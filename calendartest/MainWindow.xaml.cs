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
                frm2.Show();
                using (StreamWriter day = new StreamWriter("day.txt"))
                {
                    day.WriteLine("Sunday");
                }
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
                frm2.Show();
                using (StreamWriter day = new StreamWriter("day.txt"))
                {
                    day.WriteLine("Monday");
                }
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
                frm2.Show();
                using (StreamWriter day = new StreamWriter("day.txt"))
                {
                    day.WriteLine("Tuesday");
                }
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
                frm2.Show();
                using (StreamWriter day = new StreamWriter("day.txt"))
                {
                    day.WriteLine("Wednesday");
                }
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
                frm2.Show();
                using (StreamWriter day = new StreamWriter("day.txt"))
                {
                    day.WriteLine("Thursday");
                }
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
                frm2.Show();
                using (StreamWriter day = new StreamWriter("day.txt"))
                {
                    day.WriteLine("Friday");
                }
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
                frm2.Show();
                using (StreamWriter day = new StreamWriter("day.txt"))
                {
                    day.WriteLine("Saturday");
                }
            }
        }
        private void Cleanupdb()
        {
            using (SQLiteConnection dbconnection = new SQLiteConnection("DataSource=calendardb.db;Version=3;"))
            {
                dbconnection.Open();

                //TODO: here we will be cleaning up old entries in the db
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
                //read in everything for the calendar
                string sql = "select * from single_events order by Creation_Date";
                SQLiteCommand command = new SQLiteCommand(sql, dbconnection);
                //here we write everything to the calendar

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
