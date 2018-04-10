using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace HomeTask_C_sharp_55_ADO_Net
{
    public class ServersList : INotifyPropertyChanged
    {
        #region
        public ICommand continuaBtn { get; set; }
        public ICommand okconnection { get; set; }
        public ICommand testconnectionbtn { get; set; }
        public ICommand brouwse { get; set; }
       
        private ServerName currentElement;

        public ServerName CurrentServerName
        {
            get { return currentElement; }
            set
            {
                currentElement = value;
                
                OnPropertyChanged("CurrentServerName");
            }
        }


        ObservableCollection<ServerName> servers = new ObservableCollection<ServerName>();

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<ServerName> Servers
        {
            get { return servers; }
            set
            {
                servers = value;
            }
        }



        public ServersList()
        {

            servers.Add(new ServerName("Microsoft MS SQL Server"));
            continuaBtn = new CommandClass(CanContinueBtn);
            okconnection = new CommandClass(ConnectionStart, CanConnectionStart);
            testconnectionbtn = new CommandClass(TestConnection,CanTestConnection);
            brouwse = new CommandClass(BrowsBtn, CanBrowsBtn);
            
        }

        

        private void BrowsBtn(object arg)
        {
            OpenFileDialog opendialog = new OpenFileDialog();
            opendialog.ShowDialog();
        }

        private bool CanBrowsBtn(object arg)
        {
            if(!ChoiceOrEnterDb)
                return true;
            return false;
        }

        private Brush backgroundTestConnection = Brushes.Gray;

        public Brush BackgroundTestConnection
        {
            get { return backgroundTestConnection; }
            set { backgroundTestConnection = value; OnPropertyChanged("BackgroundTestConnection"); }
        }


        private void TestConnection(object arg)
        {
            using (SqlConnection connection = new SqlConnection(Connection.ConnectionString))
            {
                try
                {
                    connection.Open();

                    if (connection.State.ToString().Equals("Open"))
                        BackgroundTestConnection = Brushes.Green;
                    else if (connection.State.ToString().Equals("Close"))
                        BackgroundTestConnection = Brushes.Red;
                    else
                        BackgroundTestConnection = Brushes.Yellow;

                }

                catch (Exception)
                {
                    BackgroundTestConnection = Brushes.Red;
                    MessageBox.Show("Error");
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        private bool CanTestConnection(object arg)
        {
            return true;
        }

        private static List<string> serversname = new List<string>();

        public static List<string> ServersNameFromDb
        {
            get { return serversname; }
            set { serversname = value;}
        }

        private bool isconnected;

        public bool IsConnected
        {
            get { return isconnected; }
            set { isconnected = value;OnPropertyChanged("IsConnected"); }
        }

        private bool choiceOrEnterDb = true;

        public bool ChoiceOrEnterDb
        {
            get { return choiceOrEnterDb; }
            set { choiceOrEnterDb = value; OnPropertyChanged("ChoiceOrEnterDb"); }
        }

        private void ConnectionStart(object arg)
        {
            using (SqlConnection connection = new SqlConnection(Connection.ConnectionString))
            {
                try
                {
                    connection.Open();

                    MessageBox.Show("Connected");
                }
                catch (Exception)
                {

                    MessageBox.Show("Error");
                }
                finally
                {
                    connection.Close();


                }
            }


        }

        private bool CanConnectionStart(object arg)
        {
            if ((Servername != "" && Servername != null) && (Ischecked))
            {
                Connection.Authentication = SqlAuthenticationMethod.ActiveDirectoryIntegrated;
                
                IsConnected = true;
                return true;
            }
            else if((Servername != "" && Servername != null) && (!Ischecked))
            {
                if (UserName != null && UserName != "" )
                {
                    if(Pas!=null&&Pas != "")
                    {
                        Connection.Password = Pas;
                    }
                    Connection.DataSource = Servername;
                    Connection.UserID = UserName;
                    Connection.Authentication = SqlAuthenticationMethod.NotSpecified;
                   
                    IsConnected = true;
                    return true;
                }
                else
                { IsConnected = false; return false; }
            }
            return false;
            
        }

        private List<string> GetDataBaseName(SqlConnectionStringBuilder connectstring)
        {
            List<string> nameLists = new List<string>();
            using (var Connect = new SqlConnection(connectstring.ConnectionString))
            {
                try
                {
                    Connect.Open();
                    var command = new SqlCommand("select * from sys.database", Connect);
                    var reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        nameLists.Add((string)reader["name"]);
                    }
                    if (nameLists.Count > 0)
                        return nameLists;
                    else return null;
                }
                catch (Exception)
                {

                    MessageBox.Show("Error");
                }
                finally
                {
                    Connect.Close();
                }
            }
            return null;
        }

        private bool CanContinueBtn(object arg)
        {
            if (CurrentServerName != null)
                return true;
            return false;
        }
    
        
        public void OnPropertyChanged(string propertyname)
        {
            if (propertyname != null || propertyname != "")
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        #endregion

        private bool ischecked = true;

        public bool Ischecked
        {
            get { return ischecked; }
            set { ischecked = value;OnPropertyChanged("Ischecked"); }
        }


        private string servername;

        public string Servername
        {
            get { return servername; }
            set { servername = value;
                Connection.DataSource = servername;
                OnPropertyChanged("Servername"); }
        }

        private string username;

        public string UserName
        {
            get { return username; }
            set { username = value;
                Connection.UserID = username;
                OnPropertyChanged("UserName"); }
        }

        private string password;

        public string Pas
        {
            get { return password;}
            set { password = value;
                
                Connection.Password = password;
                OnPropertyChanged("Password"); }
        }

        SqlConnectionStringBuilder Connection = new SqlConnectionStringBuilder();
      
        

    }
}
