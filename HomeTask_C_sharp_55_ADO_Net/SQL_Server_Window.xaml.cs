using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HomeTask_C_sharp_55_ADO_Net
{
    /// <summary>
    /// Interaction logic for SQL_Server_Window.xaml
    /// </summary>
    public partial class SQL_Server_Window : Window
    {
        //ServersList servers = new ServersList();
        public SQL_Server_Window()
        {
            InitializeComponent();
        }

        public void ButtonChangeEvent(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow main = new MainWindow();
            main.ShowDialog();
            main.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = dbNameTxtBox.Text.ToLower();
            
            List<string> namelist = new List<string>();
            namelist.Clear();
            if (ServersList.ServersNameFromDb != null)
            {
                foreach (string item in ServersList.ServersNameFromDb)
                {
                    if (!string.IsNullOrEmpty(dbNameTxtBox.Text))
                    {
                        string newitem = item.ToLower();
                        if (newitem.StartsWith(dbNameTxtBox.Text))
                        {
                            namelist.Add(item);
                        }
                    }
                }

                if (namelist.Count > 0)
                {
                    autoCompleteListBox.ItemsSource = namelist;
                    autoCompleteListBox.Visibility = Visibility.Visible;
                }
                else if (dbNameTxtBox.Text.Equals(""))
                {
                    autoCompleteListBox.ItemsSource = null;
                    autoCompleteListBox.Visibility = Visibility.Collapsed;
                }
                else
                {
                    autoCompleteListBox.ItemsSource = null;
                    autoCompleteListBox.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void autoCompleteListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(autoCompleteListBox.ItemsSource!=null)
            {
                autoCompleteListBox.Visibility = Visibility.Collapsed;
                dbNameTxtBox.TextChanged -= TextBox_TextChanged;
                if(autoCompleteListBox.SelectedIndex!=-1)
                {
                    dbNameTxtBox.Text = autoCompleteListBox.SelectedItem.ToString();
                }
                dbNameTxtBox.TextChanged += TextBox_TextChanged;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            autoCompleteListBox.Visibility = Visibility.Visible;
        }
    }

    
}
