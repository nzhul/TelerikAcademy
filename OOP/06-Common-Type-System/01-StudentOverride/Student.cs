namespace StudentOverride
{
    using System;
    using System.Text.RegularExpressions;
    public class Student : Person
    {
        // Adress; Email; GSM; 
        // University; Faculty; Speciality;

        // Properties
        private string _adress;

        public string Adress
        {
            get { return _adress; }
            set { _adress = value; }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set {
                string regex = @"[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z]{2,4}";
                if (Regex.IsMatch(value, regex))
                {
                    this._email = value;
                }
                else
                {
                    throw new ArgumentException("Invalid email!");
                }
                
            }
        }

        private string _gSM;

        public string GSM
        {
            get { return this._gSM; }
            set { this._gSM = value; }
        }

        private Universities? _university;

        public Universities? University
        {
            get { return this._university; }
            set { this._university = value; }
        }

        private Faculties? _faculty;

        public Faculties? Faculty
        {
            get { return this._faculty; }
            set { this._faculty = value; }
        }
        
        
        
        



        
        
        
    }
}
