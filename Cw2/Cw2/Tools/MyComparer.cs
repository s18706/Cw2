using System;
using System.Collections.Generic;
using Cw2.Models;

namespace Cw2.Tools
{
    public class MyComparer : IEqualityComparer<Student>
    {

        public bool Equals(Student x, Student y)
        {
            return StringComparer
                .InvariantCultureIgnoreCase
                .Equals($"{x.FirstName} {x.LastName} {x.Index}",
                    $"{y.FirstName} {y.LastName} {y.Index}");
        }

        public int GetHashCode(Student obj)
        {
            return StringComparer
                .CurrentCultureIgnoreCase
                .GetHashCode($"{obj.FirstName} {obj.LastName} {obj.Index}");
        }
    }
}