using PersonModule.PersonDefinitions;
using PersonModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamOOP.Utilities
{
    public interface ICourses
    {
        void AddCourse(Course course);
        void RemoveCourse(Course course);
    }
}
