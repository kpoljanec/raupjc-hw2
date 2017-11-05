﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak1
{
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }
        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public override bool Equals(object obj)
        {
            if(obj is null)
            {
                return false;
            }

            if(obj.GetType() != this.GetType())
            {
                return false;
            }
            Student tmp = (Student)obj;

            return tmp.Jmbag == this.Jmbag;
            
        }

        public static bool operator== (Student s1, Student s2)
        {
            return s1.Jmbag == s2.Jmbag;
        }

        public static bool operator!= (Student s1, Student s2)
        {
            return !(s1.Jmbag == s2.Jmbag);
        }

        public override int GetHashCode()
        {
            return Jmbag.GetHashCode();
        }
    }

    

    public enum Gender
    {
        Male, Female
    }
}
