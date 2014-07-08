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
    /// <summary>
    /// Interaction logic for CreateStudentWindow.xaml
    /// </summary>
    public partial class CreateStudentWindow : Window
    {
        private StudentsContainer _studentContainer;
        public CreateStudentWindow(StudentsContainer container)
        {
            InitializeComponent();
            _studentContainer = container;
        }

        private void addStudent_MouseUp(object sender, MouseButtonEventArgs e)
        {
            string firstName = firstNameInput.Text;
            string lastName = lastNameInput.Text;
            string egn = egnInput.Text;
            int facultyNumber = int.Parse(facultyInput.Text);
            _studentContainer.Add(new Student(firstName,lastName, egn, facultyNumber, StudentRank.Junior));
            this.Close();
        }

        private void addStudent_MouseEnter(object sender, MouseEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            addBtn.Background = (Brush)bc.ConvertFrom("#c3d3e8");
        }

        private void addStudent_MouseLeave(object sender, MouseEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            addBtn.Background = (Brush)bc.ConvertFrom("#d7d7d7");
        }
    }
}
