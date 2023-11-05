using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.IO;
using System.Text.Json;
using System.Windows.Controls;
using System.Runtime.Versioning;
using Newtonsoft.Json;

namespace Volkov_HW_11_1
{
    public class MainWindowViewModel : DependencyObject
    {
        private static readonly DependencyProperty PersonsProperty;
        private static readonly DependencyProperty SelectedPersonProperty;
        private static readonly DependencyProperty InformationFullNameProperty;
        private static readonly DependencyProperty InformationAddressProperty;
        private static readonly DependencyProperty InformationPhoneProperty;

        static MainWindowViewModel()
        {
        PersonsProperty = DependencyProperty.Register("Persons", typeof(ObservableCollection<Person>), typeof(MainWindowViewModel));
        SelectedPersonProperty = DependencyProperty.Register("SelectedPerson", typeof(Person), typeof(MainWindowViewModel));
        InformationFullNameProperty = DependencyProperty.Register("InformationFullName", typeof(string), typeof(MainWindowViewModel));
        InformationAddressProperty = DependencyProperty.Register("InformationAddress", typeof(string), typeof(MainWindowViewModel));
        InformationPhoneProperty = DependencyProperty.Register("InformationPhone", typeof(string), typeof(MainWindowViewModel));
        }

        public ObservableCollection<Person> Persons
        {
            get { return (ObservableCollection<Person>)GetValue(PersonsProperty); }
            set { SetValue(PersonsProperty, value); }
        }

        public Person SelectedPerson
        {
            get { return (Person)GetValue(SelectedPersonProperty); }
            set { SetValue(SelectedPersonProperty, value); }
        }

        public string InformationFullName
        {
            get { return (string)GetValue(InformationFullNameProperty); }
            set { SetValue(InformationFullNameProperty, value); }
        }

        public string InformationAddress
        {
            get { return (string)GetValue(InformationAddressProperty); }
            set { SetValue(InformationAddressProperty, value); }
        }

        public string InformationPhone
        {
            get { return (string)GetValue(InformationPhoneProperty); }
            set { SetValue(InformationPhoneProperty, value); }
        }

        public ICommand AddCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand SaveJsonCommand { get; private set; }
        public ICommand LoadJsonCommand { get; private set; }

        public MainWindowViewModel()
        {
            Persons = new ObservableCollection<Person>();
            AddCommand = new DelegateCommand(param => Add(),param => CanAdd());
            EditCommand = new DelegateCommand(param => Edit(), param => CanEdit());
            DeleteCommand = new DelegateCommand(param => Delete(), param => CanDelete());
            SaveJsonCommand = new DelegateCommand(param => SaveJson(), param => CanSaveJson());
            LoadJsonCommand = new DelegateCommand(param => LoadJson(), null);
        }

        private void Add()
        {
            Persons.Add(new Person { FullName = InformationFullName, Address = InformationAddress, Phone = InformationPhone });
            InformationFullName = string.Empty;
            InformationAddress = string.Empty;
            InformationPhone = string.Empty;
        }

        private bool CanAdd()
        {
            return !string.IsNullOrEmpty(InformationFullName) && !string.IsNullOrEmpty(InformationAddress) && !string.IsNullOrEmpty(InformationPhone);
        }

        private void Edit()
        {
            if (SelectedPerson != null)
            {
                SelectedPerson.FullName = InformationFullName;
                SelectedPerson.Address = InformationAddress;
                SelectedPerson.Phone = InformationPhone;
                InformationFullName = string.Empty;
                InformationAddress = string.Empty;
                InformationPhone = string.Empty;
            }
        }

        private bool CanEdit()
        {
            return SelectedPerson != null && CanAdd();
        }

        private void Delete()
        {
            if (SelectedPerson != null)
            {
                Persons.Remove(SelectedPerson);
                SelectedPerson = null;
            }
        }

        private bool CanDelete()
        {
            return SelectedPerson != null;
        }

        private void SaveJson()
        {
            try
            {
                string json = JsonConvert.SerializeObject(Persons, Formatting.Indented);
                File.WriteAllText("PersonInformation.json", json);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool CanSaveJson()
        {
            return Persons.Count > 0;
        }

        private void LoadJson()
        {
            try
            {
                if (File.Exists("PersonInformation.json"))
                {
                    string json = File.ReadAllText("PersonInformation.json");
                    ObservableCollection<Person> load = JsonConvert.DeserializeObject<ObservableCollection<Person>>(json);
                    Persons.Clear();
                    foreach (var i in load)
                    {
                        Persons.Add(i);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
