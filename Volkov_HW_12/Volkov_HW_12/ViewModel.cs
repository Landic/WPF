using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Volkov_HW_12
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class ViewModel : ViewModelBase
    {
        public ObservableCollection<ColorViewModel> color_list { get; set; }
        public int index { get; set; }
        private ColorViewModel color;
        private Commands add, remove;
        public ViewModel()
        {
            color_list = new ObservableCollection<ColorViewModel>();
            CurrentColor = new ColorViewModel();
        }
        public ColorViewModel CurrentColor
        {
            get { return color; }
            set
            {
                color = value;
                OnPropertyChanged(nameof(CurrentColor));
            }
        }
        public ICommand AddCommand
        {
            get
            {
                if (add == null) 
                    add = new Commands(execute => Add(), can_exetue => CanAdd());
                return add;
            }
        }
        private void Add()
        {
            color_list.Add(CurrentColor.Clone());
        }

        private bool CanAdd()
        {
            if (color_list.Count == 0) 
                return true;
            return !color_list.Any(x => x.Alpha == CurrentColor.Alpha && x.Red == CurrentColor.Red &&
            x.Green == CurrentColor.Green && x.Blue == CurrentColor.Blue);
        }
        public ICommand RemoveCommand
        {
            get
            {
                if (remove == null) 
                    remove = new Commands(execute => Remove(), can_execute => CanRemove());
                return remove;
            }
        }
        private void Remove()
        {
            color_list.Remove(color_list[index]);
        }
        private bool CanRemove() 
        { 
            return index != -1; 
        }
    }

    public class ColorViewModel : ViewModelBase
    {
        private Color color;
        private bool check1, check2, check3, check4;
        private byte alpha, red, green, blue;
        public bool Check1
        {
            get 
            { 
                return check1; 
            }
            set
            {
                check1 = value;
                OnPropertyChanged(nameof(Check1));
            }
        }
        public bool Check2
        {
            get 
            { 
                return check2; 
            }
            set
            {
                check2 = value;
                OnPropertyChanged(nameof(Check2));
            }
        }
        public bool Check3
        {
            get 
            { 
                return check3; 
            }
            set
            {
                check3 = value;
                OnPropertyChanged(nameof(Check3));
            }
        }
        public bool Check4
        {
            get 
            { 
                return check4; 
            }
            set
            {
                check4 = value;
                OnPropertyChanged(nameof(Check4));
            }
        }
        public byte Alpha
        {
            get 
            { 
                return alpha; 
            }
            set
            {
                if (alpha != value)
                {
                    alpha = value;
                    OnPropertyChanged(nameof(Alpha));
                    SetColor();
                }
            }
        }
        public byte Red
        {
            get 
            { 
                return red; 
            }
            set
            {
                if (red != value)
                {
                    red = value;
                    OnPropertyChanged(nameof(Red));
                    SetColor();
                }
            }
        }
        public byte Green
        {
            get 
            { 
                return green; 
            }
            set
            {
                if (green != value)
                {
                    green = value;
                    OnPropertyChanged(nameof(Green));
                    SetColor();
                }
            }
        }
        public byte Blue
        {
            get 
            { 
                return blue; 
            }
            set
            {
                if (blue != value)
                {
                    blue = value;
                    OnPropertyChanged(nameof(Blue));
                    SetColor();
                }
            }
        }
        public string Name
        {
            get 
            {
                return color.name; 
            }
            set
            {
                color.name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        private void SetColor()
        {
            if (color == null) color = new Color(" ");
            Name = System.Windows.Media.Color.FromArgb(Alpha, Red, Green, Blue).ToString();
        }
        public ColorViewModel Clone()
        {
            return new ColorViewModel { Alpha = Alpha, Red = Red, Green = Green, Blue = Blue };
        }
    }
}
