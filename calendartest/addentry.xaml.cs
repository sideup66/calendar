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
                    day.Close();
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
            //read in the write file, if the first line contains edit, we are editing an existing entry
            using (StreamReader reader = new StreamReader("day.txt"))
            {
                string check = reader.ReadLine();
                reader.Close();
                    if(check.Contains("edit"))
                {
                    //we are editing at this point, we need to read in what is there and note the date as we will NOT be calculating this
                    loaddb();  
                }

            }
        }

        private void loaddb()
        {
            //load in data from the database when editing an item.
            using (SQLiteConnection dbconnection = new SQLiteConnection("DataSource=calendardb.db;Version=3;"))
            {
                dbconnection.Open();
                string desc;
                using (StreamReader readin = new StreamReader("day.txt"))
                {
                    readin.ReadLine();
                    desc = readin.ReadLine();
                    readin.Close();
                }
                string sql = "select * from single_events where Event_Name= " + "'" + desc + "'";
                SQLiteCommand command = new SQLiteCommand(sql, dbconnection);
                SQLiteDataReader reader = command.ExecuteReader();
                //little string for adjusting input for some fields
                string tofix;
                while (reader.Read())
                    {
                    //fill in the form
                    evntnmtxtbx.Text = reader["Event_Name"].ToString();
                    //get the start time
                    tofix = reader["Start_Time"].ToString();
                    tofix = tofix.Replace("AM", "");
                    tofix = tofix.Replace("PM", "");
                    strttmpicker.Text = tofix;
                    tofix = reader["Start_Time"].ToString();
                    tofix = tofix.Substring(tofix.IndexOf(" ") + 1);
                    strttmampm.Text = tofix;

                    //set the endtime
                    tofix = reader["End_Time"].ToString();
                    tofix = tofix.Replace("AM", "");
                    tofix = tofix.Replace("PM", "");
                    endtmpicker.Text = tofix;
                    tofix = reader["End_Time"].ToString();
                    tofix = tofix.Substring(tofix.IndexOf(" ") + 1);
                    endtmampm.Text = tofix;

                    //now set the blocked proram or site option
                    if (reader["Block_Sites"].ToString().Contains("1"))
                    {
                        blkwebstbtn.IsChecked = true;
                    }

                    if (reader["Block_Programs"].ToString().Contains("1"))
                    {
                        blkprogramchkbx.IsChecked = true;
                    }
                }
                //if nothing was found for normal events, try recurring
                sql = "select * from Recurrance_Events where Event_Name= " + "'" + desc + "'";
                command = new SQLiteCommand(sql, dbconnection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //fill in the form
                    evntnmtxtbx.Text = reader["Event_Name"].ToString();
                    //get the start time
                    tofix = reader["Start_Time"].ToString();
                    tofix = tofix.Replace("AM", "");
                    tofix = tofix.Replace("PM", "");
                    strttmpicker.Text = tofix;
                    tofix = reader["Start_Time"].ToString();
                    tofix = tofix.Substring(tofix.IndexOf(" ") + 1);
                    strttmampm.Text = tofix;

                    //set the endtime
                    tofix = reader["End_Time"].ToString();
                    tofix = tofix.Replace("AM", "");
                    tofix = tofix.Replace("PM", "");
                    endtmpicker.Text = tofix;
                    tofix = reader["End_Time"].ToString();
                    tofix = tofix.Substring(tofix.IndexOf(" ") + 1);
                    endtmampm.Text = tofix;

                    //now set the blocked proram or site option
                    if (reader["Block_Sites"].ToString().Contains("1"))
                    {
                        blkwebstbtn.IsChecked = true;
                    }

                    if (reader["Block_Programs"].ToString().Contains("1"))
                    {
                        blkprogramchkbx.IsChecked = true;
                    }
                    //last, we check the recurrance checkbox to deal with repeating events.
                    rptevntchkbx.IsChecked = true;
                }
                dbconnection.Close();
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
