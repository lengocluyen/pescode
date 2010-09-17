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

namespace ChuOngThongMinh
{
    public class AppEnum
    {
        public enum Level
        {
            level1 = 0,
            level2 = 500,
            level3 = 1750
        };

        public enum AnimationTicker
        {
            dropBall,
            beginTired,
            endTired,
            normal,
            startUp
        };

        public enum Calculation
        {
            mathAdd = 1,
            mathdEliminate
        }
    }
}