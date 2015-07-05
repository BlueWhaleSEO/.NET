using System;
using System.ComponentModel;
using System.Text;

namespace DonatasSimpleUniversal_MVVM_App.MVVMFramework.Models
{
    public class Person
    {
        // Members 
        string _Name;
        string _Gender;

        // Properties
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
    }
}
