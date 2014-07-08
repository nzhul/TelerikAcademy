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
    /// Interaction logic for ChangeRankWindow.xaml
    /// </summary>
    public partial class ChangeRankWindow : Window
    {
        private Person person;
        BrushConverter bc;

        public ChangeRankWindow(Person person)
        {
            InitializeComponent();

            bc = new BrushConverter();
            this.person = person;
            if (person is Student)
            {
                List<StudentRank> _ranksList = new List<StudentRank>()
                {
                    StudentRank.Unknown,
                    StudentRank.Junior,
                    StudentRank.Senior,
                    StudentRank.Bachelor,
                    StudentRank.Master,
                    StudentRank.Doctor
                };
                rankComboBox.ItemsSource = _ranksList;
                rankComboBox.SelectedIndex = 0;
            }
            else
            {
                List<TeacherRank> _ranksList = new List<TeacherRank>()
                {
                    TeacherRank.Unknown,
                    TeacherRank.AssistantProfessor,
                    TeacherRank.AssociateProfessor,
                    TeacherRank.Professor,
                    TeacherRank.LecturerInstructor,
                    TeacherRank.VisitingProfessor,
                    TeacherRank.AdjunctProfessor
                };
                rankComboBox.ItemsSource = _ranksList;
                rankComboBox.SelectedIndex = 0;
            }
        }

        private void changeRank_MouseEnter(object sender, MouseEventArgs e)
        {           
            changeBtn.Background = (Brush)bc.ConvertFrom("#c3d3e8");
        }

        //Any ideas? ^ .^
        private void changeRank_MouseLeave(object sender, MouseEventArgs e)
        {        
            changeBtn.Background = (Brush)bc.ConvertFrom("#d7d7d7");          
        }

        private void changeBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (this.person is Student)
            {
                Student person = (Student)this.person;
                person.Rank = (StudentRank)rankComboBox.SelectedItem;
            }
            else
            {
                Teacher person = (Teacher)this.person;
                person.Rank = (TeacherRank)rankComboBox.SelectedItem;
            }
            this.Close();
        }      
    }
}
