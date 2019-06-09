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
            //for showing the edit dialog
            addentry frm2 = new addentry();

            //if were not selecting the add item we are editing
           
            if (sunlist.SelectedIndex != 0)
            {
                using (StreamWriter editflag = new StreamWriter("day.txt"))
                {
                    try
                    {
                        editflag.WriteLine("edit");
                        editflag.WriteLine(sunlist.SelectedItem.ToString());
                        editflag.Close();
                        frm2.ShowDialog();
                        calendarcleanup();
                        refreshcalendar();
                    }
                    catch (Exception)
                    {
                        //close the streamwriter
                        editflag.Close();

                        MessageBox.Show("Editing item failed, creating a new entry!");
                        using (StreamWriter day = new StreamWriter("day.txt"))
                        {
                            day.WriteLine("Sunday");
                            day.Close();
                        }
                        frm2.ShowDialog();
                        //refresh the calendar when we are done
                        calendarcleanup();
                        refreshcalendar();
                    }
                }

            }
            if (sunlist.SelectedIndex == 0)
            {
               
                using (StreamWriter day = new StreamWriter("day.txt"))
                {
                    day.WriteLine("Sunday");
                    day.Close();
                }
                frm2.ShowDialog();
                //refresh the calendar when we are done
                calendarcleanup();
                refreshcalendar();
            }
        }

        private void Monlist_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //create a new item
            addentry frm2 = new addentry();

            //if were not selecting the add item we are editing.
            if (monlist.SelectedIndex != 0)
            {

                using (StreamWriter editflag = new StreamWriter("day.txt"))
                {
                    try
                    {
                        editflag.WriteLine("edit");
                        editflag.WriteLine(monlist.SelectedItem.ToString());
                        editflag.Close();
                        frm2.ShowDialog();
                        calendarcleanup();
                        refreshcalendar();
                    }
                    catch (Exception)
                    {
                        //close the streamwriter
                        editflag.Close();

                        MessageBox.Show("Editing item failed, creating a new entry!");
                        using (StreamWriter day = new StreamWriter("day.txt"))
                        {
                            day.WriteLine("Monday");
                            day.Close();
                        }
                        frm2.ShowDialog();
                        //refresh the calendar when we are done
                        calendarcleanup();
                        refreshcalendar();
                    }
                }


            }
            if (monlist.SelectedIndex == 0)
            {
                //new entry
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
            //create a new item for the add dialog
            addentry frm2 = new addentry();

            //if were not selecting the add item we are editing.
            if (tuelist.SelectedIndex != 0)
            {
                using (StreamWriter editflag = new StreamWriter("day.txt"))
                {
                    try
                    {
                        editflag.WriteLine("edit");
                        editflag.WriteLine(tuelist.SelectedItem.ToString());
                        editflag.Close();
                        frm2.ShowDialog();
                        calendarcleanup();
                        refreshcalendar();
                    }
                    catch (Exception)
                    {
                        //close the streamwriter
                        editflag.Close();

                        MessageBox.Show("Editing item failed, creating a new entry!");
                        using (StreamWriter day = new StreamWriter("day.txt"))
                        {
                            day.WriteLine("Tuesday");
                            day.Close();
                        }
                        frm2.ShowDialog();
                        //refresh the calendar when we are done
                        calendarcleanup();
                        refreshcalendar();
                    }
                }

            }
            if (tuelist.SelectedIndex == 0)
            {

                using (StreamWriter day = new StreamWriter("day.txt"))
                {
                    day.WriteLine("Tuesday");
                }
                frm2.ShowDialog();
                //cleanup and refresh the calendar
                calendarcleanup();
                refreshcalendar();
            }
        }
        private void wedlist_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //create a new item for the edit dialog
            addentry frm2 = new addentry();

            //if were not selecting the add item we are editing.
            if (wedlist.SelectedIndex != 0)
            {
                using (StreamWriter editflag = new StreamWriter("day.txt"))
                {
                    try
                    {
                        editflag.WriteLine("edit");
                        editflag.WriteLine(wedlist.SelectedItem.ToString());
                        editflag.Close();
                        frm2.ShowDialog();
                        calendarcleanup();
                        refreshcalendar();
                    }
                    catch (Exception)
                    {
                        //close the streamwriter
                        editflag.Close();

                        MessageBox.Show("Editing item failed, creating a new entry!");
                        using (StreamWriter day = new StreamWriter("day.txt"))
                        {
                            day.WriteLine("Wednesday");
                            day.Close();
                        }
                        frm2.ShowDialog();
                        //refresh the calendar when we are done
                        calendarcleanup();
                        refreshcalendar();
                    }
                }
            }
            if (wedlist.SelectedIndex == 0)
            {
                
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
            //create a new item for the edit dialog
            addentry frm2 = new addentry();

            //if were not selecting the add item we are editing.
            if (thurlist.SelectedIndex != 0)
            {
                using (StreamWriter editflag = new StreamWriter("day.txt"))
                {
                    try
                    {
                        editflag.WriteLine("edit");
                        editflag.WriteLine(thurlist.SelectedItem.ToString());
                        editflag.Close();
                        frm2.ShowDialog();
                        calendarcleanup();
                        refreshcalendar();
                    }
                    catch (Exception)
                    {
                        //close the streamwriter
                        editflag.Close();

                        MessageBox.Show("Editing item failed, creating a new entry!");
                        using (StreamWriter day = new StreamWriter("day.txt"))
                        {
                            day.WriteLine("Thursday");
                            day.Close();
                        }
                        frm2.ShowDialog();
                        //refresh the calendar when we are done
                        calendarcleanup();
                        refreshcalendar();
                    }
                }
            }

            if (thurlist.SelectedIndex == 0)
            {
                
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
            //create a new item for the edit dialog
            addentry frm2 = new addentry();

            //if were not selecting the add item we are editing.
            if (frilist.SelectedIndex != 0)
            {
                using (StreamWriter editflag = new StreamWriter("day.txt"))
                {
                    try
                    {
                        editflag.WriteLine("edit");
                        editflag.WriteLine(frilist.SelectedItem.ToString());
                        editflag.Close();
                        frm2.ShowDialog();
                        calendarcleanup();
                        refreshcalendar();
                    }
                    catch (Exception)
                    {
                        //close the streamwriter
                        editflag.Close();

                        MessageBox.Show("Editing item failed, creating a new entry!");
                        using (StreamWriter day = new StreamWriter("day.txt"))
                        {
                            day.WriteLine("Friday");
                            day.Close();
                        }
                        frm2.ShowDialog();
                        //refresh the calendar when we are done
                        calendarcleanup();
                        refreshcalendar();
                    }
                }
            }
            if (frilist.SelectedIndex == 0)
            {
                //create a new item
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
            //create a new item for the edit dialog
            addentry frm2 = new addentry();

            //if were not selecting the add item we are editing.
            if (satlist.SelectedIndex != 0)
            {
                using (StreamWriter editflag = new StreamWriter("day.txt"))
                {
                    try
                    {
                        editflag.WriteLine("edit");
                        editflag.WriteLine(satlist.SelectedItem.ToString());
                        editflag.Close();
                        frm2.ShowDialog();
                        calendarcleanup();
                        refreshcalendar();
                    }
                    catch (Exception)
                    {
                        //close the streamwriter
                        editflag.Close();

                        MessageBox.Show("Editing item failed, creating a new entry!");
                        using (StreamWriter day = new StreamWriter("day.txt"))
                        {
                            day.WriteLine("Saturday");
                            day.Close();
                        }
                        frm2.ShowDialog();
                        //refresh the calendar when we are done
                        calendarcleanup();
                        refreshcalendar();
                    }
                }

            }
            if (satlist.SelectedIndex == 0)
            {
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
                //read in everything from the calendar db and put it in the ui
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

                //populate the recurrance events now
                sql = "select* from Recurrance_events order by id";
                command= new SQLiteCommand(sql, dbconnection);
                reader =  command.ExecuteReader();
                while (reader.Read())
                {
                    //fill out the calendar
                    dbdate = reader["Day_of_Week"].ToString();
                    if (dbdate.Contains("Sunday"))
                    {
                        //add the value to the sunday list
                        sunlist.Items.Add(reader["Event_Name"]);
                    }
                    else if (dbdate.Contains("Monday"))
                    {
                        monlist.Items.Add(reader["Event_Name"]);

                    }
                    else if (dbdate.Contains("Tuesday"))
                    {
                        tuelist.Items.Add(reader["Event_Name"]);

                    }
                    else if (dbdate.Contains("Wednesday"))
                    {
                        wedlist.Items.Add(reader["Event_Name"]);
                    }
                    else if (dbdate.Contains("Thursday"))
                    {
                        thurlist.Items.Add(reader["Event_Name"]);
                    }
                    else if (dbdate.Contains("Friday"))
                    {
                        frilist.Items.Add(reader["Event_Name"]);
                    }
                    else if (dbdate.Contains("Saturday"))
                    {
                        satlist.Items.Add(reader["Event_Name"]);
                    }
                }
                //close off the db
                dbconnection.Close();
             }


         }
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //run the cleanup and refresh
            Cleanupdb();
            refreshcalendar();
        }

        private void delentry(string day)
        {
            using (SQLiteConnection dbconnection = new SQLiteConnection("DataSource=calendardb.db;Version=3;"))
            {
                string sql;
                SQLiteCommand command;
                dbconnection.Open();
                //here we will delete entries in the db based on the day passed in from the context menu. run the query on both tables to make sure it works

                if (day == "sun")
                {
                    //do it for sunday
                    sql = "DELETE from single_events WHERE Event_Name = '" + sunlist.SelectedItem.ToString() + "'";
                    command = new SQLiteCommand(sql, dbconnection);
                    command.ExecuteNonQuery();
                    sql = "DELETE from Recurrance_Events WHERE Event_Name = '" + sunlist.SelectedItem.ToString() + "'";
                    command = new SQLiteCommand(sql, dbconnection);
                    command.ExecuteNonQuery();
                }
                if (day == "mon")
                {
                    //do it for monday
                    sql = "DELETE from single_events WHERE Event_Name = '" + monlist.SelectedItem.ToString() + "'";
                    command = new SQLiteCommand(sql, dbconnection);
                    command.ExecuteNonQuery();
                    sql = "DELETE from Recurrance_Events WHERE Event_Name = '" + monlist.SelectedItem.ToString() + "'";
                    command = new SQLiteCommand(sql, dbconnection);
                    command.ExecuteNonQuery();
                }
                if (day == "tue")
                {
                    //do it for sunday
                    sql = "DELETE from single_events WHERE Event_Name = '" + tuelist.SelectedItem.ToString() + "'";
                    command = new SQLiteCommand(sql, dbconnection);
                    command.ExecuteNonQuery();
                    sql = "DELETE from Recurrance_Events WHERE Event_Name = '" + tuelist.SelectedItem.ToString() + "'";
                    command = new SQLiteCommand(sql, dbconnection);
                    command.ExecuteNonQuery();
                }
                if (day == "wed")
                {
                    //do it for sunday
                    sql = "DELETE from single_events WHERE Event_Name = '" + wedlist.SelectedItem.ToString() + "'";
                    command = new SQLiteCommand(sql, dbconnection);
                    command.ExecuteNonQuery();
                    sql = "DELETE from Recurrance_Events WHERE Event_Name = '" + wedlist.SelectedItem.ToString() + "'";
                    command = new SQLiteCommand(sql, dbconnection);
                    command.ExecuteNonQuery();
                }
                if (day == "thurs")
                {
                    //do it for sunday
                    sql = "DELETE from single_events WHERE Event_Name = '" + thurlist.SelectedItem.ToString() + "'";
                    command = new SQLiteCommand(sql, dbconnection);
                    command.ExecuteNonQuery();
                    sql = "DELETE from Recurrance_Events WHERE Event_Name = '" + thurlist.SelectedItem.ToString() + "'";
                    command = new SQLiteCommand(sql, dbconnection);
                    command.ExecuteNonQuery();
                }
                if (day == "fri")
                {
                    //do it for sunday
                    sql = "DELETE from single_events WHERE Event_Name = '" + frilist.SelectedItem.ToString() + "'";
                    command = new SQLiteCommand(sql, dbconnection);
                    command.ExecuteNonQuery();
                    sql = "DELETE from Recurrance_Events WHERE Event_Name = '" + frilist.SelectedItem.ToString() + "'";
                    command = new SQLiteCommand(sql, dbconnection);
                    command.ExecuteNonQuery();
                }
                if (day == "sat")
                {
                    //do it for sunday
                    sql = "DELETE from single_events WHERE Event_Name = '" + satlist.SelectedItem.ToString() + "'";
                    command = new SQLiteCommand(sql, dbconnection);
                    command.ExecuteNonQuery();
                    sql = "DELETE from Recurrance_Events WHERE Event_Name = '" + satlist.SelectedItem.ToString() + "'";
                    command = new SQLiteCommand(sql, dbconnection);
                    command.ExecuteNonQuery();
                }
                //close the db connection
                dbconnection.Close();
            }

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //run delete method for sunday and refresh
            delentry("sun");
            calendarcleanup();
            refreshcalendar();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            //run delete method for monday and refresh
            delentry("mon");
            calendarcleanup();
            refreshcalendar();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            //run delete method for tuesday and refresh
            delentry("tue");
            calendarcleanup();
            refreshcalendar();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            //run delete method for wed and refresh
            delentry("wed");
            calendarcleanup();
            refreshcalendar();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            //run delete method for thursday and refresh
            delentry("thurs");
            calendarcleanup();
            refreshcalendar();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            //run delete method for friday and refresh
            delentry("fri");
            calendarcleanup();
            refreshcalendar();
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            //run delete method for saturday and refresh
            delentry("sat");
            calendarcleanup();
            refreshcalendar();
        }
    }
}
