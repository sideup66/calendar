using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
using System.IO;
namespace calendartest
{
    /// <summary>
    /// Interaction logic for addentry.xaml
    /// </summary>
    public partial class addentry : Window
    {
        public addentry()
        {
            InitializeComponent();
        }

        //write data to the table
        void dbwriter()
        {
            //write the entry to the table
            using (SQLiteConnection dbconnection = new SQLiteConnection("DataSource=calendardb.db;Version=3;"))
            {
                //declare som variables
                dbconnection.Open();
                int blockprogs = 0;
                int blocksites = 0;
                string sql;
                string wkday;
                SQLiteCommand command;
                if (blkprogramchkbx.IsChecked == true)
                {
                    blockprogs = 1;
                }
                if (blkwebstbtn.IsChecked == true)
                {
                    blocksites = 1;
                }
                using (StreamReader day = new StreamReader("day.txt"))
                {
                    wkday = day.ReadLine();
                }
                //if the user is using a recurring schedule, the db works a bit different. So we will need a different write 
                if (rptevntchkbx.IsChecked == true)
                {
                    //we dont care about the date,long as the day of the week matches, we can go
                    sql = "insert into Recurrance_Events (Day_of_Week, Event_Name, Start_Time, End_Time, Block_Programs, Block_Websites) values ('" + wkday + "', '" + evntnmtxtbx.Text + "', '" + strttmpicker.Text + " " + strttmampm.Text + "', '" + endtmpicker.Text + " " + endtmampm.Text + "', " + blocksites + " , " + blockprogs + ")";
                    command = new SQLiteCommand(sql, dbconnection);
                    command.ExecuteNonQuery();
                }
                else
                {
                    //find the next day using what is in the readline
                    int advclock = 0;
                    string setdate = DateTime.Today.AddDays(advclock).DayOfWeek.ToString();
                    while (wkday != setdate)
                    {
                        setdate = DateTime.Today.AddDays(advclock).DayOfWeek.ToString();
                        advclock++;
                    }
                    //adjust for a 1 day offset 
                    advclock--;
                    setdate = DateTime.Today.AddDays(advclock).ToString("MM-dd");
                    sql = "insert into Single_Events (Creation_Date, Event_Name, Start_Time, End_Time, Block_Sites, Block_Programs) values ('" + setdate + "', '" + evntnmtxtbx.Text + "', '" + strttmpicker.Text + " " + strttmampm.Text + "', '" + endtmpicker.Text + " " + endtmampm.Text + "', " + blockprogs + " , " + blocksites + ")";
                    command = new SQLiteCommand(sql, dbconnection);
                    command.ExecuteNonQuery();
                }
                dbconnection.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //add the time into the comboboxes so a user can pick times for start and end
            int hour = 1;
            int min = 00;
            string printmin;
            while (hour <= 12)
            {
                printmin = min.ToString("00");
                strttmpicker.Items.Add(hour + ":" + printmin);
                endtmpicker.Items.Add(hour + ":" + printmin);
                if (min == 59)
                {
                    hour = hour + 1;
                    min = 0;
                    if (hour != 13)
                    {
                        printmin = min.ToString("00");
                        strttmpicker.Items.Add(hour + ":" + printmin);
                        endtmpicker.Items.Add(hour + ":" + printmin);
                    }

                }
                min++;
            }
        }

        private void Strttmpicker_LostFocus(object sender, RoutedEventArgs e)
        {
            //validate the time input
            bool allowed = false;
            string value = "";
            if (strttmpicker.Text != "")
            {
                for (int i = 0; i < strttmpicker.Items.Count; i++)
                {
                    value = strttmpicker.Items[i].ToString();
                    if (value == strttmpicker.Text)
                    {
                        allowed = true;
                        break;
                    }
                }
                if (!allowed)
                {
                    MessageBox.Show("Please input a valid start time!", "Input Error!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
        }

        private void Evntnmtxtbx_GotFocus(object sender, RoutedEventArgs e)
        {
            if (evntnmtxtbx.Text.Contains("Enter the event name here..."))
            {
                evntnmtxtbx.Text = "";
            }
        }

        private void Cancelbtn_Click(object sender, RoutedEventArgs e)
        {
            //closes the form
            this.Close();
        }

        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            //write to the database and close
            dbwriter();
            this.Close();
        }
    }
}
