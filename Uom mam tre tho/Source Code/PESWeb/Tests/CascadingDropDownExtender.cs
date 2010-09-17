// (c) Copyright Microsoft Corporation. 
// This source is subject to the Microsoft Permissive License. 
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx. 
// All other rights reserved. 
 
 
using System; 
using System.ComponentModel; 
using System.Collections; 
using System.Collections.Specialized; 
using System.Collections.Generic; 
using System.Globalization; 
using System.Text; 
using Microsoft.Web.UI; 
using System.Web; 
using System.Web.UI; 
using System.Web.UI.WebControls; 
using System.Xml; 
using Microsoft.AtlasControlExtender; 
 
#region Assembly Resource Attribute 
[assembly: System.Web.UI.WebResource("AtlasControlToolkit.CascadingDropDown.CascadingDropDownBehavior.js", "text/javascript")] 
#endregion 
 
namespace AtlasControlToolkit 
{ 
    ///  
    /// CascadingDropDown extender class definition 
    ///  
    [Designer(typeof(CascadingDropDownDesigner))] 
    [ClientScriptResource("atlascontroltoolkit", "cascadingDropDownBehavior", typeof(CascadingDropDown), "CascadingDropDown.CascadingDropDownBehavior.js")] 
    [RequiredScript(typeof(CommonToolkitScripts))] 
    public class CascadingDropDown : ExtenderControlBase 
    { 
        ///  
        /// OnLoad override to pre-populate DropDownLists with prompt text 
        ///  
        /// arguments 
        protected override void OnLoad(EventArgs e) 
        { 
            base.OnLoad(e); 
            foreach (CascadingDropDownProperties cascadingDropDownProperties in TargetProperties) 
            { 
                // Find control, clear existing content, and set the selected value so we can 
                // access it normally on the server-side. 
                // 
                DropDownList dropDownList = (DropDownList)FindControlHelper(cascadingDropDownProperties.TargetControlID); 
                dropDownList.Items.Clear(); 
                dropDownList.Items.Add(cascadingDropDownProperties.ClientState); 
            } 
        } 
 
        protected override void OnPreRender(EventArgs e) 
        { 
            //// clear the dropdowns. 
            //// 
            foreach (CascadingDropDownProperties cascadingDropDownProperties in TargetProperties) 
            { 
                DropDownList dropDownList = (DropDownList)FindControlHelper(cascadingDropDownProperties.TargetControlID); 
                dropDownList.Items.Clear(); 
            } 
 
            base.OnPreRender(e); 
        } 
 
        protected override string GetClientClassForControl(Control control) 
        { 
            string clientClass = base.GetClientClassForControl(control); 
            if ("select" == clientClass) 
            { 
                // Atlas doesn't currently hook up "select" controls, so tell it this is just a generic control 
                clientClass = "control"; 
            } 
            return clientClass; 
        } 
 
        ///  
        /// Helper method to parse the private storage format used to communicate known category/value pairs 
        ///  
        /// private storage format string 
        /// dictionary of category/value pairs 
        public static StringDictionary ParseKnownCategoryValuesString(string knownCategoryValues) 
        { 
            // Validate parameters 
            if (null == knownCategoryValues) 
            { 
                throw new ArgumentNullException("knownCategoryValues"); 
            } 
 
            StringDictionary dictionary = new StringDictionary(); 
            if (null != knownCategoryValues) 
            { 
                // Split into category/value pairs 
                foreach (string knownCategoryValue in knownCategoryValues.Split(';')) 
                { 
                    // Split into category and value 
                    string[] knownCategoryValuePair = knownCategoryValue.Split(':'); 
                    if (2 == knownCategoryValuePair.Length) 
                    { 
                        // Add the pair to the dictionary 
                        dictionary.Add(knownCategoryValuePair[0].ToLowerInvariant(), knownCategoryValuePair[1]); 
                    } 
                } 
            } 
            return dictionary; 
        } 
 
        ///  
        /// Helper method to provide a simple implementation of a method to query a data set and return the relevant drop down contents 
        ///  
        /// XML document containing the data set 
        /// list of strings representing the hierarchy of the data set 
        /// known category/value pairs 
        /// category for which the drop down contents are desired 
        /// contents of the specified drop down subject to the choices already made 
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1059:MembersShouldNotExposeCertainConcreteTypes", Justification = "Non-IXPathNavigable members of XmlDocument are used")] 
        public static CascadingDropDownNameValue[] QuerySimpleCascadingDropDownDocument(XmlDocument document, string[] documentHierarchy, StringDictionary knownCategoryValuesDictionary, string category) 
        { 
            // Validate parameters 
            if (null == document) 
            { 
                throw new ArgumentNullException("document"); 
            } 
            if (null == documentHierarchy) 
            { 
                throw new ArgumentNullException("documentHierarchy"); 
            } 
            if (null == knownCategoryValuesDictionary) 
            { 
                throw new ArgumentNullException("knownCategoryValuesDictionary"); 
            } 
            if (null == category) 
            { 
                throw new ArgumentNullException("category"); 
            } 
 
            // Root the XPath query 
            string xpath = "/" + document.DocumentElement.Name; 
 
            // Build an XPath query into the data set to select the relevant items 
            foreach (string key in documentHierarchy) 
            { 
                if (knownCategoryValuesDictionary.ContainsKey(key)) 
                { 
                    xpath += string.Format(CultureInfo.CurrentCulture, "/{0}[(@name and @value='{1}') or (@name='{1}' and not(@value))]", key, knownCategoryValuesDictionary[key]); 
                } 
            } 
            xpath += ("/" + category.ToLowerInvariant()); 
 
            // Perform the XPath query and add the results to the list 
            List result = new List(); 
            foreach (XmlNode node in document.SelectNodes(xpath)) 
            { 
                string name = node.Attributes.GetNamedItem("name").Value; 
                XmlNode valueNode = node.Attributes.GetNamedItem("value"); 
                string value = ((null != valueNode) ? valueNode.Value : name); 
                result.Add(new CascadingDropDownNameValue(name, value)); 
            } 
 
            // Return the list 
            return result.ToArray(); 
        } 
    } 
} 