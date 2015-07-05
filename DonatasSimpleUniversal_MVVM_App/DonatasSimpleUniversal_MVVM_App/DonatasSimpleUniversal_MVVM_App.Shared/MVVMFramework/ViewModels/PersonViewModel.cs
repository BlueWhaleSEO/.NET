using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using DonatasSimpleUniversal_MVVM_App.MVVMFramework.Models;
using DonatasSimpleUniversal_MVVM_App.MVVMFramework.MVVMHelpers;
using DonatasSimpleUniversal_MVVM_App.Services;
using Windows.Data.Json;

namespace DonatasSimpleUniversal_MVVM_App.MVVMFramework.ViewModels
{
    public class PersonViewModel : ObservableObject
    {
        // Members
        Person _Person;

        // Constructs the default instance of a PersonViewModel
        public PersonViewModel()
        {
            _Person = new Person();
        }

        // Properties
        public Person Person
        {
            get
            {
                return _Person;
            }
            set
            {
                _Person = value;
            }
        }

        public string Name
        {
            get 
            { 
                return Person.Name; 
            }
            set
            {
                if (Person.Name != value)
                {
                    Person.Name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        public string Gender
        {
            get
            {
                return Person.Gender;
            }
            set
            {
                if (Person.Gender != value)
                {
                    Person.Gender = value;
                    RaisePropertyChanged("Gender");
                }
            }
        }

        // Commands
        void UpdateGenderExecute()
        {
            MashapeAPI mashapeAPI = new MashapeAPI();
            string json = mashapeAPI.getGenderInformation(Name).Result;

            JsonObject jsonObject = JsonObject.Parse(json);
            Gender = jsonObject.GetNamedString("gender");
        }

        bool CanUpdateGenderExecute()
        {
            return true;
        }

        public ICommand UpdateGender { get { return new RelayCommand(UpdateGenderExecute, CanUpdateGenderExecute); } }
    }
}
