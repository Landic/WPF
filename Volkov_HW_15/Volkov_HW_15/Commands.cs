using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace Volkov_HW_15
{
    public class Commands : ICommand
    {
        Action<object> execute;
        Predicate<object> can_execute;
        public Commands(Action<object> execute, Predicate<object> can_execute)
        {
            if (execute == null) throw new ArgumentNullException("execute");
            this.execute = execute;
            this.can_execute = can_execute;
        }
        public bool CanExecute(object param)
        {
            if (can_execute != null) return can_execute(param);
            return true;
        }
        public void Execute(object param) => execute(param);
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }

    public class WindowService
    {
        public void CloseWindow(Window window)
        {
            if (window == null)
                throw new ArgumentNullException(nameof(window));

            window.Close();
        }
        public void OpenRegistrationWindow()
        {
            CreateAccount createAccountWindow = new CreateAccount();
            createAccountWindow.Show();
        }

        public void OpenGalleryWindow()
        {
            MainWindow galleryWindow = new MainWindow();
            galleryWindow.Show();
        }
    }
    public class KeyValue
    {
        public string Key { get; set; }
        public double Value { get; set; }
        public KeyValue() { }
        public KeyValue(string key, double value)
        {
            Key = key;
            Value = value;
        }
    }
}
