using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destop
{
    public class Student
    {
       
            public string GPA { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public string Image { get; set; }

            public string Birthday { get; set; }
            public string Address { get; set; }

            public string ImageURL
            {
                get
                {
                    return $"/Images/{Image}";
                }
            }

            public Student(string gpa, string firstName, string lastName, string image, string birthday, string address)
            {
                GPA = gpa;
                FirstName = firstName;
                LastName = lastName;
                Image = image;
                Birthday = birthday;
                Address = address;
            }
            public Student() { }    
    }
}
