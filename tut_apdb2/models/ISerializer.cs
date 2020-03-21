using System.Collections.Generic;
using System.IO;

namespace tut_apdb2.models
{
    public interface ISerializer
    {
        public void serializeStudents(IEnumerable<Student> students, FileStream writer);
        public void serializeStudies(IEnumerable<ActiveStudies> studies, FileStream writer);

    }
}