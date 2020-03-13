using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Serialization;

namespace Cw2.Models
{
    [XmlRootAttribute("uczelnia")]
    public class Uczelnia
    {
        [XmlAttribute] 
        public string createdAt = DateTime.Today.ToShortDateString();
        
        [XmlAttribute] 
        public string author = "Arkadiusz Pańczyk";
        
        public HashSet<Student> studenci { get; set; }
        public List<ActiveStudies> activeStudies { get; set; }
    }
}