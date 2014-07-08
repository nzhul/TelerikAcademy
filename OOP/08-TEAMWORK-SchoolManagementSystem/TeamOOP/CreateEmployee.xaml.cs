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
    /// Interaction logic for CreateEmployee.xaml
    /// </summary>
    public partial class CreateEmployee : Window
    {
        private EmployeesContainer _employeeContainer;
        public CreateEmployee(EmployeesContainer container)
        {
            InitializeComponent();
            _employeeContainer = container;
            List<Position> allPositions = new List<Position>();
            foreach (Position position in (Position[])Enum.GetValues(typeof(Position)))
            {
                allPositions.Add(position);
            }
            positionComboBox.ItemsSource = allPositions;
            positionComboBox.SelectedIndex = 1;
            List<ContractType> allContractTypes = new List<ContractType>();
            foreach (ContractType type in (ContractType[])Enum.GetValues(typeof(ContractType)))
            {
                allContractTypes.Add(type);
            }
            contractTypeComboBox.ItemsSource = allContractTypes;
            contractTypeComboBox.SelectedIndex = 1;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as Slider;
            double value = slider.Value;
            this.salaryValue.Text = " " + value.ToString("$0.0") + "/ $" + slider.Maximum;
        }

        private void addEmployee_MouseUp(object sender, MouseButtonEventArgs e)
        {
            string firstName = firstNameInput.Text;
            string lastName = lastNameInput.Text;
            string egn = egnInput.Text;
            Position position = (Position)positionComboBox.SelectedItem;
            ContractType type = (ContractType)contractTypeComboBox.SelectedItem;
            decimal salary = (decimal)SliderGrade.Value;
            int rating = 1;
            // Get the object with Max ID
            var maxIdEmEmployee = _employeeContainer.EmployeesList.Aggregate((seed, f) => f.Id > seed.Id ? f : seed); // IT is magic but works - don't know how, dont' touch it please :)
            int id = maxIdEmEmployee.Id + 1;
            Employee newEmployee;
            switch (position)
            {
                case Position.Unknown:
                    throw new ArgumentException("Please Select Valid Position Type");
                case Position.Principal:
                    newEmployee = new Principal(firstName, lastName, egn, type, id, salary, rating);
                    break;
                case Position.Administrator:
                    newEmployee = new Administrator(firstName, lastName, egn, type, id, salary, rating);
                    break;
                case Position.Teacher:
                    newEmployee = new Teacher(firstName, lastName, egn, type, id, salary, rating);
                    break;
                //case Position.Support:
                //    newEmployee = new Support(firstName, lastName, egn, type, id);
                //    break;
                case Position.Hygienist:
                    newEmployee = new Hygienist(firstName, lastName, egn, type, id, salary, rating);
                    break;
                default:
                    newEmployee = new Teacher(firstName, lastName, egn, type, id, salary, rating);
                    break;
            }
            _employeeContainer.Add(newEmployee);
            this.Close();
        }

        private void addEmployee_MouseEnter(object sender, MouseEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            addBtn.Background = (Brush)bc.ConvertFrom("#c3d3e8");
        }

        private void addEmployee_MouseLeave(object sender, MouseEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            addBtn.Background = (Brush)bc.ConvertFrom("#d7d7d7");
        }

    }
}
