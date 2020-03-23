using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Tutorial2
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student(FurstName = "1", LastName = "2", sNumber = "");
            FileStream writer = new FileStream(@"data.xml", FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
           
            serializer.Serialize(writer, student);
        }
    }
}