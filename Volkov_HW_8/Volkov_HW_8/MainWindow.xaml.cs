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
using System.Windows.Threading;

namespace Volkov_HW_8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<int> list;
        List<Button> buttons;
        DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();
            list = new List<int>();
            buttons = new List<Button>() { button1,button2,button3,button4,
                                           button5,button6,button7,button8,
                                           button9,button10,button11,button12,
                                           button13,button14,button15,button16};
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            comboBox.Items.Add("60");
            comboBox.Items.Add("45");
            comboBox.Items.Add("30");
            comboBox.SelectedIndex = 0;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            progressbar1.Value++;
            if(progressbar1.Value == progressbar1.Maximum) 
            { 
                for (int i = 0; i < buttons.Count; i++)
                {
                    buttons[i].IsEnabled = false;
                }
                timer.Stop();
                NewGameButton.IsEnabled = true;
                MessageBox.Show("Вы проиграли!");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button but = (Button)sender;
            if (CorrectDigit(int.Parse(but.Content.ToString())))
            {
                but.IsEnabled = false;
                listbox1.Items.Add(but.Content);
                if (CheckWin())
                {
                    MessageBox.Show("Вы победили!");
                    for (int i = 0; i < buttons.Count; i++)
                    {
                        buttons[i].IsEnabled = false;
                    }
                    timer.Stop();
                    NewGameButton.IsEnabled = true;
                }
            }
        }

        private bool CheckWin()
        {
            if(list.Count == 0)
            {
                return true;
            }
            return false;   
        }

        private bool CorrectDigit(int digit)
        {
            if (list.Min() == digit)
            {
                list.Remove(list.Min());
                return true;
            }
            return false;
        }

        private void NewGame()
        {
            progressbar1.Maximum = int.Parse(comboBox.SelectedItem.ToString());
            list.Clear();
            listbox1.Items.Clear();
            Random random = new Random();
            for (int i = 0; i < buttons.Count; i++)
            {
                list.Add(random.Next(100));
            }
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Content = list[i].ToString();
                buttons[i].IsEnabled = true;
            }
            NewGameButton.IsEnabled = false;
            progressbar1.Value = 0;
            timer.Start();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NewGame();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }
    }
}
