using PersonModule;
using PersonModule.PersonDefinitions;
using System;
using System.ComponentModel;
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
    /// Interaction logic for StudentView.xaml
    /// </summary>
    public partial class StudentView : Window
    {
        private Student _student;

        public StudentView(Student student)
        {
            InitializeComponent();
            _student = student;

            this.firstName.Text = _student.FirstName;
            this.lastName.Text = _student.LastName;
            this.tbxFacultyNumber.Text = _student.FacultyNumber.ToString();
            this.rank.Text = _student.Rank.ToString();
            lvGrades.ItemsSource = _student.GradeList;
            this.homeTown.Text = _student.HomeTown;

            this.TotalPoints.Text = _student.TotalPoints.ToString();
            this.AverageGrade.Text = string.Format("{0:F2}", _student.AverageGrade);
            this.BestCourse.Text = _student.BestCourse.ToString();


            _student.CoursesList.Add(new Course(CourseName.Algorithms));
            lvCourses.ItemsSource = _student.CoursesList;
        }

        private void addGrade_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AddGradeWindow addGrade = new AddGradeWindow(_student);
            addGrade.ShowDialog();
            lvGrades.ItemsSource = _student.GradeList;
            this.AverageGrade.Text = string.Format("{0:F2}", _student.AverageGrade);
            this.TotalPoints.Text = _student.TotalPoints.ToString();
        }

        // Course Btn Events
        private void SubScribeCourse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AddCourseWindow addGrade = new AddCourseWindow(_student);
            addGrade.ShowDialog();
            lvCourses.ItemsSource = _student.CoursesList;
        }

        // Promote Btn Events
        private void PromotePerson_MouseClick(object sender, MouseButtonEventArgs e)
        {
            ChangeRankWindow changeRankWindow = new ChangeRankWindow(this._student);
            changeRankWindow.ShowDialog();
            this.rank.Text = _student.Rank.ToString();

        }

        //Edit
        private void Edit_Student(object sender, MouseButtonEventArgs e)
        {
            if (tblEditStudent.Text == "Edit Student")
            {
                this.tbxFirstName.IsReadOnly = false;
                this.tbxLastName.IsReadOnly = false;
                this.tbxFacultyNumber.IsReadOnly = false;
                this.tbxFirstName.BorderThickness = new Thickness(1);
                this.tbxLastName.BorderThickness = new Thickness(1);
                this.tbxFacultyNumber.BorderThickness = new Thickness(1);
                this.tblEditStudent.Text = "Apply changes";
                this.homeTown.IsReadOnly = false;
                this.homeTown.BorderThickness = new Thickness(1);

            }
            else
            {
                this.tbxFirstName.IsReadOnly = true;
                this.tbxLastName.IsReadOnly = true;
                this.tbxFacultyNumber.IsReadOnly = true;
                this.homeTown.IsReadOnly = true;
                this.tbxFirstName.BorderThickness = new Thickness(0);
                this.tbxLastName.BorderThickness = new Thickness(0);
                this.tbxFacultyNumber.BorderThickness = new Thickness(0);
                this.homeTown.BorderThickness = new Thickness(0);
                this.tblEditStudent.Text = "Edit Student";
                _student.UpdateStudentDetails(this.tbxFirstName.Text, this.tbxLastName.Text,
                    _student.EGN, int.Parse(this.tbxFacultyNumber.Text), _student.Rank, this.homeTown.Text);

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

        private void DeleteStudent(object sender, MouseButtonEventArgs e)
        {
            StudentsContainer students = StudentsContainer.Instance;
            students.Remove(_student.EGN);
            this.Close();
        }

    }
}
