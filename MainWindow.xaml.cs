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

namespace Kalkulator
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string liczba1 = string.Empty;
        string liczba2 = string.Empty;
        char dzialanie = ' ';

        private void Number_click(object sender, RoutedEventArgs e)
        {
            Button number = (Button)sender;
            string str = Convert.ToString(number.Content);
            if(dzialanie == 'a')
            {
                txtBox.Text = string.Empty;
                dzialanie = ' ';
            }
            if (dzialanie == ' ')
            {
                txtBox.Text += str;
                liczba1 = txtBox.Text;
            }
            else
            {
                txtBox.Text += str;
                liczba2 = txtBox.Text;
            }
        }

        private void Przecinek_click(object sender, RoutedEventArgs e)
        {
            if (txtBox.Text.Contains(',') || txtBox.Text.Length == 0)
                return;

            txtBox.Text += ',';
        }

        private void Clear_click(object sender, RoutedEventArgs e)
        {
            txtBox.Text = string.Empty;
            liczba1 = string.Empty;
            liczba2 = string.Empty;
            dzialanie = ' ';
        }

        private void Dzielenie_click(object sender, RoutedEventArgs e)
        {
            dzialanie = '/';
            txtBox.Text = string.Empty;
        }

        private void Mnozenie_click(object sender, RoutedEventArgs e)
        {
            dzialanie = '*';
            txtBox.Text = string.Empty;
        }

        private void Dodawanie_click(object sender, RoutedEventArgs e)
        {
            dzialanie = '+';
            txtBox.Text = string.Empty;
        }

        private void Odejmowanie_click(object sender, RoutedEventArgs e)
        {
            dzialanie = '-';
            txtBox.Text = string.Empty;
        }

        private void Wynik_click(object sender, RoutedEventArgs e)
        {
            switch(dzialanie)
            {
                case '+':
                    if (liczba1 == string.Empty)
                        liczba1 = "0";
                    else if (liczba2 == string.Empty)
                        liczba2 = "0";
                    
                    txtBox.Text = (double.Parse(liczba1) + double.Parse(liczba2)).ToString();
                    liczba1 = txtBox.Text;
                    break;
                case '-':
                    if (liczba1 == string.Empty)
                        liczba1 = "0";
                    else if (liczba2 == string.Empty)
                        liczba2 = "0";

                    txtBox.Text = (double.Parse(liczba1) - double.Parse(liczba2)).ToString();
                    liczba1 = txtBox.Text;
                    break;
                case '*':
                    if (liczba1 == string.Empty)
                        liczba1 = "1";
                    else if (liczba2 == string.Empty)
                        liczba2 = "1";

                    txtBox.Text = (double.Parse(liczba1) * double.Parse(liczba2)).ToString();
                    liczba1 = txtBox.Text;
                    break;
                case '/':
                    if (liczba1 == string.Empty)
                        liczba1 = "0";
                    else if (liczba2 == string.Empty)
                        liczba2 = "1";

                    if (double.Parse(liczba2) == 0)
                    {
                        txtBox.Text = "BŁĄD";
                    }
                    else
                    {
                        txtBox.Text = (double.Parse(liczba1) / double.Parse(liczba2)).ToString();
                        liczba1 = txtBox.Text;
                    }
                    break;
            }
            liczba2 = string.Empty;
            dzialanie = 'a';
        }
    }
}
