using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Danh_Trong.Objects
{
    public partial class Drums : UserControl
    {
        public Drums()
        {
            InitializeComponent();
        }

        public void Play(int position)
        {
            if (position == 1)
                PlayXen1();
            else if (position == 2)
                PlayDrum1();
            else if (position == 3)
                PlayDrum2();
            else if (position == 4)
                PlayDrum3();
            else if (position == 5)
                PlayXen2();
        }

        void PlayXen1()
        {
            this.stbLeftXen.Begin();
            this.SoundXen1.Position = TimeSpan.FromSeconds(0);
            this.SoundXen1.Play();
        }

        void PlayXen2()
        {
            this.stbRightXen.Begin();
            this.SoundXen2.Position = TimeSpan.FromSeconds(0);
            this.SoundXen2.Play();
        }

        void PlayDrum1()
        {
            this.stbDrum1.Begin();
            this.SoundDrum1.Position = TimeSpan.FromSeconds(0);
            this.SoundDrum1.Play();
        }

        void PlayDrum2()
        {
            this.stbDrum2.Begin();
            this.SoundDrum2.Position = TimeSpan.FromSeconds(0);
            this.SoundDrum2.Play();
        }

        void PlayDrum3()
        {
            this.stbDrum3.Begin();
            this.SoundDrum3.Position = TimeSpan.FromSeconds(0);
            this.SoundDrum3.Play();
        }
    }
}
