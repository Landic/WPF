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

namespace Task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(A11.Text) == false && string.IsNullOrEmpty(A12.Text) == false && string.IsNullOrEmpty(A13.Text) == false &&
                string.IsNullOrEmpty(A21.Text) == false && string.IsNullOrEmpty(A22.Text) == false && string.IsNullOrEmpty(A23.Text) == false &&
                string.IsNullOrEmpty(A31.Text) == false && string.IsNullOrEmpty(A32.Text) == false && string.IsNullOrEmpty(A33.Text) == false)
            {
                if (A11.Text.Any(char.IsLetter) == false && A12.Text.Any(char.IsLetter) == false && A13.Text.Any(char.IsLetter) == false &&
                    A21.Text.Any(char.IsLetter) == false && A22.Text.Any(char.IsLetter) == false && A23.Text.Any(char.IsLetter) == false &&
                    A31.Text.Any(char.IsLetter) == false && A32.Text.Any(char.IsLetter) == false && A33.Text.Any(char.IsLetter) == false)
                {
                    Answer.Content = float.Parse(A11.Text) * float.Parse(A22.Text) * float.Parse(A33.Text) -
                     float.Parse(A11.Text) * float.Parse(A23.Text) * float.Parse(A32.Text) -
                     float.Parse(A12.Text) * float.Parse(A21.Text) * float.Parse(A33.Text) +
                     float.Parse(A12.Text) * float.Parse(A23.Text) * float.Parse(A31.Text) +
                     float.Parse(A13.Text) * float.Parse(A21.Text) * float.Parse(A32.Text) -
                     float.Parse(A13.Text) * float.Parse(A22.Text) * float.Parse(A31.Text);
                }
                else
                {
                    MessageBox.Show("Матрица содержит буквы!");
                }
            }
            else
            {
                MessageBox.Show("Матрица пустая!");
            }
        }
    }
}
