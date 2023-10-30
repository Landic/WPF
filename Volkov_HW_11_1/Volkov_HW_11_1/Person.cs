using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volkov_HW_11_1
{
    public class Person : INotifyPropertyChanged
    {
        private string fullname;
        private string address;
        private string phone;

        public string FullName
        {
            get
            {
                return fullname;
            }
            set
            {
                fullname = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(FullName)));
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Address)));
            }
        }
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Phone)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
    }

    public class PersonsInformation : INotifyPropertyChanged
    {
        public ObservableCollection<Person> Persons { get; set; } = new ObservableCollection<Person>();

        private int index_selected_listbox = -1;

        public int Index_selected_listbox
        {
            get { return index_selected_listbox; }
            set
            {
                index_selected_listbox = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Index_selected_listbox)));
            }
        }

        private string fullname;
        private string address;
        private string phone;

        public string InformationFullName
        {
            get
            {
                return fullname;
            }
            set
            {
                fullname = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(InformationFullName)));
            }
        }
        public string InformationAddress
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(InformationAddress)));
            }
        }
        public string InformationPhone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(InformationPhone)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
    }
}
