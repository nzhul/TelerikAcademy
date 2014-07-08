using PersonModule.PersonDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamOOP.Utilities
{
    public static class CourseFactory
    {
        private static Dictionary<CourseName, Course> coursesList;
        
        static CourseFactory()
        {
            coursesList = new Dictionary<CourseName, Course>();
            coursesList.Add(CourseName.Algorithms, new Course(CourseName.Algorithms));
            coursesList.Add(CourseName.Chemistry, new Course(CourseName.Chemistry));
            coursesList.Add(CourseName.Cryptography, new Course(CourseName.Cryptography));
            coursesList.Add(CourseName.Design, new Course(CourseName.E_Commerce));
            coursesList.Add(CourseName.InternetTechnologies, new Course(CourseName.InternetTechnologies));
            coursesList.Add(CourseName.Mathematics, new Course(CourseName.Mathematics));
            coursesList.Add(CourseName.Multimedia, new Course(CourseName.Multimedia));
            coursesList.Add(CourseName.OperationalSystems, new Course(CourseName.OperationalSystems));
            coursesList.Add(CourseName.Physics, new Course(CourseName.Physics));
            coursesList.Add(CourseName.Unknown, new Course(CourseName.Unknown));
        }

        public static Course GetCourse(CourseName name)
        {
            return coursesList[name];
        }
        
    }
}
