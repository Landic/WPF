using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Newtonsoft.Json;
using System.IO;
using Formatting = Newtonsoft.Json.Formatting;

namespace Volkov_HW_15
{
    public class RegistrationViewModel : ViewModelBase
    {
        private User users;
        private string? repeatPassword;
        private Commands? registration, openSignIn;

        private WindowService windowService;

        public RegistrationViewModel()
        {
            users = User.Example;
            windowService = new WindowService();
        }

        public string? Login
        {
            get { return users.Login; }
            set
            {
                users.Login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public string? Password
        {
            get { return users.Password; }
            set
            {
                users.Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string? RepeatPassword
        {
            get { return repeatPassword; }
            set
            {
                repeatPassword = value;
                OnPropertyChanged(nameof(RepeatPassword));
            }
        }

        public ICommand OpenSignIn
        {
            get
            {
                if (openSignIn == null) openSignIn = new Commands(null, can => CanOpen());
                return openSignIn;
            }
        }

        private bool CanOpen()
        {
            return true;
        }

        public ICommand RegistrationCommand
        {
            get
            {
                if (registration == null) registration = new Commands(exec => Reg(), can => CanReg());
                return registration;
            }
        }

        private bool CanReg()
        {
            return Login != null && Password != string.Empty && Password == RepeatPassword;
        }

        private void Reg()
        {
            var data = new { Login, Password };
            try
            {
                if (File.Exists("user.json"))
                {
                    string currentData = File.ReadAllText("user.json");
                    List<dynamic>? currentUsers = JsonConvert.DeserializeObject<List<dynamic>>(currentData);
                    if (currentUsers.Any(u => u.Login == Login))
                    {
                        MessageBox.Show("Такой пользователь уже существует", "Gallery",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    currentUsers.Add(data);
                    string newData = JsonConvert.SerializeObject(currentUsers, Formatting.Indented);
                    File.WriteAllText("user.json", newData);
                }
                else
                {
                    List<dynamic> users = new List<dynamic> { data };
                    string jsonData = JsonConvert.SerializeObject(users, Formatting.Indented);
                    File.WriteAllText("user.json", jsonData);
                }

                windowService.CloseWindow(Application.Current.Windows[1]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gallery");
            }
        }
    }
}
