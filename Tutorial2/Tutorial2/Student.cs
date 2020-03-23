using System.Xml.Serialization;

namespace Tutorial2
{
    public class Student
    {
        [XmlElement(ElementName = "fname")]
        public string FirstName { get; set; }
        [XmlAttribute()]
        public string LastName { get; set; }
        public string sNumber { get; set; }
    }
}