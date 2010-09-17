// 
//   SubSonic - http://subsonicproject.com
// 
//   The contents of this file are subject to the New BSD
//   License (the "License"); you may not use this file
//   except in compliance with the License. You may obtain a copy of
//   the License at http://www.opensource.org/licenses/bsd-license.php
//  
//   Software distributed under the License is distributed on an 
//   "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, either express or
//   implied. See the License for the specific language governing
//   rights and limitations under the License.
// 
using System;
using System.Text;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Web;
using SubSonic.Extensions;

namespace SubSonic.Helpers
{
    public class Utility
    {

        #region URL Related

        /// <summary>
        /// Gets the parameter.
        /// </summary>
        /// <param name="sParam">The s param.</param>
        /// <returns></returns>
        public static string GetParameter(string sParam)
        {
            if (HttpContext.Current.Request.QueryString[sParam] != null)
                return HttpContext.Current.Request[sParam];
            return string.Empty;
        }

        public static string GetParameter(string sParam, bool includeForm)
        {
            if (includeForm == true && HttpContext.Current.Request.Form[sParam] != null)
                return HttpContext.Current.Request.Form[sParam];

            if (HttpContext.Current.Request.QueryString[sParam] != null)
                return HttpContext.Current.Request[sParam];
            return string.Empty;
        }

        /// <summary>
        /// Gets the int parameter.
        /// </summary>
        /// <param name="sParam">The s param.</param>
        /// <returns></returns>
        public static int GetIntParameter(string sParam)
        {
            int iOut = 0;
            if (HttpContext.Current.Request.QueryString[sParam] != null)
            {
                string sOut = HttpContext.Current.Request[sParam];
                if (!String.IsNullOrEmpty(sOut))
                    int.TryParse(sOut, out iOut);
            }
            return iOut;
        }

        /// <summary>
        /// Gets the GUID parameter.
        /// </summary>
        /// <param name="sParam">The s param.</param>
        /// <returns></returns>
        public static Guid GetGuidParameter(string sParam)
        {
            Guid gOut = Guid.Empty;
            if (HttpContext.Current.Request.QueryString[sParam] != null)
            {
                string sOut = HttpContext.Current.Request[sParam];
                if (SubSonic.Extensions.Validation.IsGuid(sOut))
                    gOut = new Guid(sOut);
            }
            return gOut;
        }

        #endregion

        #region Random Generators

        /// <summary>
        /// Gets the random string.
        /// </summary>
        /// <returns></returns>
        public static string GetRandomString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, false));
            builder.Append(RandomInt(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }

        /// <summary>
        /// Randoms the string.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <param name="lowerCase">if set to <c>true</c> [lower case].</param>
        /// <returns></returns>
        private static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                char ch = Convert.ToChar(Convert.ToInt32(26 * random.NextDouble() + 65));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        /// <summary>
        /// Randoms the int.
        /// </summary>
        /// <param name="min">The min.</param>
        /// <param name="max">The max.</param>
        /// <returns></returns>
        private static int RandomInt(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        #endregion

        #region Lists

        /// <summary>
        /// Loads the drop down.
        /// </summary>
        /// <param name="ddl">The DDL.</param>
        /// <param name="collection">The collection.</param>
        /// <param name="textField">The text field.</param>
        /// <param name="valueField">The value field.</param>
        /// <param name="initialSelection">The initial selection.</param>
        public static void LoadDropDown(ListControl ddl,
            ICollection collection,
            string textField,
            string valueField,
            string initialSelection)
        {
            ddl.DataSource = collection;
            ddl.DataTextField = textField;
            ddl.DataValueField = valueField;
            ddl.DataBind();
            ddl.SelectedValue = initialSelection;
        }

        /// <summary>
        /// Loads the drop down.
        /// </summary>
        /// <param name="listControl">The list control.</param>
        /// <param name="dataReader">The data reader.</param>
        /// <param name="closeReader">if set to <c>true</c> [close reader].</param>
        public static void LoadDropDown(ListControl listControl, IDataReader dataReader, bool closeReader)
        {
            listControl.Items.Clear();

            if (closeReader)
            {
                using (dataReader)
                {
                    while (dataReader.Read())
                    {
                        string sText = dataReader[1].ToString();
                        string sVal = dataReader[0].ToString();
                        listControl.Items.Add(new ListItem(sText, sVal));
                    }
                    dataReader.Close();
                }
            }
            else
            {
                while (dataReader.Read())
                {
                    string sText = dataReader[1].ToString();
                    string sVal = dataReader[0].ToString();
                    listControl.Items.Add(new ListItem(sText, sVal));
                }
            }
        }

        /// <summary>
        /// Loads the list items.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="tblBind">The TBL bind.</param>
        /// <param name="tblVals">The TBL vals.</param>
        /// <param name="textField">The text field.</param>
        /// <param name="valField">The val field.</param>
        public static void LoadListItems(ListItemCollection list, DataTable tblBind, DataTable tblVals, string textField, string valField)
        {
            for (int i = 0; i < tblBind.Rows.Count; i++)
            {
                ListItem l = new ListItem(tblBind.Rows[i][textField].ToString(), tblBind.Rows[i][valField].ToString());

                for (int x = 0; x < tblVals.Rows.Count; x++)
                {
                    DataRow dr = tblVals.Rows[x];
                    if (dr[valField].ToString().Matches(l.Value))
                        l.Selected = true;
                }
                list.Add(l);
            }
        }

        /// <summary>
        /// Loads the list items.
        /// </summary>
        /// <param name="listCollection">The list.</param>
        /// <param name="dataReader">The data reader.</param>
        /// <param name="textField">The text field.</param>
        /// <param name="valueField">The value field.</param>
        /// <param name="selectedValue">The selected value.</param>
        /// <param name="closeReader">if set to <c>true</c> [close reader].</param>
        public static void LoadListItems(ListItemCollection listCollection, IDataReader dataReader, string textField, string valueField, string selectedValue, bool closeReader)
        {
            listCollection.Clear();

            if (closeReader)
            {
                using (dataReader)
                {
                    while (dataReader.Read())
                    {
                        string sText = dataReader[textField].ToString();
                        string sVal = dataReader[valueField].ToString();

                        ListItem l = new ListItem(sText, sVal);
                        if (!String.IsNullOrEmpty(selectedValue))
                            l.Selected = selectedValue.Matches(sVal);
                        listCollection.Add(l);
                    }
                    dataReader.Close();
                }
            }
            else
            {
                while (dataReader.Read())
                {
                    string sText = dataReader[textField].ToString();
                    string sVal = dataReader[valueField].ToString();

                    ListItem l = new ListItem(sText, sVal);
                    if (!String.IsNullOrEmpty(selectedValue))
                        l.Selected = selectedValue.Matches(sVal);
                    listCollection.Add(l);
                }
            }
        }

        /// <summary>
        /// Sets the list selection.
        /// </summary>
        /// <param name="lc">The lc.</param>
        /// <param name="Selection">The selection.</param>
        public static void SetListSelection(ListItemCollection lc, string Selection)
        {
            for (int i = 0; i < lc.Count; i++)
            {
                if (lc[i].Value == Selection)
                {
                    lc[i].Selected = true;
                    break;
                }
            }
        }


        #endregion
    }
}