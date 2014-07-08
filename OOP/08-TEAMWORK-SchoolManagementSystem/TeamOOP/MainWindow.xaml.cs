using PersonModule;
using PersonModule.PersonDefinitions;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml;
using System.Xml.Linq;
using TeamOOP.Utilities;

namespace TeamOOP
{
    public partial class MainWindow : Window
    {
        StudentsContainer students = StudentsContainer.Instance;
        EmployeesContainer employees = EmployeesContainer.Instance;
        public MainWindow()
        {
            InitializeComponent();
            students.ReadStudentsFromFile(Utils.Constants.FILENAME);
            lvStudents.ItemsSource = students.StudentList;

            employees.ReadEmployeesFromFile(Utils.Constants.FILENAME);
            lvEmployees.ItemsSource = employees.EmployeesList;

            this.studentCounter.Text = students.StudentCounter();
            this.averGrade.Text = string.Format("{0:F2}", students.AverageGrade());
            Student bestStudent = students.BestStudent();
            this.bestStudent.Text = bestStudent.FirstName + " " + bestStudent.LastName;
            this.bestStudHome.Text = bestStudent.HomeTown;

            this.TotalSalaryCost.Text = "$" + employees.TotalSalaryCost.ToString();
            this.AverageSalary.Text = "$" + employees.AverageSalary.ToString();
            Employee bestEmployee = employees.BestEmployee();
            this.BestEmployee.Text = bestEmployee.FirstName + " " + bestEmployee.LastName;

            List<Course> allCourses = new List<Course>();

            // Show The list of all AvailableCourses
            foreach (CourseName course in (CourseName[])Enum.GetValues(typeof(CourseName)))
            {
                allCourses.Add(new Course(course));
            }
            lvCourses.ItemsSource = allCourses;
        }      

        public void buttonEmployeeAdd_Click(object sender, RoutedEventArgs e)
        {
            CreateEmployee createEmployee = new CreateEmployee(employees);
            createEmployee.ShowDialog();
            lvEmployees.ItemsSource = employees.EmployeesList;
            this.TotalSalaryCost.Text = "$" + employees.TotalSalaryCost.ToString();
            this.AverageSalary.Text = "$" + employees.AverageSalary.ToString();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            CreateStudentWindow createStudent = new CreateStudentWindow(students);
            createStudent.ShowDialog();
            lvStudents.ItemsSource = students.StudentList;
            this.studentCounter.Text = students.StudentCounter();
        }

        private void lvStudents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Student selectedStudent = (Student)lvStudents.SelectedItem;

            StudentView window = new StudentView(selectedStudent);
            window.ShowDialog();
        }

        private void lvEmployee_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            Employee selectedEmplyee = (Employee)lvEmployees.SelectedItem;

            EmployeesView window = new EmployeesView(selectedEmplyee);
            window.ShowDialog();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            XElement dataNode = new XElement("Data");
            StudentsContainer students = StudentsContainer.Instance;
            XElement studentsNode = new XElement("ListOfStudents");
            foreach (var student in students.StudentList)
            {
                studentsNode.Add(student.toXML());
            }
            dataNode.Add(new XComment("Students"));
            dataNode.Add(studentsNode);

            EmployeesContainer employees = EmployeesContainer.Instance;
            XElement employeesNode = new XElement("ListOfEmployees");
            foreach (var student in employees.EmployeesList)
            {
                employeesNode.Add(student.toXML());
            }
            dataNode.Add(new XComment("Employees")); 
            dataNode.Add(employeesNode);

            XmlDocument XMLFile = new XmlDocument();
            XMLFile.LoadXml(dataNode.ToString()); // ulgy, I had not time to find the right use of the class
            XMLFile.Save(Utils.Constants.FILENAME);
        }

        private void buttonReset_Click(object sender, RoutedEventArgs e)
        {
//            students.FillWithDummyData();
            lvStudents.ItemsSource = students.StudentList;

//            employees.FillWithDummyData();
            lvEmployees.ItemsSource = employees.EmployeesList;
        }

        void onPageFocused(object sender, RoutedEventArgs e)
        {
            lvStudents.ItemsSource = students.StudentList;
        }
    }
}
