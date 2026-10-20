using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Mozi
{
    internal class Szek:Button
    {
        public bool Foglalt;
        public bool Kijelolt;
        public int Sor;
        public static int darab = 0;
        public Szek()
        {
            darab++;
            Content = darab;
            Margin = new System.Windows.Thickness(5);
            Width = 30;
            Height = 30;
            FontSize = 15;
            Szinez();
        }
        public void Szinez()
        {
            if (Foglalt)
            {
                Background = Brushes.Gray;
            }
            else if (Kijelolt)
            {
                Background = Brushes.Orange;
            }
            else 
            {
                Background = Brushes.LightGreen;
            }
        }
        public void Foglal()
        {
            Foglalt = true;
            Kijelolt = false;
            Szinez();
        }
        public void Reset()
        {
            Foglalt = false;
            Kijelolt = false;
            Szinez();
        }
        protected override void OnClick()
        {
            if (Foglalt)
            {
                return;
            }
            Kijelolt = !Kijelolt;
            Szinez();
            base.OnClick();
        }
    }
}
