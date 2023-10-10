using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup.Localizer;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Volkov_HW_9
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
            Button button = (Button)sender;

            if(button.Content.ToString() == "+" ||  button.Content.ToString() == "-" || button.Content.ToString() == "*" || button.Content.ToString() == "/")
            {
                if (ExpressionBox.Text.Contains("="))
                {
                    ExpressionBox.Clear();
                    ExpressionBox.Text += SummaBox.Text + button.Content.ToString();
                    SummaBox.Clear();
                }
                else if (SummaBox.Text == "Деление на ноль невозможно")
                {
                    MessageBox.Show("Введите число!");
                    SummaBox.Clear();
                }
                else
                {
                    ExpressionBox.Text += SummaBox.Text + button.Content.ToString();
                    SummaBox.Clear();
                }
            }
            else
            {
                if(SummaBox.Text.Contains("0")) 
                {
                    int index = SummaBox.Text.IndexOf("0");
                    if(index != 0 || SummaBox.Text.Contains("."))
                    {
                        SummaBox.Text += button.Content.ToString();
                    }
                    else if(button.Content.ToString() == ".")
                    {
                        SummaBox.Text += button.Content.ToString();
                    }
                }
                else
                {
                    if (SummaBox.Text == "Деление на ноль невозможно")
                    {
                        ExpressionBox.Clear();
                        SummaBox.Clear();
                        SummaBox.Text += button.Content.ToString();
                    }
                    else
                    {
                        SummaBox.Text += button.Content.ToString();
                    }
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SummaBox.Clear();
            ExpressionBox.Clear();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if(SummaBox.Text != string.Empty && ExpressionBox.Text.Contains("=") == false)
                {
                    ExpressionBox.Text += SummaBox.Text;
                    SummaBox.Clear();
                }
                if(ExpressionBox.Text.Contains("="))
                {
                    return;
                }
                if (ExpressionBox.Text.Contains("/0"))
                {
                    SummaBox.Text = "Деление на ноль невозможно";
                    throw new DivideByZeroException();
                }
                SummaBox.Text = new DataTable().Compute(ExpressionBox.Text, null).ToString();
                ExpressionBox.Text += "=";
                if (SummaBox.Text.Contains(","))
                {
                    SummaBox.Text = SummaBox.Text.Replace(",", ".");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SummaBox.Clear();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            SummaBox.Text = SummaBox.Text.Substring(0, SummaBox.Text.Length - 1);
        }
    }
}
