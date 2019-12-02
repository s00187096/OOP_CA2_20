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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CA2_OOP_20
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Activity> allActivities = new List<Activity>();
        List<Activity> selectedActivities = new List<Activity>();
        List<Activity> filteredActivities = new List<Activity>();

        decimal total = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Btn___ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private List<Activity> CreateActivities()
        {

            List<Activity> allActivities = new List<Activity>();

            Activity l1 = new Activity()
            {
                Name = "Treking",
                Description = "Instructor led group trek through local mountains.",
                ActivityDate = new DateTime(2019, 06, 01),
                TypeOfActivity = ActivityType.Land,
                Cost = 20m
            };

            Activity l2 = new Activity()
            {
                Name = "Mountain Biking",
                Description = "Instructor led half day mountain biking.  All equipment provided.",
                ActivityDate = new DateTime(2019, 06, 02),
                TypeOfActivity = ActivityType.Land,
                Cost = 30m
            };

            Activity l3 = new Activity()
            {
                Name = "Abseiling",
                Description = "Experience the rush of adrenaline as you descend cliff faces from 10-500m.",
                ActivityDate = new DateTime(2019, 06, 03),
                TypeOfActivity = ActivityType.Land,
                Cost = 40m
            };

            Activity w1 = new Activity()
            {
                Name = "Kayaking",
                Description = "Half day lakeland kayak with island picnic.",
                ActivityDate = new DateTime(2019, 06, 01),
                TypeOfActivity = ActivityType.Water,
                Cost = 40m
            };

            Activity w2 = new Activity()
            {
                Name = "Surfing",
                Description = "2 hour surf lesson on the wild atlantic way",
                ActivityDate = new DateTime(2019, 06, 02),
                TypeOfActivity = ActivityType.Water,
                Cost = 25m
            };

            Activity w3 = new Activity()
            {
                Name = "Sailing",
                Description = "Full day lakeland kayak with island picnic.",
                ActivityDate = new DateTime(2019, 06, 03),
                TypeOfActivity = ActivityType.Water,
                Cost = 50m
            };

            Activity a1 = new Activity()
            {
                Name = "Parachuting",
                Description = "Experience the thrill of free fall while you tandem jump from an airplane.",
                ActivityDate = new DateTime(2019, 06, 01),
                TypeOfActivity = ActivityType.Air,
                Cost = 100m
            };

            Activity a2 = new Activity()
            {
                Name = "Hang Gliding",
                Description = "Soar on hot air currents and enjoy spectacular views of the coastal region.",
                ActivityDate = new DateTime(2019, 06, 02),
                TypeOfActivity = ActivityType.Air,
                Cost = 80m
            };

            Activity a3 = new Activity()
            {
                Name = "Helicopter Tour",
                Description = "Experience the ultimate in aerial sight-seeing as you tour the area in our modern helicopters",
                ActivityDate = new DateTime(2019, 06, 03),
                TypeOfActivity = ActivityType.Air,
                Cost = 200m
            };

            allActivities.Add(l1);
            allActivities.Add(l2);
            allActivities.Add(l3);
            allActivities.Add(a1);
            allActivities.Add(a2);
            allActivities.Add(a3);
            allActivities.Add(w1);
            allActivities.Add(w2);
            allActivities.Add(w3);

            return allActivities;

        }

        //Code runs when window loads
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //create activities

            allActivities = CreateActivities();


            //display
            lbxAllActivities.ItemsSource = allActivities;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            // figure out selceted item
            Activity activity = lbxAllActivities.SelectedItem as Activity;//get selected item
            //null check
            if (activity != null)
            {

                //before moving check if date conflict

                //look at the selected activities to make sure none have the same date as the one we are moving

                DateTime dateOfActivity = activity.ActivityDate;

                bool dateClash = false;
                foreach (Activity act in selectedActivities)
                {
                    if (dateOfActivity == act.ActivityDate)
                        dateClash = true;
                }

                if (dateClash == false)
                {

                    //move item from left to right
                    allActivities.Remove(activity);
                    selectedActivities.Add(activity);

                    //update total
                    total += activity.Cost;
                    tblkTotal.Text = total.ToString();

                    //refresh window
                    Refresh();
                }
                else if (dateClash == true)
                {
                    MessageBox.Show("Date clash");
                }
            }
            else
            {
                MessageBox.Show("Nothing selected");
            }
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            // figure out selceted item
            Activity activity = lbxSelectedActivities.SelectedItem as Activity;//get selected item
            //null check
            if (activity != null)
            {
                //move item from left to right
                selectedActivities.Remove(activity);
                allActivities.Add(activity);

                //update total
                total -= activity.Cost;
                tblkTotal.Text = total.ToString();

                //refresh window
                Refresh();
            }
            else
            {
                MessageBox.Show("Nothing Selected");
            }
        }

        private void Refresh()
        {
            lbxSelectedActivities.ItemsSource = null;
            lbxSelectedActivities.ItemsSource = selectedActivities;

            lbxAllActivities.ItemsSource = null;
            lbxAllActivities.ItemsSource = allActivities;
        }

        //handkes all radio buttons
        private void RbAll_Click(object sender, RoutedEventArgs e)
        {
            filteredActivities.Clear();
            if (rbAll.IsChecked == true)
            {
                //show all Activities
                Refresh();
            }
            else if (rbAir.IsChecked == true)
            {
                //show air Activities

                //air activites
                foreach (Activity activity in allActivities)
                {
                    if (activity.TypeOfActivity == ActivityType.Air)
                    {
                        filteredActivities.Add(activity);
                        lbxAllActivities.ItemsSource = null;
                        lbxAllActivities.ItemsSource = filteredActivities;
                    }
                }
            }
            else if (rbLand.IsChecked == true)
            {
                //land activites
                foreach (Activity activity in allActivities)
                {
                    if (activity.TypeOfActivity == ActivityType.Land)
                    {
                        filteredActivities.Add(activity);
                        lbxAllActivities.ItemsSource = null;
                        lbxAllActivities.ItemsSource = filteredActivities;
                    }
                }
            }
            else if (rbWater.IsChecked == true)
            {
                //water activites
                foreach (Activity activity in allActivities)
                {
                    if (activity.TypeOfActivity == ActivityType.Water)
                    {
                        filteredActivities.Add(activity);
                        lbxAllActivities.ItemsSource = null;
                        lbxAllActivities.ItemsSource = filteredActivities;
                    }
                }
            }
        }

        private void LbxAllActivities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //figure out what was selected
            Activity activity = lbxAllActivities.SelectedItem as Activity;//get selected item
            //check it is not null
            if (activity !=null ) 
            {
                //update text of textblock with the activity description
                tblkDescription.Text = activity.Description;

            }


        }
    }
}

