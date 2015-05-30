using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problems
{
    class Problems
    {
        static void Main(string[] args)
        {
            List<int> marksSara = new List<int>();
            List<int> marksDaniel = new List<int>();
            List<int> marksAaron = new List<int>();
            List<int> marksMildred = new List<int>();
            List<int> marksAntonio = new List<int>();
            List<int> marksCheryl = new List<int>();
            List<int> marksCraig = new List<int>();

            MarksGenerator(marksSara);
            MarksGenerator(marksDaniel);
            MarksGenerator(marksAaron);
            MarksGenerator(marksMildred);
            MarksGenerator(marksAntonio);
            MarksGenerator(marksCheryl);
            MarksGenerator(marksCraig);

            var students = new Student[]
            {
                new Student("Sara", "Mills", 24, 143212, "0885234546", "smills0@marketwatch.com", marksSara, 4),
                new Student("Daniel", "Carter", 26, 145212, "+359885273546", "dcarter1@buzzfeed.com", marksDaniel, 1),
                new Student("Aaron", "Gibson", 21, 253214, "029234546", "agibson2@house.gov", marksAaron, 2),
                new Student("Mildred", "Hansen", 22, 156412, "046634577", "mhansen4@skype.com", marksMildred, 2),
                new Student("Antonio", "Gonzalez", 18, 311115, "+3592865223", "agonzalez5@zdnet.com", marksAntonio, 3),
                new Student("Cheryl", "Gray", 24, 213211, "0885765436", "cgray6@abv.bg", marksCheryl, 4),
                new Student("Craig", "King", 27, 113414, "0873245546", "cking7@abv.bg", marksCraig, 1)
            };

            var studentSpecialties = new StudentSpecialty[]
            {
                new StudentSpecialty("Web Developer", 143212),
                new StudentSpecialty("PHP Developer", 145212),
                new StudentSpecialty("Web Developer", 253214),
                new StudentSpecialty("QA Engineer", 156412),
                new StudentSpecialty("QA Engineer", 311115),
                new StudentSpecialty("Web Developer", 213211),
                new StudentSpecialty("Web Developer", 113414)
            };

            Problem2PrintStudentsByGroup(students);
            Problem3PrintStudentsByFirstAndLastName(students);
            Problem4PrintStudentsByAge(students);
            Problem5aSortStudentsLambda(students);
            Problem5bSortStudentsQuery(students);
            Problem6FilterStudentsByEmailDomain(students);
            Problem7FilterStudentsByPhone(students);
            Problem8PrintExcellentStudents(students);
            Problem9PrintWeakStudents(students);
            Problem10PrintMarksOfStudentsEnrolledIn2014(students);
            Problem11PrintStudentsByGroups(students);
            Problem12StudentsJoinedToSpecialties(students, studentSpecialties);
        }

        static void MarksGenerator(List<int> marks)
        {
            Random rand = new Random();
            for (int i = 0; i < 6; i++)
			{
			    marks.Add(rand.Next(2, 7));
			}
        }

        static void Problem2PrintStudentsByGroup(Student[] students)
        {
            //Print all students from group number 2. Use a LINQ query. Order the students by FirstName.
            Console.WriteLine("Problem2");
            Console.WriteLine("---------------------");
            var studentsFromGroup2 = students.Where(student => student.GroupNumber == 2)
                                             .OrderBy(student => student.FirstName);
            foreach (var student in studentsFromGroup2)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
            Console.WriteLine("---------------------");
        }

        static void Problem3PrintStudentsByFirstAndLastName(Student[] students)
        {
            //Print all students whose first name is before their last name alphabetically. Use a LINQ query.
            var studentsByFirstAndLastName = students.Where(student => String.Compare(student.FirstName, student.LastName, false) == -1);
            Console.WriteLine("Problem3");
            Console.WriteLine("---------------------");
            foreach (var student in studentsByFirstAndLastName)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
            Console.WriteLine("---------------------");
        }

        static void Problem4PrintStudentsByAge(Student[] students)
        {
            //Write a LINQ query that finds the first name and last name of all students with age between 18 and 24. 
            //The query should return only the first name, last name and age.
            var studentsByAge = students.Where(student => student.Age >= 18 && student.Age <= 24)
                                        .Select(student => new { student.FirstName, student.LastName, student.Age });
            Console.WriteLine("Problem4");
            Console.WriteLine("---------------------");
            foreach (var student in studentsByAge)
            {
                Console.WriteLine("{0} {1} {2}", student.FirstName, student.LastName, student.Age);
            }
            Console.WriteLine("---------------------");
        }

        static void Problem5aSortStudentsLambda(Student[] students)
        {
            //Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by 
            //first name and last name in descending order. Rewrite the same with LINQ query syntax.
            var sortedStudents = students.OrderByDescending(student => student.FirstName)
                                         .ThenByDescending(student => student.LastName);
            Console.WriteLine("Problem5a");
            Console.WriteLine("---------------------");
            foreach (var student in sortedStudents)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
            Console.WriteLine("---------------------");
        }

        static void Problem5bSortStudentsQuery(Student[] students)
        {
            //Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by 
            //first name and last name in descending order. Rewrite the same with LINQ query syntax.
            var sortedStudents =
                from student in students
                orderby student.LastName descending
                orderby student.FirstName descending
                select student;
            Console.WriteLine("Problem5b");
            Console.WriteLine("---------------------");
            foreach (var student in sortedStudents)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
            Console.WriteLine("---------------------");
        }

        static void Problem6FilterStudentsByEmailDomain(Student[] students)
        {
            //Print all students that have email @abv.bg. Use LINQ.
            var studentsWithAbvDomain = students.Where(student => student.Email.Contains("abv.bg"));
            Console.WriteLine("Problem6");
            Console.WriteLine("---------------------");
            foreach (var student in studentsWithAbvDomain)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
            Console.WriteLine("---------------------");
        }

        static void Problem7FilterStudentsByPhone(Student[] students)
        {
            //Print all students with phones in Sofia (starting with 02 / +3592 / +359 2). Use LINQ.
            string pattern1 = @"^02\s*";
            Regex rgx1 = new Regex(pattern1);
            string pattern2 = @"^\+359\s*2";
            Regex rgx2 = new Regex(pattern2);
            var studentsFromSofia = students.Where(student => rgx1.IsMatch(student.Phone) || rgx2.IsMatch(student.Phone));
            Console.WriteLine("Problem7");
            Console.WriteLine("---------------------");
            foreach (var student in studentsFromSofia)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
            Console.WriteLine("---------------------");
        }

        static void Problem8PrintExcellentStudents(Student[] students)
        {
            //Print all students that have at least one mark Excellent (6). 
            //Using LINQ first select them into a new anonymous class that holds { FullName + Marks}.
            var excellentStudents = students.Where(student => student.Marks.Contains(6))
                                            .Select(student => new { FullName = student.FirstName + " " + student.LastName, student.Marks });
            Console.WriteLine("Problem8");
            Console.WriteLine("---------------------");
            if (excellentStudents.Count() == 0)
            {
                Console.WriteLine("There is no excellent students");
            }
            else
            {
                foreach (var student in excellentStudents)
                {
                    Console.WriteLine("{0}: {1}", student.FullName, String.Join(", ", student.Marks));
                }
            }
            Console.WriteLine("---------------------");
        }

        static void Problem9PrintWeakStudents(Student[] students)
        {
            //Write a similar program to the previous one to extract the students with exactly two marks "2". Use extension methods.
            var weakStudents = students.Where(student => student.Marks.TwoBadMarks())
                                       .Select(student => new { FullName = student.FirstName + " " + student.LastName, student.Marks });
            Console.WriteLine("Problem9");
            Console.WriteLine("---------------------");
            if (weakStudents.Count() == 0)
            {
                Console.WriteLine("There is no weak students");
            }
            else
            {
                foreach (var student in weakStudents)
                {
                    Console.WriteLine("{0}: {1}", student.FullName, String.Join(", ", student.Marks));
                }
            }
            Console.WriteLine("---------------------");
        }

        static void Problem10PrintMarksOfStudentsEnrolledIn2014(Student[] students)
        {
            //Extract and print the Marks of the students that enrolled in 2014 
            //(the students from 2014 have 14 as their 5-th and 6-th digit in the FacultyNumber).
            var studentsOf2014 = students.Where(student => student.FacultyNumber.IsThereStudentsOf2014());
            Console.WriteLine("Problem10");
            Console.WriteLine("---------------------");
            if (studentsOf2014.Count() == 0)
            {
                Console.WriteLine("There is no weak students");
            }
            else
            {
                foreach (var student in studentsOf2014)
                {
                    Console.WriteLine("{0} {1}: {2}", student.FirstName, student.LastName, String.Join(", ", student.Marks));
                }
            }
            Console.WriteLine("---------------------");
        }

        static void Problem11PrintStudentsByGroups(Student[] students)
        {
            //Write a program that extracts all students grouped by GroupName and then prints them on the console. 
            //Print all group names along with the students in each group. Use the "group by into" LINQ operator.
            var groupedStudents =
                from student in students
                group student by student.GroupNumber;
            Console.WriteLine("Problem11");
            Console.WriteLine("---------------------");
            foreach (var group in groupedStudents)
            {
                Console.WriteLine(group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
                }
            }
            Console.WriteLine("---------------------");
        }

        static void Problem12StudentsJoinedToSpecialties(Student[] students, StudentSpecialty[] studentSpecialties)
        {
            //Write a program that extracts all students grouped by GroupName and then prints them on the console. 
            //Print all group names along with the students in each group. Use the "group by into" LINQ operator.
            var specialties =
                from student in students
                join specialty in studentSpecialties on student.FacultyNumber equals specialty.FacultyNumber
                orderby student.FirstName
                select new { student.FirstName, student.LastName, student.FacultyNumber, specialty.SpecialtyName };
            Console.WriteLine("Problem12");
            Console.WriteLine("---------------------");
            foreach (var student in specialties)
            {
                Console.WriteLine("{0} {1} {2} {3}", student.FirstName, student.LastName, student.FacultyNumber, student.SpecialtyName);
            }
            Console.WriteLine("---------------------");
        }
    }
}
