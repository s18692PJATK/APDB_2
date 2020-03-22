using System;
using System.Collections.Generic;
using System.IO;

namespace tut_apdb2.models
{
    public interface ISerializer
    {
        public void serializeStudents(IEnumerable<Object> students, FileStream writer);
        public void serializeStudies(IEnumerable<Object> studies, FileStream writer);

    }
}