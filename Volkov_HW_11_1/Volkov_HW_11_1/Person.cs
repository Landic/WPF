using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Volkov_HW_11_1
{
    public class Person : DependencyObject
    {
        private static readonly DependencyProperty FullNameProperty;
        private static readonly DependencyProperty AddressProperty;
        private static readonly DependencyProperty PhoneProperty;

        static Person()
        {
            FullNameProperty = DependencyProperty.Register("FullName", typeof(string), typeof(Person));
            AddressProperty = DependencyProperty.Register("Address", typeof(string), typeof(Person));
            PhoneProperty = DependencyProperty.Register("Phone", typeof(string), typeof(Person));
        }

        public string FullName
        {
            get { return (string)GetValue(FullNameProperty); }
            set { SetValue(FullNameProperty, value); }
        }

        public string Address
        {
            get { return (string)GetValue(AddressProperty); }
            set { SetValue(AddressProperty, value); }
        }

        public string Phone
        {
            get { return (string)GetValue(PhoneProperty); }
            set { SetValue(PhoneProperty, value); }
        }
    }
}
