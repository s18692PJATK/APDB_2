using System.Collections.Generic;
using System.IO;

namespace tut_apdb2.models
{
    public interface ISerializer
    {
        public void serializeStudents(IEnumerable<Student> students, FileStream writer);
        
    }
}