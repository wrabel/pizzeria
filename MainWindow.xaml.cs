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

namespace pizzeria
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Pizza pizza = new Pizza();
        int ilosc_skladnikow = 0;
        bool czy_sos = false;
        public MainWindow()
        {
            InitializeComponent();
            btn_add_skladnika.Visibility = Visibility.Hidden;
            btn_add_nazwa_pizzy.Visibility = Visibility.Hidden;
            btn_add_sos.Visibility = Visibility.Hidden;
            btn_dostawa.Visibility = Visibility.Hidden;
            btn_skladnik_add.Visibility = Visibility.Hidden;
            btn_sprawdz_godzine.Visibility = Visibility.Hidden;

            txtbox_cena_skladnika.Visibility = Visibility.Hidden;
            txtbox_godzina.Visibility = Visibility.Hidden;
            txtbox_nazwa.Visibility = Visibility.Hidden;
            txtbox_skladnik.Visibility = Visibility.Hidden;
            txtbox_sos.Visibility = Visibility.Hidden;
            txt_cena_skladnika.Visibility = Visibility.Hidden;
            txt_godzina.Visibility = Visibility.Hidden;
            txt_nazwa.Visibility = Visibility.Hidden;
            txt_skladnik.Visibility = Visibility.Hidden;
            txt_sos.Visibility = Visibility.Hidden;

            comboBox.Visibility = Visibility.Hidden;

        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            if (txtbox_nazwa.Text.ToString() == "")
            {
                MessageBox.Show("Podaj nazwe Pizzy", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                pizza.UstawNazwe(txtbox_nazwa.Text);
                btn_skladnik_add.Visibility = Visibility.Visible;

            }
            
        }

        private void btn_pizza_add_Click(object sender, RoutedEventArgs e)
        {
            txt_nazwa.Visibility = Visibility.Visible;
            txtbox_nazwa.Visibility = Visibility.Visible;
            btn_add_nazwa_pizzy.Visibility = Visibility.Visible;
        }

        private void btn_skladnik_add_Click(object sender, RoutedEventArgs e)
        {
            txtbox_skladnik.Visibility = Visibility.Visible;
            txt_skladnik.Visibility = Visibility.Visible; ;
            txtbox_cena_skladnika.Visibility = Visibility.Visible;
            txt_cena_skladnika.Visibility = Visibility.Visible;
            btn_add_skladnika.Visibility = Visibility.Visible;

            txt_sos.Visibility = Visibility.Visible;
            txtbox_sos.Visibility = Visibility.Visible;
            btn_add_sos.Visibility = Visibility.Visible;

            txt_nazwa.Visibility = Visibility.Hidden;
            txtbox_nazwa.Visibility = Visibility.Hidden;
            btn_add_nazwa_pizzy.Visibility = Visibility.Hidden;
        }

        private void btn_add_skladnika_Click(object sender, RoutedEventArgs e)
        {
            
            if (txtbox_skladnik.Text.ToString() == "")
            {
                MessageBox.Show("Podaj nazwe skadnika", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            try
            {
                if (double.Parse(txtbox_cena_skladnika.Text.ToString()) <= 0)
                {
                    MessageBox.Show("cena nei moze byc ujemna", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
                pizza.DodajSkladnik(txtbox_skladnik.Text, double.Parse(txtbox_cena_skladnika.Text.ToString()));
                txt_zamowienie.Text = pizza.ToString();
                ilosc_skladnikow += 1;
                if (ilosc_skladnikow > 2 && czy_sos) { btn_dostawa.Visibility = Visibility.Visible; }
                    
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }

        }

        private void btn_add_sos_Click(object sender, RoutedEventArgs e)
        {
            if (txtbox_sos.Text.ToString() == "")
            {
                MessageBox.Show("podaj nazwe sosu", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            czy_sos = true;
            pizza.DodajSos(txtbox_sos.Text);
            txt_zamowienie.Text = pizza.ToString();
            if (ilosc_skladnikow > 2 && czy_sos) { btn_dostawa.Visibility = Visibility.Visible; }

        }
     
        private void btn_dostawa_Click(object sender, RoutedEventArgs e)
        {
            txtbox_skladnik.Visibility = Visibility.Hidden;
            txt_skladnik.Visibility = Visibility.Hidden; ;
            txtbox_cena_skladnika.Visibility = Visibility.Hidden;
            txt_cena_skladnika.Visibility = Visibility.Hidden;
            btn_add_skladnika.Visibility = Visibility.Hidden;

            txt_sos.Visibility = Visibility.Hidden;
            txtbox_sos.Visibility = Visibility.Hidden;
            btn_add_sos.Visibility = Visibility.Hidden;

            comboBox.Visibility = Visibility.Visible;
            txtbox_godzina.Visibility = Visibility.Visible;
            txt_godzina.Visibility = Visibility.Visible;
            btn_sprawdz_godzine.Visibility = Visibility.Visible;
        }

        private void btn_sprawdz_godzine_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtbox_godzina.Text.Length < 5)
                {
                    MessageBox.Show("podaj poprawny format godziny", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
                var time = TimeSpan.Parse(txtbox_godzina.Text);
                var dateTime = DateTime.Today.Add(time);
                switch (comboBox.SelectedIndex)
                {
                    case 0:
                        NaWynos wynos = new NaWynos();
                        wynos.UstawCzasDostawy(dateTime);
                        if (wynos.PoprawnyCzas()) MessageBox.Show("wszystko ok", "Zrobione", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        else MessageBox.Show("nie dotrzemy na czas", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        break;
                    case 1:
                        NaMiejscu miejsce = new NaMiejscu();
                        miejsce.UstawCzasDostawy(dateTime);
                        if (miejsce.PoprawnyCzas()) MessageBox.Show("wszystko ok", "Zrobione", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        else MessageBox.Show("nie zdarzymy", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        break;
                }
            }
            catch
            {
                MessageBox.Show("podaj poprawny czas", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }

        }
    }
}
