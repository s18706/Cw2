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
                .Equals($"{x.fname} {x.lname} {x.indexNumber}",
                    $"{y.fname} {y.lname} {y.indexNumber}");
        }

        public int GetHashCode(Student obj)
        {
            return StringComparer
                .CurrentCultureIgnoreCase
                .GetHashCode($"{obj.fname} {obj.lname} {obj.indexNumber}");
        }
    }
}