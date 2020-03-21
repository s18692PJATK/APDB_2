using System;
using System.Xml.Serialization;

namespace tut_apdb2.models
{
    public class Student
    {
        [XmlAttribute(AttributeName = "index")]
        public string IndexNumber { get; set; }
        public string Email { get; set;}
        public string FirstName { get; set; }
        
        public Studies Studies { get; set; }
        
        
        public DateTime BirthDate { get; set; }
        
        public string FatherName { get; set; }
        public string MotherName { get; set; }

        private string _lastName;
        
        

        public string LastName
        {
            get => _lastName;
            set => _lastName = value ?? throw new ArgumentNullException();
        }


    }
}