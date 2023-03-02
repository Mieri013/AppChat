using ChatApp.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    public class StatusDataModel
    {
        public string ImieKontakt { get; set; }

        public Uri ZdjecieKontakt { get; set; }

        //trzeba dokończyć
        //public string StatusWiadomosci { get; set; }

        public Uri StatusZdjecia { get; set; }

        ///Jeśli chcemy dodać nasz status

        public bool StatusDodania  { get; set; }
    }
}
