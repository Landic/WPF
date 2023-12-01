using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Newtonsoft.Json;

namespace Volkov_HW_13
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<string> ComboPersons { get; set; }
        public ObservableCollection<PersonViewModel> ListPersons { get; set; }
        private ObservableCollection<PersonViewModel> temp_list = new ObservableCollection<PersonViewModel>();
        private PersonViewModel current;
        private int combo_index;
        private Commands? add, select, clear, remove, save;
        public MainViewModel()
        {
            ComboPersons = new ObservableCollection<string>();
            ListPersons = new ObservableCollection<PersonViewModel>();
            Current = new PersonViewModel();
            LoadFromFile();
        }
        public PersonViewModel Current
        {
            get { return current; }
            set
            {
                current = value;
                OnPropertyChanged(nameof(Current));
            }
        }
        public int ComboIndex
        {
            get { return combo_index; }
            set
            {
                if (combo_index != value)
                {
                    combo_index = value;
                    OnPropertyChanged(nameof(ComboIndex));
                }
            }
        }
        private void LoadFromFile()
        {
            try
            {
                if (File.Exists("Resume.json") && File.Exists("List.json"))
                {
                    string json = File.ReadAllText("Resume.json");
                    temp_list = JsonConvert.DeserializeObject<ObservableCollection<PersonViewModel>>(json);
                    json = File.ReadAllText("List.json");
                    ComboPersons = JsonConvert.DeserializeObject<ObservableCollection<string>>(json);
                }
            }
            catch (Exception ex) 
            { MessageBox.Show(ex.Message); 
            }
        }
        public ICommand AddCommand
        {
            get
            {
                if (add == null) add = new Commands(execute => Add(), can => CanAdd());
                return add;
            }
        }
        private void Add()
        {
            ComboPersons.Add(Current.ComboText());
            temp_list.Add(Current.Clone());
            Current.Fullname = Current.Age = Current.Family = Current.Address = Current.Email = string.Empty;
            Current.Check1 = Current.Check2 = Current.Check3 = false;
        }
        private bool CanAdd() { return !current.IsEmpty(); }
        public ICommand SelectCommand
        {
            get
            {
                if (select == null) select = new Commands(execute => Select(), can => CanSelect());
                return select;
            }
        }
        private void Select()
        {
            ListPersons.Clear();
            ListPersons.Add(temp_list[ComboIndex]);
        }
        private bool CanSelect() { return ComboPersons.Count > 0; }
        public ICommand ClearCommand
        {
            get
            {
                if (clear == null) clear = new Commands(execute => Clear(), can => CanClear());
                return clear;
            }
        }
        private void Clear() => ListPersons.Clear();
        private bool CanClear() { return ComboPersons.Count > 0 && ListPersons.Count > 0; }
        public ICommand RemoveCommand
        {
            get
            {
                if (remove == null) remove = new Commands(execute => Remove(), can => CanRemove());
                return remove;
            }
        }
        private void Remove()
        {
            MessageBoxResult res = MessageBox.Show("Вы точно хотите удалить резюме?","Resume", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                ComboPersons.RemoveAt(ComboIndex);
                ListPersons.Clear();
            }
        }
        private bool CanRemove() { return ComboPersons.Count > 0; }
        public ICommand SaveCommand
        {
            get
            {
                if (save == null) save = new Commands(execute => SaveToFile(), can => CanSave());
                return save;
            }
        }
        private void SaveToFile()
        {
            try
            {
                string json = JsonConvert.SerializeObject(temp_list, Formatting.Indented);
                File.WriteAllText("Resume.json", json);
                json = JsonConvert.SerializeObject(ComboPersons, Formatting.Indented);
                File.WriteAllText("List.json", json);
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message); 
            }
        }
        private bool CanSave() { return temp_list.Count > 0; }
    }
    public class PersonViewModel : BaseViewModel
    {
        private ResumeModel model;
        private bool check1, check2, check3;
        public PersonViewModel() => model = new ResumeModel();
        public bool Check1
        {
            get { return check1; }
            set
            {
                check1 = value;
                OnPropertyChanged(nameof(Check1));
            }
        }
        public bool Check2
        {
            get { return check2; }
            set
            {
                check2 = value;
                OnPropertyChanged(nameof(Check2));
            }
        }
        public bool Check3
        {
            get { return check3; }
            set
            {
                check3 = value;
                OnPropertyChanged(nameof(Check3));
            }
        }
        public ResumeModel Model
        {
            get { return model; }
            set
            {
                model = value;
                OnPropertyChanged(nameof(Model));
            }
        }
        public string Fullname
        {
            get { return model.Fullname; }
            set
            {
                model.Fullname = value;
                OnPropertyChanged(nameof(Fullname));
            }
        }
        public string Age
        {
            get { return model.Age; }
            set
            {
                model.Age = value;
                OnPropertyChanged(nameof(Age));
            }
        }
        public string Family
        {
            get { return model.Family; }
            set
            {
                model.Family = value;
                OnPropertyChanged(nameof(Family));
            }
        }
        public string Address
        {
            get { return model.Address; }
            set
            {
                model.Address = value;
                OnPropertyChanged(nameof(Address));
            }
        }
        public string Email
        {
            get { return model.Email; }
            set
            {
                model.Email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string IsCPlusPlus
        {
            get { return model.IsCPlusPlus; }
            set
            {
                if (Check1) model.IsCPlusPlus = "Да";
                else model.IsCPlusPlus = "Нет";
                OnPropertyChanged(nameof(IsCPlusPlus));
            }
        }
        public string IsLanguage
        {
            get { return model.IsLanguage; }
            set
            {
                if (Check2) model.IsLanguage = "Да";
                else model.IsLanguage = "Нет";
                OnPropertyChanged(nameof(IsLanguage));
            }
        }
        public string IsOOP
        {
            get { return model.IsOOP; }
            set
            {
                if (Check3) model.IsOOP = "Да";
                else model.IsOOP = "Нет";
                OnPropertyChanged(nameof(IsOOP));
            }
        }
        public PersonViewModel Clone()
        {
            return new PersonViewModel
            {
                Fullname = Fullname,
                Age = Age,
                Family = Family,
                Address = Address,
                Email = Email,
                IsCPlusPlus = IsCPlusPlus,
                IsLanguage = IsLanguage,
                IsOOP = IsOOP
            };
        }
        public string ComboText() { return Fullname + ", " + Age; }
        public bool IsEmpty()
        {
            return (string.IsNullOrEmpty(Fullname) || string.IsNullOrEmpty(Age) || string.IsNullOrEmpty(Family)
                || string.IsNullOrEmpty(Address) || string.IsNullOrEmpty(Email));
        }
    }
}
