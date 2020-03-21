using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace tut_apdb2.models
{
    public class MyXmlSerializer : ISerializer

    {
        private XmlSerializer _serializer;
        public void serializeStudents(IEnumerable<Student> students,FileStream writer)
        {
            _serializer = new XmlSerializer(typeof(HashSet<Student>),new XmlRootAttribute("university"));
            _serializer.Serialize(writer,students);
        }

       
    }
}