using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using static System.Formats.Asn1.AsnWriter;

namespace Volkov_HW_10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isstart;
        bool gen;
        int highscore;
        int score;
        Button[,] button;
        int[,] board;

        public MainWindow()
        {
            InitializeComponent();
            isstart = false;
            gen = true;
            score = 0;
            button = new Button[4, 4];
            board = new int[4, 4];
            SetScore(score);
            List<Button> temp = new List<Button>();
            foreach (var i in Grid1.Children)
            {
                if (i is Button)
                {
                    temp.Add((Button)i);
                }
            }
            for (int i = 0; i < button.GetLength(0); i++)
            {
                for (int j = 0; j < button.GetLength(1); j++)
                {
                    button[i, j] = temp[i * button.GetLength(1) + j];
                }
            }
            Load();
        }
        void Load()
        {
            using (StreamReader file = new StreamReader("Score.txt", Encoding.UTF8))
            {
                highscore = int.Parse(file.ReadLine());
                HighScoreLabel.Content = highscore.ToString();
            }
        }

        void Save()
        {
            using(StreamWriter file = new StreamWriter("Score.txt", false))
            {
                file.Write(HighScoreLabel.Content);
            }
        }


        void RandomDigit()
        {
            if (gen)
            {
                Random rand = new Random();
                int i;
                int j; 
                int value = (rand.Next(10) == 0) ? 4 : 2;
                while (true)
                {
                    i = rand.Next(board.GetLength(0));
                    j = rand.Next(board.GetLength(1));
                    if (board[i, j] == 0) break;
                }
                button[i, j].Content = value.ToString();
                board[i, j] = value;
                SetColor(button[i, j]);
            }
        }


        void Set()
        {
            foreach (var i in button)
            {
                if (i.Content == "")
                {
                    gen = true;
                    return;
                }
            }
            gen = false;
        }


        void CheckLose()
        {
            foreach (var i in board)
            {
                if (i == 0)
                {
                    return;
                }
            }
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1) - 1; j++)
                {
                    if (board[i, j] == board[i, j + 1]) 
                        return;
                }
            }
            for (int i = 0; i < board.GetLength(1); i++)
            {
                for (int j = 0; j < board.GetLength(0) - 1; j++)
                {
                    if (board[j, i] == board[j + 1, i]) 
                        return;
                }
            }
            MessageBox.Show("You Lose!", "2048");
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = 0;
                }
            }
            gen = false;
            isstart = false;
            for (int i = 0; i < button.GetLength(0); i++)
            {
                for (int j = 0; j < button.GetLength(1); j++)
                {
                    button[i, j].Content = "";
                    SetColor(button[i, j]);
                }
            }
            score = 0;
            StartBut.IsEnabled = true;
            SetScore(score);
            Save();
        }


        void CheckWin()
        {
            foreach (var g in board)
            {
                if (g == 2048)
                {
                    MessageBox.Show("Win!", "2048");
                    for (int i = 0; i < board.GetLength(0); i++)
                    {
                        for (int j = 0; j < board.GetLength(1); j++)
                        {
                            board[i, j] = 0;
                        }
                    }
                    gen = false;
                    isstart = false;
                    for (int i = 0; i < button.GetLength(0); i++)
                    {
                        for (int j = 0; j < button.GetLength(1); j++)
                        {
                            button[i, j].Content = "";
                            SetColor(button[i, j]);
                        }
                    }
                    score = 0;
                    SetScore(score);
                    StartBut.IsEnabled = true;
                    Save();
                }
            }
        }
        void SetScore(int value)
        {
            score += value;
            ScoreLabel.Content = score.ToString();
            if (score > highscore)
            {
                highscore = score;
                HighScoreLabel.Content = highscore.ToString();
            }
        }
        void SetColor(Button button)
        {
            Color color = GetColor(button);
            Brush background = new SolidColorBrush(color);
            button.Background = background;
        }
        Color GetColor(Button button)
        {
            switch (button.Content)
            {
                case "2":
                    return Color.FromRgb(238, 228, 218);
                case "4":
                    return Color.FromRgb(237, 224, 200);
                case "8":
                    return Color.FromRgb(242, 177, 121);
                case "16":
                    return Color.FromRgb(245, 149, 99);
                case "32":
                    return Color.FromRgb(246, 124, 96);
                case "64":
                    return Color.FromRgb(246, 94, 59);
                case "128":
                    return Color.FromRgb(237, 207, 115);
                case "256":
                    return Color.FromRgb(237, 204, 98);
                case "512":
                    return Color.FromRgb(237, 200, 80);
                case "1024":
                    return Color.FromRgb(237, 197, 63);
                case "2048":
                    return Color.FromRgb(237, 194, 45);
                default:
                    return Color.FromRgb(205, 193, 181);
            }
        }


        void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            gen = true;
            isstart = true;
            StartBut.IsEnabled = false;
            RandomDigit();
        }


        void WinKeyDown(object sender, KeyEventArgs e)
        {
            if (isstart)
            {
                switch (e.Key)
                {
                    case Key.Up:
                        for (int i = 0; i < board.GetLength(1); i++)
                        {
                            for (int j = 1; j < board.GetLength(0); j++)
                            {
                                if (board[j, i] != 0)
                                {
                                    int temp = j;
                                    while (temp > 0 && board[temp - 1, i] == 0)
                                    {
                                        board[temp - 1, i] = board[temp, i];
                                        button[temp - 1, i].Content = button[temp, i].Content;
                                        SetColor(button[temp - 1, i]);
                                        board[temp, i] = 0;
                                        button[temp, i].Content = "";
                                        SetColor(button[temp, i]);
                                        temp--;
                                    }
                                    if (temp > 0 && board[temp - 1, i] == board[temp, i]
                                        && board[temp, i] != 0)
                                    {
                                        board[temp - 1, i] *= 2;
                                        button[temp - 1, i].Content = board[temp - 1, i].ToString();
                                        SetColor(button[temp - 1, i]);
                                        board[temp, i] = 0;
                                        button[temp, i].Content = "";
                                        SetColor(button[temp, i]);
                                        SetScore(board[temp - 1, i]);
                                    }
                                }
                            }
                        }
                        Set();
                        CheckLose();
                        CheckWin();
                        RandomDigit();
                        break;
                    case Key.Down:
                        for (int i = 0; i < board.GetLength(1); i++)
                        {
                            for (int j = board.GetLength(0) - 2; j >= 0; j--)
                            {
                                if (board[j, i] != 0)
                                {
                                    int temp = j;
                                    while (temp < board.GetLength(0) - 1 && board[temp + 1, i] == 0)
                                    {
                                        board[temp + 1, i] = board[temp, i];
                                        button[temp + 1, i].Content = button[temp, i].Content;
                                        SetColor(button[temp + 1, i]);
                                        board[temp, i] = 0;
                                        button[temp, i].Content = "";
                                        SetColor(button[temp, i]);
                                        temp++;
                                    }
                                    if (temp < board.GetLength(0) - 1 && board[temp + 1, i] == board[temp, i] && board[temp, i] != 0)
                                    {
                                        board[temp + 1, i] *= 2;
                                        button[temp + 1, i].Content = board[temp + 1, i].ToString();
                                        SetColor(button[temp + 1, i]);
                                        board[temp, i] = 0;
                                        button[temp, i].Content = "";
                                        SetColor(button[temp, i]);
                                        SetScore(board[temp + 1, i]);
                                    }
                                }
                            }
                        }
                        Set();
                        CheckLose();
                        CheckWin();
                        RandomDigit();
                        break;
                    case Key.Left:
                        for (int i = 0; i < board.GetLength(0); i++)
                        {
                            for (int j = 1; j < board.GetLength(1); j++)
                            {
                                if (board[i, j] != 0)
                                {
                                    int col = j;
                                    while (col > 0 && board[i, col - 1] == 0)
                                    {
                                        board[i, col - 1] = board[i, col];
                                        button[i, col - 1].Content = button[i, col].Content;
                                        SetColor(button[i, col - 1]);
                                        board[i, col] = 0;
                                        button[i, col].Content = "";
                                        SetColor(button[i, col]);
                                        col--;
                                    }
                                    if (col > 0 && board[i, col - 1] == board[i, col])
                                    {
                                        board[i, col - 1] *= 2;
                                        button[i, col - 1].Content = board[i, col - 1].ToString();
                                        SetColor(button[i, col - 1]);
                                        board[i, col] = 0;
                                        button[i, col].Content = "";
                                        SetColor(button[i, col]);
                                        SetScore(board[i, col - 1]);
                                    }
                                }
                            }
                        }
                        Set();
                        CheckLose();
                        CheckWin();
                        RandomDigit();
                        break;
                    case Key.Right:
                        for (int i = 0; i < board.GetLength(0); i++)
                        {
                            for (int j = board.GetLength(1) - 2; j >= 0; j--)
                            {
                                if (board[i, j] != 0)
                                {
                                    int col = j;
                                    while (col < board.GetLength(1) - 1 && board[i, col + 1] == 0)
                                    {
                                        board[i, col + 1] = board[i, col];
                                        button[i, col + 1].Content = button[i, col].Content;
                                        SetColor(button[i, col + 1]);
                                        board[i, col] = 0;
                                        button[i, col].Content = "";
                                        SetColor(button[i, col]);
                                        col++;
                                    }
                                    if (col < board.GetLength(1) - 1 && board[i, col + 1] == board[i, col] && board[i, col + 1] != 0)
                                    {
                                        board[i, col + 1] *= 2;
                                        button[i, col + 1].Content = board[i, col + 1].ToString();
                                        SetColor(button[i, col + 1]);
                                        board[i, col] = 0;
                                        button[i, col].Content = "";
                                        SetColor(button[i, col]);
                                        SetScore(board[i, col + 1]);
                                    }
                                }
                            }
                        }
                        Set();
                        CheckLose();
                        CheckWin();
                        RandomDigit();
                        break;
                }
                e.Handled = true;
            }
        }
    }
}
