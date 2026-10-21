using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mozi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int Sorok = 12;
        int Oszlopok = 20;
        int Ar = 2500;
        List<Szek> szekek = new List<Szek>();
        public MainWindow()
        {
            InitializeComponent();
            TeremKeszites();
            Frissit();
        }
        private void TeremKeszites()
        {
            for (int i = 0; i < Sorok; i++)
            {
                Szek.darab = 0;
                StackPanel sor = new StackPanel();
                sor.Orientation = Orientation.Horizontal;
                for (int k = 0; k < Oszlopok; k++)
                {
                    Szek sz = new Szek();
                    sz.Click += Szek_Click;
                    sz.Sor = i + 1;
                    szekek.Add(sz);
                    sor.Children.Add(sz);
                }
                Terem.Children.Add(sor);
            }
        }
        private void Szek_Click(object sender, RoutedEventArgs e) {
            Frissit();
        }
        private void Frissit()
        {
            int db = 0;
            int szabad = 0;
            foreach (Szek sz in szekek)
            {
                if (sz.Kijelolt)
                {
                    db++;
                }
                if (!sz.Foglalt)
                {
                    szabad++;
                }
            }
            Info.Content = "Kijelölt székek: " + db + " db, " + (db * Ar) + " Ft";
            Szabad.Content = "Szabad helyek: " + szabad + " db";
        }
        private void Foglalas_Click(object sender, RoutedEventArgs e)
        {
            string uzenet = "";
            int db = 0;
            foreach (Szek sz in szekek)
            {
                if (sz.Kijelolt)
                {
                    uzenet += sz.Sor + ". sor, " + sz.Content + ". szék\n";
                    sz.Foglal();
                    db++;
                }
            }
            if (db > 0)
            {
                int szabadszekek = 0;
                foreach (Szek sz in szekek)
                {
                    if (!sz.Foglalt)
                    {
                        szabadszekek++;
                    }
                }
                uzenet += "\nÖsszesen: " + db + " szék, " + (db * Ar) + " Ft\nSzabad székek száma: " + szabadszekek;
                MessageBox.Show(uzenet, "Sikeres foglalás");
            }
            Frissit();
        }
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            foreach (Szek sz in szekek)
            {
                sz.Reset();
            }
            Frissit();
        }

    }
}
