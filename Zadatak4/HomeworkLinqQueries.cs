using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak1;

namespace Zadatak4
{
    public class HomeworkLinqQueries
    {
        public static string[] Linq1(int[] intArray)
        {
            return intArray.GroupBy(i => i)
                            .Select(x => $"Broj {x.Key} ponavlja se {x.Count()} puta")
                            .OrderBy(i => i)
                            .ToArray();
        }

        public static University[] Linq2_1(University[] universityArray)
        {
            return universityArray.Where(u => u.Students.All(s => s.Gender == Gender.Male)).ToArray();

        }

        public static University[] Linq2_2(University[] universityArray)
        {
            double avg = universityArray.Average(u => u.Students.Length);
            return universityArray.Where(u => u.Students.Length < avg).ToArray();
        }

        public static Student[] Linq2_3(University[] universityArray)
        {
            return universityArray.SelectMany(u => u.Students).Distinct().ToArray();

        }

        public static Student[] Linq2_4(University[] universityArray)
        {
            return universityArray.Where(u => (u.Students.All(s => s.Gender == Gender.Male) || u.Students.All(s => s.Gender == Gender.Female)))
                .SelectMany(u => u.Students)
                .Distinct()
                .ToArray();
        }

        public static Student[] Linq2_5(University[] universityArray)
        {
            return universityArray.SelectMany(u => u.Students)
                .GroupBy(s => s)
                .Where(t => t.Count() >= 2)
                .Select(t => t.Key)
                .Distinct()
                .ToArray();
        }
    }

}
