using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Text.Json;
using System.IO;

namespace Volkov_HW_11_1
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

        private void AddCommand(object sender, ExecutedRoutedEventArgs e)
        {
            PersonsInformation persinf = Resources["person"] as PersonsInformation;
            Person pers = new Person();
            pers.FullName = persinf.InformationFullName;
            pers.Address = persinf.InformationAddress;
            pers.Phone = persinf.InformationPhone;
            persinf.InformationPhone = string.Empty;
            persinf.InformationFullName = string.Empty;
            persinf.InformationAddress = string.Empty;
            persinf.Persons.Add(pers);
        }

        private void AddCommandExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            PersonsInformation persinf = Resources["person"] as PersonsInformation;
            if (string.IsNullOrEmpty(persinf.InformationFullName) == false && string.IsNullOrEmpty(persinf.InformationAddress) == false && string.IsNullOrEmpty(persinf.InformationPhone) == false)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void DelCommand(object sender, ExecutedRoutedEventArgs e)
        {
            PersonsInformation persinf = Resources["person"] as PersonsInformation;
            persinf.Persons.RemoveAt(persinf.Index_selected_listbox);
            persinf.InformationPhone = string.Empty;
            persinf.InformationFullName = string.Empty;
            persinf.InformationAddress = string.Empty;
        }

        private void DelCommandExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            PersonsInformation persinf = Resources["person"] as PersonsInformation;
            if (persinf.Index_selected_listbox == -1)
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute= true;
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                PersonsInformation persinf = Resources["person"] as PersonsInformation;
                if(persinf.Index_selected_listbox == -1)
                {
                    return;
                }
                Person pers = persinf.Persons[persinf.Index_selected_listbox];
                persinf.InformationPhone = pers.Phone;
                persinf.InformationAddress = pers.Address;
                persinf.InformationFullName = pers.FullName;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void EditCommand(object sender, ExecutedRoutedEventArgs e)
        {
            PersonsInformation persinf = Resources["person"] as PersonsInformation;
            Person pers = new Person();
            pers.FullName = persinf.InformationFullName;
            pers.Address = persinf.InformationAddress;
            pers.Phone = persinf.InformationPhone;
            persinf.InformationPhone = string.Empty;
            persinf.InformationFullName = string.Empty;
            persinf.InformationAddress = string.Empty;
            persinf.Persons.Insert(persinf.Index_selected_listbox, pers);
            persinf.Persons.RemoveAt(persinf.Index_selected_listbox);
        }

        private void EditCommandExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            PersonsInformation persinf = Resources["person"] as PersonsInformation;
            if (persinf.Index_selected_listbox == -1)
            {
                
                e.CanExecute = false;
            }
            else
            {
                if (string.IsNullOrEmpty(persinf.InformationFullName) == false && string.IsNullOrEmpty(persinf.InformationAddress) == false && string.IsNullOrEmpty(persinf.InformationPhone) == false)
                    e.CanExecute = true;
            }
        }

        private void SaveJsonCommand(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                PersonsInformation persinf = Resources["person"] as PersonsInformation;
                using (StreamWriter wr = new StreamWriter("PersonInformation.json"))
                {
                    wr.WriteLine(JsonSerializer.Serialize(persinf.Persons));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveJsonCommandExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            PersonsInformation persinf = Resources["person"] as PersonsInformation;
            if(persinf.Persons.Count != 0)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void LoadJsonCommand(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                PersonsInformation persinf = Resources["person"] as PersonsInformation;
                using (StreamReader read = new StreamReader("PersonInformation.json"))
                {
                    persinf.Persons = JsonSerializer.Deserialize<ObservableCollection<Person>>(read.ReadToEnd());
                    Dispatcher.Invoke(() => Listbox1.ItemsSource = persinf.Persons);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
