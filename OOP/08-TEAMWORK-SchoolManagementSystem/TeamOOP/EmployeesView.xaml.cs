using PersonModule;
using PersonModule.PersonDefinitions;
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
using TeamOOP.Utilities;

namespace TeamOOP
{
    /// <summary>
    /// Interaction logic for EmployeesView.xaml
    /// </summary>
    public partial class EmployeesView : Window
    {
        private Employee _employee;
        private Teacher _teacher;
        
        public EmployeesView(Employee employee)
        { 
            InitializeComponent();
            _employee = employee;

            this.firstName.Text = _employee.FirstName;
            this.lastName.Text = _employee.LastName;
            this.tbxIDNumber.Text = _employee.Id.ToString();
            this.homeTown.Text = _employee.HomeTown;

            if (_employee is Teacher)
            {
                _teacher = (Teacher)_employee;
                this.rank.Text = _teacher.Rank.ToString();
                lvCourses.ItemsSource = _teacher.CoursesList;
            }
            else
            {
 //               promoteBtn.Visibility = System.Windows.Visibility.Hidden;
                addBtn.Visibility = System.Windows.Visibility.Hidden;
                addCourseButton.Visibility = System.Windows.Visibility.Hidden;
                tabMain.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        //Rating
        private void addRating_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // TODO: Change this to Add Rating!
            //AddGradeWindow addRating= new AddGradeWindow(_employee);
            //addRating.ShowDialog();
        }

        //Promote
        private void PromotePerson_MouseClicl(object sender, MouseButtonEventArgs e)
        {
            ChangeRankWindow changeRankWindow = new ChangeRankWindow(this._employee);
            changeRankWindow.ShowDialog();
            this.rank.Text = _teacher.Rank.ToString();
        }

        //Edit
        private void Edit_Employee(object sender, MouseButtonEventArgs e)
        {
            if (tblEditEmployee.Text == "Edit Employee")
            {
                this.tbxFirstName.IsReadOnly = false;
                this.tbxLastName.IsReadOnly = false;
                this.tbxIDNumber.IsReadOnly = false;
                this.tbxFirstName.BorderThickness = new Thickness(1);
                this.tbxLastName.BorderThickness = new Thickness(1);
                this.tbxIDNumber.BorderThickness = new Thickness(1);
                this.tblEditEmployee.Text = "Apply changes";
                this.homeTown.IsReadOnly = false;
                this.homeTown.BorderThickness = new Thickness(1);

            }
            else
            {
                this.tbxFirstName.IsReadOnly = true;
                this.tbxLastName.IsReadOnly = true;
                this.tbxIDNumber.IsReadOnly = true;
                this.tbxFirstName.BorderThickness = new Thickness(0);
                this.tbxLastName.BorderThickness = new Thickness(0);
                this.tbxIDNumber.BorderThickness = new Thickness(0);
                this.tblEditEmployee.Text = "Edit Employee";
                _employee.UpdateEmployeeDetails(this.tbxFirstName.Text, this.tbxLastName.Text,
                    _employee.EGN, int.Parse(this.tbxIDNumber.Text), this.homeTown.Text);

                this.homeTown.IsReadOnly = true;
                this.homeTown.BorderThickness = new Thickness(0);

            }
        }

        private void btnMouseEnter(object sender, MouseEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            Border border = (Border)sender;
            border.Background = (Brush)bc.ConvertFrom("#c3d3e8");
        }

        private void btnMouseLeave(object sender, MouseEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            Border border = (Border)sender;
            border.Background = (Brush)bc.ConvertFrom("#d7d7d7");
        }        

        private void Delete_Employee(object sender, MouseButtonEventArgs e)
        {
            EmployeesContainer employees = EmployeesContainer.Instance;
            employees.Remove(_employee.EGN);
            this.Close();
        }

        private void AddCourse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AddCourseWindow addGrade = new AddCourseWindow(_teacher);
            addGrade.ShowDialog();
            lvCourses.ItemsSource = _teacher.CoursesList;
        }

    }        

}
