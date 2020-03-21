using System;
using System.Collections.Generic;

namespace tut_apdb2.models
{
    public class PersonComparator: IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            return StringComparer
                .InvariantCultureIgnoreCase
                .Equals($"{x.IndexNumber} {x.Email} {x.FirstName} {x.LastName}",
                    $"{y.IndexNumber} {y.Email} {y.FirstName} {y.LastName}");
        }

        public int GetHashCode(Student obj)
        {
            return StringComparer.CurrentCultureIgnoreCase
                .GetHashCode($"{obj.IndexNumber}{obj.FirstName}{obj.LastName}{obj.Email}");
        }
    }
}