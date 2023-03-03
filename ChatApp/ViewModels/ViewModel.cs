﻿using ChatApp.CustomControls;
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

        public ObservableCollection<ListaData> Chats { get; set; }
        
        void LoadChats()
        {
            Chats = new ObservableCollection<ListaData>()
            {
                new ListaData
                {
                    ImieKontakt = "Kinga",
                    ZdjecieKontakt = new Uri("", UriKind.RelativeOrAbsolute),
                    Wiadomosc = "Witaj! Co u Ciebie?",
                    OstCzasWiadomosc = "Wt 13:15",
                    Wybrany = true
                },
                new ListaData
                {
                    ImieKontakt = "Adrian",
                    ZdjecieKontakt = new Uri("", UriKind.RelativeOrAbsolute),
                    Wiadomosc = "Żyjesz tam?",
                    OstCzasWiadomosc = "Pt 20:10"
                },
                new ListaData
                {
                    ImieKontakt = "Ala",
                    ZdjecieKontakt = new Uri("", UriKind.RelativeOrAbsolute),
                    Wiadomosc = "To o której jutro?",
                    OstCzasWiadomosc = "Nd 04:20"
                },
                new ListaData
                {
                    ImieKontakt = "Paweł",
                    ZdjecieKontakt = new Uri("", UriKind.RelativeOrAbsolute),
                    Wiadomosc = "Weź się do pracy",
                    OstCzasWiadomosc = "Pon 18:18"
                },
            };
            OnPropertyChanged();
        }
        public ViewModel()
        {
            LoadStatus();
            LoadChats();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
