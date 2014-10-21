using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _04_StudentRegistration
{
    public partial class index : System.Web.UI.Page
    {

        private string[] universities = {
                                            "Technical University",
                                            "New Bulgarian University",
                                            "Sofia University",
                                            "Software Univeristy"
                                        };

        private string[] specialities = {
                                            "Design",
                                            "Programming",
                                            "Biology",
                                            "Mathematics",
                                        };
        private string[] courses = {
                                       "Game Level Design",
                                       "Character Design",
                                       "Layout Design",
                                       "Advanced Javascript",
                                       "Linear algebra",
                                       "DNA Analysis",
                                       "Human anatomy"
                                   };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            this.DropDownListUniversity.DataSource = universities;
            this.DropDownListSpeciality.DataSource = specialities;
            this.ListBoxCourses.DataSource = courses;

            this.DropDownListUniversity.DataBind();
            this.DropDownListSpeciality.DataBind();
            this.ListBoxCourses.DataBind();
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            AddNames();
            AddNumber();
            AddSpecialityAndUniversity();
            AddCourses();
        }

        private void AddCourses()
        {
            var selectedCourses = this.ListBoxCourses.Items.OfType<ListItem>().Where(item => item.Selected);
            var coursesField = new LiteralControl("<p>Courses:</p>");
            foreach (var course in selectedCourses)
            {
                coursesField.Text += "<span>" + course + " | " + "</span>";
            }

            this.PanelFeedBack.Controls.Add(coursesField);
        }

        private void AddSpecialityAndUniversity()
        {
            string specialty = this.DropDownListSpeciality.SelectedItem.Text;
            string university = this.DropDownListUniversity.SelectedItem.Text;

            var specUniField = new LiteralControl(
                                        "<span>" + specialty + "</span>" + " in " + university + "<br />");

            this.PanelFeedBack.Controls.Add(specUniField);
        }

        private void AddNumber()
        {
            string number = this.TextBoxFacultyNumber.Text;
            var facilityNumberField = new LiteralControl("<span>" + number + "</span>" + "<br /><br />");
            this.PanelFeedBack.Controls.Add(facilityNumberField);
        }

        private void AddNames()
        {
            string firstName = this.TextBoxFirstName.Text;
            string lastName = this.TextBoxLastName.Text;

            var heading = new LiteralControl();
            heading.Text = "<h4>" + firstName + " " + lastName + "</h4>";
            this.PanelFeedBack.Controls.Add(heading);
        }
    }
}