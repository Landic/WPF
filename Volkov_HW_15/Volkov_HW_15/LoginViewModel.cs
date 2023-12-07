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
    public class LoginViewModel : ViewModelBase
    {
        private User user;
        private Commands? signIn, openReg;
        private WindowService windowService;

        public LoginViewModel()
        {
            user = User.Example;
            windowService = new WindowService();
        }

        public string Login
        {
            get { return user.Login; }
            set
            {
                user.Login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public string Password
        {
            get { return user.Password; }
            set
            {
                user.Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand OpenRegCommand
        {
            get
            {
                if (openReg == null) openReg = new Commands(exec => Open(), can => CanOpen());
                return openReg;
            }
        }

        private bool CanOpen()
        {
            return true;
        }

        private void Open()
        {
            windowService.OpenRegistrationWindow();
        }

        public ICommand SignInCommand
        {
            get
            {
                if (signIn == null) signIn = new Commands(exec => Sign(), can => CanSignIn());
                return signIn;
            }
        }

        private bool CanSignIn()
        {
            return Login != null;
        }

        private void Sign()
        {
            try
            {
                if (File.Exists("user.json"))
                {
                    string data = File.ReadAllText("user.json");
                    List<dynamic>? users = JsonConvert.DeserializeObject<List<dynamic>>(data);
                    var userAuthenticate = users?.FirstOrDefault(u => u.Login == Login && u.Password == Password);
                    if (userAuthenticate != null)
                    {
                        windowService.OpenGalleryWindow();
                    }
                    else
                    {
                        MessageBox.Show("Неправильно введен логин или пароль!", "Gallery",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

                if (user != null)
                {
                    windowService.CloseWindow(Application.Current.Windows[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gallery");
            }
        }
    }
}
