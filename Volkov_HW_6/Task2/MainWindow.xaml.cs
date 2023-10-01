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

namespace Task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int password;

        public MainWindow()
        {
            InitializeComponent();
            password = 4253;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            textBox.Text += button.Content.ToString();
        }
        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            textBox.Text = "";
        }

        private void Button_Click_OK(object sender, RoutedEventArgs e)
        {
            if(textBox.Text == password.ToString()) 
            {
                MessageBox.Show("Safe open!");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
