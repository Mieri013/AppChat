using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    public class ChatKonwersacja
    {
        public string ImieKontakt { get; set; }
        public string OtrzymanaWiadomosc { get; set; }
        public string MsgReceivedOn { get; set; }
        public string WyslanaWiadomosc { get; set; }
        public string MsgSentOn { get; set; }
        public bool JestOtrzymana { get; set; }
        public bool WiadZawieraOdp { get; set; }
    }
}
