using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Cw2.Models
{
    [XmlType("student")]
    public class Student
    {
        
        [XmlAttribute] 
        public string indexNumber
        {
            get { return _indexNumber; }
            set { _indexNumber = "s" + value; }
        }
        private string _indexNumber;
        public string fname { get; set; }
        public string lname
        {
            get { return _lname; }
            set { _lname = Regex.Replace(value, @"[\d-]", string.Empty); }
        }
        private string _lname;
        public string birthdate { get; set; }
        public string email { get; set; }
        public string mothersName { get; set; }
        public string fathersName { get; set; }
        public Studies studies { get; set; }

        public Student(string[] data)
        {
            indexNumber = data[4];
            fname = data[0];
            lname = data[1];
            birthdate = data[5];
            email = data[6];
            mothersName = data[7];
            fathersName = data[8];
            studies = new Studies
            {
                name = data[2].Replace(data[3].ToLower(), ""),
                mode = data[3]
            };
        }

        public Student()
        {
        }
    }
}