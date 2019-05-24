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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace calendartest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
 

        private void Sunlist_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //if were not selecting the add item we are editing.
            if (sunlist.SelectedIndex != 0)
            {
                MessageBox.Show("you are editing an item.");
            }
            if (sunlist.SelectedIndex == 0)
            {
                //create a new item
                addentry frm2 = new addentry();
                using (StreamWriter day = new StreamWriter("day.txt"))
                {
                    day.WriteLine("Sunday");
                }
                frm2.ShowDialog();
                //refresh the calendar when we are done
                calendarcleanup();
                refreshcalendar();
            }
        }

        private void Monlist_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //if were not selecting the add item we are editing.
            if (monlist.SelectedIndex != 0)
            {
                MessageBox.Show("you are editing an item.");
            }
            if (monlist.SelectedIndex == 0)
            {
                //create a new item
                addentry frm2 = new addentry();
                using (StreamWriter day = new StreamWriter("day.txt"))
                {
                    day.WriteLine("Monday");
                }
                frm2.ShowDialog();
                //cleanup and refresh the calendar
                calendarcleanup();
                refreshcalendar();
            }
        }
        private void tuelist_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //if were not selecting the add item we are editing.
            if (tuelist.SelectedIndex != 0)
            {
                MessageBox.Show("you are editing an item.");
            }
            if (tuelist.SelectedIndex == 0)
            {
                //create a new item
                addentry frm2 = new addentry();
                using (StreamWriter day = new StreamWriter("day.txt"))
                {
                    day.WriteLine("Tuesday");
                }
                frm2.Show();
                //cleanup and refresh the calendar
                calendarcleanup();
                refreshcalendar();
            }
        }
        private void wedlist_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //if were not selecting the add item we are editing.
            if (wedlist.SelectedIndex != 0)
            {
                MessageBox.Show("you are editing an item.");
            }
            if (wedlist.SelectedIndex == 0)
            {
                //create a new item
                addentry frm2 = new addentry();
                using (StreamWriter day = new StreamWriter("day.txt"))
                {
                    day.WriteLine("Wednesday");
                }
                frm2.ShowDialog();
                //cleanup and refresh the calendar
                calendarcleanup();
                refreshcalendar();
            }
        }
        private void thurlist_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //if were not selecting the add item we are editing.
            if (thurlist.SelectedIndex != 0)
            {
                MessageBox.Show("you are editing an item.");
            }
            if (thurlist.SelectedIndex == 0)
            {
                //create a new item
                addentry frm2 = new addentry();
                using (StreamWriter day = new StreamWriter("day.txt"))
                {
                    day.WriteLine("Thursday");
                }
                frm2.ShowDialog();
                //cleanup and refresh the calendar
                calendarcleanup();
                refreshcalendar();
            }
        }
        private void frilist_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //if were not selecting the add item we are editing.
            if (frilist.SelectedIndex != 0)
            {
                MessageBox.Show("you are editing an item.");
            }
            if (frilist.SelectedIndex == 0)
            {
                //create a new item
                addentry frm2 = new addentry();
                using (StreamWriter day = new StreamWriter("day.txt"))
                {
                    day.WriteLine("Friday");
                }
                frm2.ShowDialog();
                //cleanup and refresh the calendar
                calendarcleanup();
                refreshcalendar();

            }
        }
        private void satlist_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //if were not selecting the add item we are editing.
            if (satlist.SelectedIndex != 0)
            {
                MessageBox.Show("you are editing an item.");
            }
            if (satlist.SelectedIndex == 0)
            {
                //create a new item
                addentry frm2 = new addentry();
                using (StreamWriter day = new StreamWriter("day.txt"))
                {
                    day.WriteLine("Saturday");
                }
                frm2.ShowDialog();
                //cleanup and refresh the calendar
                calendarcleanup();
                refreshcalendar();
            }
        }

        private void calendarcleanup()
        {
            //here we will be cleaning up the calendar by deleteing old entries (any change triggers a refresh and will call this method to cleanup first)
            monlist.Items.Clear();
            monlist.Items.Add("Click here");
            tuelist.Items.Clear();
            tuelist.Items.Add("Click here");
            wedlist.Items.Clear();
            wedlist.Items.Add("Click here");
            thurlist.Items.Clear();
            thurlist.Items.Add("Click here");
            frilist.Items.Clear();
            frilist.Items.Add("Click here");
            satlist.Items.Clear();
            satlist.Items.Add("Click here");
            sunlist.Items.Clear();
            sunlist.Items.Add("Click here");
        }

        private void Cleanupdb()
        {
            using (SQLiteConnection dbconnection = new SQLiteConnection("DataSource=calendardb.db;Version=3;"))
            {
                dbconnection.Open();

                //this logic will clean up old entries that are before the current date
                string sql = "select * from single_events order by Creation_Date";
                SQLiteCommand command = new SQLiteCommand(sql, dbconnection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //check each entry from the reader and delete from the table IF the schedule entry is in the past
                    DateTime dbdate = Convert.ToDateTime(reader["Creation_Date"]);
                    DateTime nowdate = Convert.ToDateTime(DateTime.Now.ToString("MM-dd"));
                    if (dbdate < nowdate)
                    {
                        //delete the entry, its old.
                        sql = "DELETE  from single_events where id = " + reader["id"].ToString();
                        command = new SQLiteCommand(sql, dbconnection);
                        command.ExecuteNonQuery();
                    }
                }
                dbconnection.Close();
            }
        }
        private void refreshcalendar()
        {
            using (SQLiteConnection dbconnection = new SQLiteConnection("DataSource=calendardb.db;Version=3;"))
            {
                dbconnection.Open();
                //read in everything from the calendar and put it in the 
                string sql = "select * from single_events order by Creation_Date";

                SQLiteCommand command = new SQLiteCommand(sql, dbconnection);
                SQLiteDataReader reader = command.ExecuteReader();
                string dbdate;
                DateTime daytoadd;
                string dayofweek;
                while (reader.Read())
                {
                    //populate single events
                    dbdate = reader["Creation_Date"].ToString();
                    daytoadd = Convert.ToDateTime(dbdate);
                    dayofweek = daytoadd.ToString("dddd");
                    if (dayofweek.Contains("Sunday"))
                    {
                        //add the value to the sunday list
                        sunlist.Items.Add(reader["Event_Name"]);
                    }
                    else if (dayofweek.Contains("Monday"))
                    {
                        monlist.Items.Add(reader["Event_Name"]);

                    }
                    else if (dayofweek.Contains("Tuesday"))
                    {
                        tuelist.Items.Add(reader["Event_Name"]);

                    }
                    else if (dayofweek.Contains("Wednesday"))
                    {
                        wedlist.Items.Add(reader["Event_Name"]);
                    }
                    else if (dayofweek.Contains("Thursday"))
                    {
                        thurlist.Items.Add(reader["Event_Name"]);
                    }
                    else if (dayofweek.Contains("Friday"))
                    {
                        frilist.Items.Add(reader["Event_Name"]);
                    }
                    else if (dayofweek.Contains("Saturday"))
                    {
                        satlist.Items.Add(reader["Event_Name"]);
                    }
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //run the cleanup and refresh
            Cleanupdb();
            refreshcalendar();
        }
    }
}
