using System;
using System.Collections.Generic;
 
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace TutorialSolution2
{

    [XmlRoot("university")]
    [XmlInclude(typeof(Student))]
    [Serializable]
    class University
    {
        [XmlAttribute("createdAt")]
        [JsonPropertyName("createdAt")]
        public string CreatedAt { get; set; }
        [XmlAttribute("author")]
        [JsonPropertyName("author")]
        public string Author { get; set; }
        [XmlArrayAttribute("students")]
        [JsonPropertyName("students")]
        public List<Student> Students { get; set; }
    }
}
