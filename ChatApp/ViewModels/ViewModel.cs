using ChatApp.CustomControls;
using ChatApp.Models;
using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.ViewModels
{
    public class ViewModel: INotifyPropertyChanged
    {

       public ObservableCollection<StatusDataModel> statusCollection { get; set; }

        void LoadStatus()
        {
            //Zbindowanie kolekcji do kontrolek 
            statusCollection = new ObservableCollection<StatusDataModel>()
            {
                new StatusDataModel
                {
                    //pierwszy status ma być pusty, aby użytkownik mógł dodać własny status
                    StatusDodania = true
                },

                new StatusDataModel
                {
                    ImieKontakt = "Adrian",

                    //Dodać zdjęcie
                    //ZdjecieKontakt = new Uri("", UriKind.RelativeOrAbsolute),

                    //StatusZdjecia = new Uri("" UriKind.RelativeOrAbsolute),

                    StatusDodania = false
                },

                new StatusDataModel
                {
                    ImieKontakt = "Ala",

                    //Dodać zdjęcie
                    //ZdjecieKontakt = new Uri("", UriKind.RelativeOrAbsolute),

                    //StatusZdjecia = new Uri("" UriKind.RelativeOrAbsolute),

                    StatusDodania = false
                },

                new StatusDataModel
                {
                    ImieKontakt = "Natalia",

                    //Dodać zdjęcie
                    //ZdjecieKontakt = new Uri("", UriKind.RelativeOrAbsolute),

                    //StatusZdjecia = new Uri("" UriKind.RelativeOrAbsolute),

                    StatusDodania = false
                },

                new StatusDataModel
                {
                    ImieKontakt = "Paweł",

                    //Dodać zdjęcie
                    //ZdjecieKontakt = new Uri("", UriKind.RelativeOrAbsolute),

                    //StatusZdjecia = new Uri("" UriKind.RelativeOrAbsolute),

                    StatusDodania = false
                },
            };
            OnPropertyChanged("statusCollection");
        }
        public ViewModel()
        {
            LoadStatus();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
