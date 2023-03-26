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
using System.Data.SqlClient;

namespace ChatApp.ViewModels
{
    public class ViewModel: INotifyPropertyChanged
    {
       public string ImieKontakt { get; set; }
       public Uri ZdjecieKontakt { get; set; } 
       public string OstWidziany { get; set; }
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
                    ZdjecieKontakt = new Uri("/assets/boy.png", UriKind.RelativeOrAbsolute),

                    StatusZdjecia = new Uri("/assets/adi.png", UriKind.RelativeOrAbsolute),

                    StatusDodania = false
                },

                new StatusDataModel
                {
                    ImieKontakt = "Ala",

                    //Dodać zdjęcie
                    ZdjecieKontakt = new Uri("/assets/girl.png", UriKind.RelativeOrAbsolute),

                    StatusZdjecia = new Uri("/assets/ala.png", UriKind.RelativeOrAbsolute),

                    StatusDodania = false
                },

                new StatusDataModel
                {
                    ImieKontakt = "Natalia",

                    //Dodać zdjęcie
                    ZdjecieKontakt = new Uri("/assets/girl.png", UriKind.RelativeOrAbsolute),

                    StatusZdjecia = new Uri("/assets/nat.png", UriKind.RelativeOrAbsolute),

                    StatusDodania = false
                },

                new StatusDataModel
                {
                    ImieKontakt = "Paweł",

                    //Dodać zdjęcie
                    ZdjecieKontakt = new Uri("/assets/boy.png", UriKind.RelativeOrAbsolute),

                    StatusZdjecia = new Uri("/assets/Pawcio.png", UriKind.RelativeOrAbsolute),

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
                    ImieKontakt = "Natalia",
                    ZdjecieKontakt = new Uri("/assets/nat.png", UriKind.RelativeOrAbsolute),
                    Wiadomosc = "Witaj! Co u Ciebie?",
                    OstCzasWiadomosc = "Wt 13:15",
                    Wybrany = true
                },
                new ListaData
                {
                    ImieKontakt = "Adrian",
                    ZdjecieKontakt = new Uri("/assets/adi.png", UriKind.RelativeOrAbsolute),
                    Wiadomosc = "Żyjesz tam?",
                    OstCzasWiadomosc = "Pt 20:10"
                },
                new ListaData
                {
                    ImieKontakt = "Ala",
                    ZdjecieKontakt = new Uri("/assets/ala.png", UriKind.RelativeOrAbsolute),
                    Wiadomosc = "To o której jutro?",
                    OstCzasWiadomosc = "Nd 04:20"
                },
                new ListaData
                {
                    ImieKontakt = "Paweł",
                    ZdjecieKontakt = new Uri("/assets/Pawcio.png", UriKind.RelativeOrAbsolute),
                    Wiadomosc = "Weź się do pracy",
                    OstCzasWiadomosc = "Pon 18:18"
                },
            };
            OnPropertyChanged();
        }

        public ObservableCollection<ChatKonwersacja> Conversations;
        void LoadChatConversation()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
            using(SqlCommand com = new SqlCommand("select * from conversations where ImieKontakt=Natalia", connection))
            {
                using(SqlDataReader reader = com.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        //format daty Jun 15, 01:15 PM
                        string MsgReceivedOn = !string.IsNullOrEmpty(reader["MsgReceivedOn"].ToString()) ? 
                            Convert.ToDateTime(reader["MsgReceivedOn"].ToString()).ToString("MMM dd, hh:mm tt") :"";
                        string MsgSentOn = !string.IsNullOrEmpty(reader["MsgSentOn"].ToString()) ?
                            Convert.ToDateTime(reader["MsgSentOn"].ToString()).ToString("MMM dd, hh:mm tt") : "";

                        var conversation = new ChatKonwersacja()
                        {
                            ImieKontakt = reader["ContactName"].ToString(),
                            OtrzymanaWiadomosc = reader["ReceivedMsgs"].ToString(),
                            MsgReceivedOn = reader["MsgReceivedOn"].ToString(),
                            WyslanaWiadomosc = reader["SentMsgs"].ToString(),
                            MsgSentOn = reader["MsgSentOn"].ToString(),
                            JestOtrzymana = string.IsNullOrEmpty(reader["ReceivedMsgs"].ToString()) ? false : true

                        };
                        Conversations.Add(conversation);
                    }
                }
            }
        }

        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=\Database\Database1.mdf;Integrated Security=True");
        public ViewModel()
        {
            LoadStatus();
            LoadChats();
            LoadChatConversation();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
