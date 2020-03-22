using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace tut_apdb2.models
{
    public class MyXmlSerializer : ISerializer

    {
        private XmlSerializer _serializer;
        public void serializeStudents(IEnumerable<Object> students,FileStream writer)
        {
            _serializer = new XmlSerializer(typeof(HashSet<Object>),new XmlRootAttribute("university"));
            _serializer.Serialize(writer,students);
        }

        public void serializeStudies(IEnumerable<object> studies, FileStream writer)
        {
            _serializer.Serialize(writer,studies);
        }
    }
}