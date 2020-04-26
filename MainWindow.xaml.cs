using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfRegex
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            Regex regex = new Regex(@"^\d{11}$");

            RegTextBox.Text = "";


            string pattern = @"^\d{11}$";
            string text = "01234567891234";
            MatchCollection matches;

            Regex defaultRegex = new Regex(pattern);
            // Get matches of pattern in text
            matches = defaultRegex.Matches(text);
            Console.WriteLine("Parsing '{0}'", text);
            // Iterate matches
            for (int ctr = 0; ctr < matches.Count; ctr++)
                Console.WriteLine("{0}. {1}", ctr, matches[ctr].Value);
        }

        private void RegTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Regex regex = new Regex(@"^\d{0,18}$");
            bool isillegel = regex.IsMatch(RegTextBox.Text);
            if (!isillegel)
            {
                e.Handled = true;
                return;
            }


            string keyvalue = e.ImeProcessedKey.ToString();
            if (keyvalue=="None")
            {
                keyvalue = e.Key.ToString();
            }
            //Debug.WriteLine($"Preview Key Value:{ keyvalue}");
            //Regex rg = new Regex("^[0-9]*$");  //正则表达式
            Regex rg = new Regex("^D+[0-9]$");  //正则表达式
            
            bool match = rg.IsMatch(keyvalue);
            //if (!rg.IsMatch(keyvalue) && keyvalue != $"\b") //'\b'是退格键
            if (!rg.IsMatch(keyvalue) && keyvalue != $"Back") //'\b'是退格键
            {
                Debug.WriteLine($"Preview:{keyvalue}:不显示！");
                e.Handled = true;
            }
        }

        private void RegTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Regex regex = new Regex(@"^\d{0,18}$");
            bool isillegel = regex.IsMatch(RegTextBox.Text);
            if (!isillegel)
            {
                e.Handled = true;
                return;
            }


            string keyvalue = e.ImeProcessedKey.ToString();
            if (keyvalue == "None")
            {
                keyvalue = e.Key.ToString();
            }
            //Debug.WriteLine($"Key Value:{ keyvalue}");
            //Regex rg = new Regex("^[0-9]*$");  //正则表达式
            Regex rg = new Regex("^D+[0-9]$");  //正则表达式
            
            bool match = rg.IsMatch(keyvalue);
            //if (!rg.IsMatch(keyvalue) && keyvalue != $"\b") //'\b'是退格键
            if (!rg.IsMatch(keyvalue) && keyvalue != $"Back") //'\b'是退格键
            {
                Debug.WriteLine($"{keyvalue}:不显示！");
                e.Handled = true;
            }
        }

        private void RegTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string oldstring = textBox.Text;
            Regex regex = new Regex(@"^\d{0,18}$");
            bool isillegel =regex.IsMatch(e.Text);
            if (!isillegel)
            {
                int startindex = textBox.Text.Length - e.Text.Length;
               string noldstring=oldstring.Remove(startindex, e.Text.Length);
                textBox.Text = noldstring;
                textBox.CaretIndex = textBox.Text.Length;
                e.Handled = true;
            }
        }
    }
}
