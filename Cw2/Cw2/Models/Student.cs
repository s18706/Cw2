using System.Xml.Serialization;

namespace Cw2.Models
{
    [XmlType("student")]
    public class Student
    {
        
        [XmlAttribute] 
        public string indexNumber { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string birthdate { get; set; }
        public string email { get; set; }
        public string mothersName { get; set; }
        public string fathersName { get; set; }
        public Studies studies { get; set; }
    }
}