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
using System.Text;

namespace HocChuCai_2
{
    public class FontHandle
    {
        public static string TranslateUnicodeCharToBKHCM2(string character)
        {
            string[] arrUnicode = new string[]  {"à","á","ạ","ả","ã","â","ầ","ấ","ậ","ẩ","ẫ","ă",
                                                "ằ","ắ","ặ","ẳ","ẵ","è","é","ẹ","ẻ","ẽ","ê","ề"
                                                ,"ế","ệ","ể","ễ",
                                                "ì","í","ị","ỉ","ĩ",
                                                "ò","ó","ọ","ỏ","õ","ô","ồ","ố","ộ","ổ","ỗ","ơ"
                                                ,"ờ","ớ","ợ","ở","ỡ",
                                                "ù","ú","ụ","ủ","ũ","ư","ừ","ứ","ự","ử","ữ",
                                                "ỳ","ý","ỵ","ỷ","ỹ",
                                                "đ",
                                                "À","Á","Ạ","Ả","Ã","Â","Ầ","Ấ","Ậ","Ẩ","Ẫ","Ă"
                                                ,"Ằ","Ắ","Ặ","Ẳ","Ẵ",
                                                "È","É","Ẹ","Ẻ","Ẽ","Ê","Ề","Ế","Ệ","Ể","Ễ",
                                                "Ì","Í","Ị","Ỉ","Ĩ",
                                                "Ò","Ó","Ọ","Ỏ","Õ","Ô","Ồ","Ố","Ộ","Ổ","Ỗ","Ơ"
                                                ,"Ờ","Ớ","Ợ","Ở","Ỡ",
                                                "Ù","Ú","Ụ","Ủ","Ũ","Ư","Ừ","Ứ","Ự","Ử","Ữ",
                                                "Ỳ","Ý","Ỵ","Ỷ","Ỹ",
                                                "Đ"};

            string[] arrBKHCM2 = new string[]  {"aâ","aá","aå","aã","aä","ê","êì","êë","êå","êí","êî","ù",
                                                "ùç","ùæ","ùå","ùè","ùé","eâ","eá","eå","eã","eä","ï","ïì"
                                                ,"ïë","ïå","ïí","ïî",
                                                "ò","ñ","õ","ó","ô",
                                                "oâ","oá","oå","oã","oä","ö","öì","öë","öå","öí","öî","ú"
                                                ,"úâ","úá","úå","úã","úä",
                                                "uâ","uá","uå","uã","uä","û","ûâ","ûá","ûå","ûã","ûä",
                                                "yâ","yá","yå","yã","yä",
                                                "à",
                                                "AÂ","AÁ","AÅ","AÃ","AÄ","Ê","ÊÌ","ÊË","ÊÅ","ÊÍ","ÊÎ","Ù"
                                                ,"ÙÇ","ÙÆ","ÙÅ","ÙÈ","ÙÉ",
                                                "EÂ","EÁ","EÅ","EÃ","EÄ","Ï","ÏÌ","ÏË","Ïå","ÏÍ","ÏÎ",
                                                "Ò","Ñ","Õ","Ó","Ô",
                                                "OÂ","OÁ","OÅ","OÃ","OÄ","Ö","ÖÌ","ÖË","ÖÅ","ÖÍ","ÖÎ","Ú"
                                                ,"ÚÂ","ÚÁ","ÚÅ","ÚÃ","ÚÄ",
                                                "UÂ","UÁ","UÅ","UÃ","UÄ","Û","ÛÂ","ÛÁ","ÛÅ","ÛÃ","ÛÄ",
                                                "YÂ","YÁ","YÅ","YÃ","YÄ",
                                                "À"};

            for (int i = 0; i < arrUnicode.Length; i++)
            {
                if (character == arrUnicode[i])
                {
                    character = character.Replace(arrUnicode[i], arrBKHCM2[i]);
                    break;
                }
            }

            return character;
        }

        public static string TranslateUnicodeTextToBKHCM2(string text)
        {
            string textResult = "";
            for (int i = 0; i < text.Length; i++)
                textResult += TranslateUnicodeCharToBKHCM2(text[i].ToString());

            return textResult;
        }
    }
}
