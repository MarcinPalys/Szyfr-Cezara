using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SzyfrCezara
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string szyfrogram = "";
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string jawny = TextInput.Text;
            int klucz = Convert.ToInt32(NumberInput.Text);
            for (int i = 0; i < jawny.Length; i++)
            {
                if(jawny[i] !=' ')
                {
                    szyfrogram += koduj(jawny[i], klucz);
                }
                else
                {
                    szyfrogram += ' ';
                }
            }
            TextOutput.Text = szyfrogram;
        }
        private char koduj(char znak, int klucz)
        {
            znak = Char.ToUpper(znak);
            if(znak+klucz<90)
            {
                return Convert.ToChar(znak + klucz);
            }
            else
            {
                return Convert.ToChar(znak + klucz - 26);
            }

        }
        private char dekoduj(char znak, int klucz)
        {
            znak = Char.ToUpper(znak);           
            if (znak - klucz >= 65)
            {
                return Convert.ToChar(znak - klucz);
            }
            else
            {
                return Convert.ToChar(znak - klucz + 26);
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int klucz = Convert.ToInt32(_NumberInput.Text);
            string jawny = "";
            for(int i = 0; i < szyfrogram.Length; i++)
            {
                if (szyfrogram[i] != ' ') jawny += dekoduj(szyfrogram[i], klucz);
                else jawny += ' ';
            }
            _TextOutput.Text = jawny;
        }
    }
}