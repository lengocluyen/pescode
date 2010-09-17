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
using System.Collections.Generic;

namespace ITBusSilverlight
{
    public class ITBusSilverlightCommons
    {
        public static IDictionary<string, string> parameters;

        public static ToolTip GetToolTip(string content)
        {
            ToolTip result = new ToolTip();
            result.FontWeight = FontWeights.Bold;
            result.FontSize = 17;
            result.Content = content;
            result.Foreground = new SolidColorBrush(Colors.Green);            


            result.VerticalOffset = 10;
            result.HorizontalOffset = 10;

            return result;
        }

        public static Image FindCanvasChildrenByName(Canvas root, string name)
        {
            foreach (object obj in root.Children)
            {
                if (obj is Image)
                {
                    Image img = obj as Image;
                    if (img.Name == name)
                        return img;
                }
            }
            return null;
        }

        public static int FindMaxValue(List<int> lst)
        {
            int max = 0;
            foreach (int i in lst)
                if (i > max)
                    max = i;
            return max;
        }

        public static int FindMinValue(List<int> lst)
        {
            int min = lst[0];
            for (int i = 1; i < lst.Count; i++)
                if (i < min)
                    min = i;
            return min;
        }
    }
}
