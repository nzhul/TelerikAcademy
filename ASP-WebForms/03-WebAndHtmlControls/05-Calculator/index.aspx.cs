namespace _05.Calculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class Index : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void Button_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "")
            {
                this.TextBoxInput.Text += e.CommandArgument;
            }
            else if (e.CommandName == "equals")
            {
                Equals();
            }
            else
            {
                string firstOperand = this.HiddenFieldFirstOperand.Value;
                if (!string.IsNullOrEmpty(firstOperand))
                {
                    string input = this.TextBoxInput.Text;
                    double number;
                    if (!double.TryParse(input, out number))
                    {
                        this.Clear();
                        return;
                    }
                    this.HiddenFieldFirstOperand.Value = input;
                    this.TextBoxInput.Text = "";
                    return;
                }
                else if (e.CommandName == "squareRoot")
                {
                    double number = long.Parse(this.TextBoxInput.Text);
                    double result = Math.Sqrt(number);
                    this.HiddenFieldFirstOperand.Value = "";
                    this.TextBoxInput.Text = result.ToString();
                    return;
                }
                else
                {
                    switch (e.CommandName)
                    {
                        case "add":
                            this.HiddenFieldOperator.Value = "add";
                            break;
                        case "subtract":
                            this.HiddenFieldOperator.Value = "subtract";
                            break;
                        case "multiply":
                            this.HiddenFieldOperator.Value = "multiply";
                            break;
                        case "divide":
                            this.HiddenFieldOperator.Value = "divide";
                            break;
                        case "clear":
                            Clear();
                            break;
                        default:
                            break;
                    }

                    this.HiddenFieldFirstOperand.Value = this.TextBoxInput.Text;
                    this.TextBoxInput.Text = "";
                }
            }
        }

        private void Equals()
        {
            if (this.HiddenFieldOperator.Value == "")
            {
                return;
            }
            else
            {
                double firstOperand;
                double secondOperand;
                try
                {
                    firstOperand = double.Parse(this.HiddenFieldFirstOperand.Value);
                    secondOperand = double.Parse(this.TextBoxInput.Text);
                }
                catch (Exception)
                {
                    this.Clear();
                    return;
                }

                this.HiddenFieldFirstOperand.Value = "";
                double result = 0;
                switch (this.HiddenFieldOperator.Value)
                {
                    case "add":
                        result = firstOperand + secondOperand;
                        break;
                    case "subtract":
                        result = firstOperand - secondOperand;
                        break;
                    case "multiply":
                        result = firstOperand * secondOperand;
                        break;
                    case "divide":
                        result = firstOperand / secondOperand;
                        break;
                    default:
                        break;
                }

                this.TextBoxInput.Text = result.ToString();
            }
        }

        private void Clear()
        {
            this.HiddenFieldFirstOperand.Value = "";
            this.HiddenFieldOperator.Value = "";
            this.TextBoxInput.Text = "";
        }
    }
}