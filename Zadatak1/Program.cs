using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak1
{
    class Program
    {
        static void Main(string[] args)
        {

            //first test
            var topStudents = new List<Student>()
            {
                new Student ("Ivan", jmbag :"001234567") ,
                new Student ("Luka", jmbag :"3274272") ,
                new Student ("Ana", jmbag :"9382832")
            };

            var ivan = new Student("Ivan", jmbag: "001234567");
            // false :(
            bool isIvanTopStudent = topStudents.Contains(ivan);

            //second test
            var list = new List<Student>()
            {
                new Student ("Ivan", jmbag :"001234567") ,
                new Student ("Ivan", jmbag :"001234567")
            };
            // 2 :(
            var distinctStudentsCount = list.Distinct().Count();

            //third test
            bool isIvanTopStudent1 = topStudents.Any(s => s == ivan);

            Console.WriteLine(isIvanTopStudent); //true
            Console.WriteLine(distinctStudentsCount); //1
            Console.WriteLine(isIvanTopStudent1); //true


            Console.ReadLine();
        }
    }
}
