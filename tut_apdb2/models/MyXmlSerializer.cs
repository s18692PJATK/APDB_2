using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace tut_apdb2.models
{
    public class MyXmlSerializer : ISerializer

    {
        private XmlSerializer _serializerStudent;
        private XmlSerializer _serializerStudies;
        public void serializeStudents(IEnumerable<Student> students,FileStream writer)
        {
            _serializerStudent = new XmlSerializer(typeof(HashSet<Student>),new XmlRootAttribute("university"));
            _serializerStudent.Serialize(writer,students);
        }

        public void serializeStudies(IEnumerable<ActiveStudies> studies, FileStream writer)
        {
            _serializerStudies = new XmlSerializer(typeof(HashSet<ActiveStudies>), new XmlRootAttribute("university"));
            _serializerStudies.Serialize(writer,studies);
        }
    }
}