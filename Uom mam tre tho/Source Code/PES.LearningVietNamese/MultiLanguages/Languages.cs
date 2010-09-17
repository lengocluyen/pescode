using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml;

namespace MultiLanguages
{
    public enum EnumLanguages
    {
        Vietnamese,
        English
    }

    public class Languages
    {
        XmlReader reader;
        EnumLanguages _lang;

        public Languages(EnumLanguages lang)
        {
            _lang = lang;
            ResetReader();
        }

        void ResetReader()
        {
            if (_lang == EnumLanguages.Vietnamese)
                reader = XmlReader.Create("lang/vi.xml");
            else if (_lang == EnumLanguages.English)
                reader = XmlReader.Create("lang/en.xml");
            else
                throw new Exception("Not supported language");
        }

        public string GetWord(string key)
        {
            string value = key;
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name == key)
                        {
                            reader.Read();
                            value = reader.Value;
                        }                        
                        break;                                   
                }
            }

            reader.Close();
            ResetReader();
            return value;
        }
    }
}
