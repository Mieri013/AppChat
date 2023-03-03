using System;

namespace ChatApp.Models
{
    public class ListaData
    {
        public string ImieKontakt { get; set; }
        public Uri ZdjecieKontakt { get; set; }
        public string Wiadomosc { get; set; }
        public string OstCzasWiadomosc { get; set; }

        public bool Wybrany { get; set; }
    }
}