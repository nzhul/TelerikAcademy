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
    /// Interaction logic for AddGradeWindow.xaml
    /// </summary>
    public partial class AddGradeWindow : Window
    {
        private Student _student;
        public AddGradeWindow(Student student)
        {
            InitializeComponent();
            _student = student;
            courseComboBox.ItemsSource = _student.CoursesList;
            courseComboBox.SelectedIndex = 0;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as Slider;
            double value = slider.Value;
            this.gradeValue.Text = " " + value.ToString("0.0") + "/" + slider.Maximum;
        }

        private void addGrade_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Course courseEnum = (Course)courseComboBox.SelectedItem;
            double grade = SliderGrade.Value;
            _student.AddGrade(new Grade(grade, courseEnum));
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
