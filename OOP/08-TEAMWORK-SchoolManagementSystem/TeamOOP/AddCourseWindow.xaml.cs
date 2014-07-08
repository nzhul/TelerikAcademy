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

namespace TeamOOP
{
    /// <summary>
    /// Interaction logic for AddCourseWindow.xaml
    /// </summary>
    public partial class AddCourseWindow : Window
    {
        object someoneWithCourses;

        public AddCourseWindow(Person person)
        {
            someoneWithCourses = person;
            List<Course> subscribedCourses = new List<Course>();
            if (person is Student)
            {
                subscribedCourses=((Student)someoneWithCourses).CoursesList;
            }
            else if (person is Teacher)
            {
                subscribedCourses = ((Teacher)someoneWithCourses).CoursesList;
            }
            InitializeComponent();
            List<Course> allCourses = new List<Course>();

            // Show The list of all AvailableCourses
            foreach (CourseName course in (CourseName[]) Enum.GetValues(typeof(CourseName)))
            {
                // Check if the course exists in the Student Course List
                bool courseExists = false;
                for (int i = 0; i < subscribedCourses.Count; i++)
                {
                    if (subscribedCourses[i].Name == course.ToString())
                    {
                        courseExists = true;
                    }
                }
                if (courseExists)
                {
                    courseExists = false;
                    continue;
                }
                else
                {
                    allCourses.Add(new Course(course));
                }
            }
            courseComboBox.ItemsSource = allCourses;
            courseComboBox.SelectedIndex = 0;
        }

        private void addGrade_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // TODO IMPLEMENT THIS
            Course course = (Course)courseComboBox.SelectedItem;

            if (someoneWithCourses is Student)
            {
                ((Student)someoneWithCourses).AddCourse(course);
            }
            else if (someoneWithCourses is Teacher)
            {
                ((Teacher)someoneWithCourses).AddCourse(course);
            }
            this.Close();

        }

        private void addGrade_MouseEnter(object sender, MouseEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            addBtn.Background = (Brush)bc.ConvertFrom("#c3d3e8");
        }

        private void addGrade_MouseLeave(object sender, MouseEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            addBtn.Background = (Brush)bc.ConvertFrom("#d7d7d7");
        }
    }
}
