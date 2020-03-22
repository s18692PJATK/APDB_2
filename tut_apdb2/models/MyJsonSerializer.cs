using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace tut_apdb2.models
{
    public class MyJsonSerializer : ISerializer
    {
        public void serializeStudents(IEnumerable<Student> students, FileStream writer)
        {
            var jsonString = JsonSerializer.Serialize(students);
            var bytes = Encoding.ASCII.GetBytes(jsonString);
            writer.Write(bytes);
        }

        public void serializeStudies(IEnumerable<ActiveStudies> studies, FileStream writer)
        {
            var jsonString = JsonSerializer.Serialize(studies);
            var bytes = Encoding.ASCII.GetBytes(jsonString);
            writer.Write(bytes);
        }
    }
}
      