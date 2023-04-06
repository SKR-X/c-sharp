using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class student
    {
        public int[] marks = new int[5];
        public string fam;
        public double sr;
        public student(int[] inputMarks, string inputFam)
        {
            marks = inputMarks;
            fam = inputFam;
        }
    }

    class goodStudent : student
    {
        public double amount = 1500;
        public goodStudent(int[] inputMarks, string inputFam) : base(inputMarks, inputFam)
        {
            marks = inputMarks;
            fam = inputFam;
        }
    }

    class bestStudent : goodStudent
    { 
        public void getAmount()
        {
            amount = amount + amount / 2;
        }
        public bestStudent(int[] inputMarks, string inputFam) : base(inputMarks, inputFam)
        {
            marks = inputMarks;
            fam = inputFam;
            getAmount();
        }
    }


    internal class Program
    {

        static List<student> removeUnA(List<student> students)
        {
            for (int i = 0; i < students.Count; i++)
            {
                for (int j = 0; j < students[i].marks.Length; j++)
                {
                    if (students[i].marks[j] == 2)
                    {
                        students.RemoveAt(i);
                        break;
                    }
                }
            }
            return students;
        }

        static List<student> getSrMarks(List<student> students)
        {
            for (int i = 0; i < students.Count; i++)
            {
                double sr = students[i].marks[0];
                for (int j = 1; j < students[i].marks.Length; j++)
                {
                    sr += students[i].marks[j];
                }
                sr = sr / students[i].marks.Length;
                students[i].sr = sr;
            }

            return students;
        }

        static List<student> sortStudents(List<student> students)
        {
            for (int i = 0; i < students.Count-1; i++)
            {
                for (int j = i; j < students.Count; j++)
                {
                    if (students[i].sr > students[j].sr)
                    {
                        student temp = students[i];
                        students[i] = students[j];
                        students[j] = temp;
                    }
                }
            }
            return students;
        }

        static void showList(List<student> students)
        {
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"Фамилия: {students[i].fam} Сред. Балл: {students[i].sr}");
            }
        }
        
        static void getMarksInfo(List<student> students)
        {
            int a = 0, b = 0, c = 0;
            for (int i = 0; i < students.Count; i++)
            {
                if ((students[i].sr>4 && students[i].sr < 5) && (students[i].sr >= 4.5))
                {
                    a++;
                    bestStudent bs = new bestStudent(students[i].marks, students[i].fam);
                    Console.WriteLine($"{bs.fam} Имеет стипендию: {bs.amount}р");
                } else if ((students[i].sr> 3 && students[i].sr < 4.5) && (students[i].sr >= 3.5))
                {
                    b++;
                    goodStudent gs = new goodStudent(students[i].marks, students[i].fam);
                    Console.WriteLine($"{gs.fam} Имеет стипендию: {gs.amount}р");
                } else if ((students[i].sr> 2 && students[i].sr < 3.5) && (students[i].sr >= 2.5))
                {
                    c++;
                    Console.WriteLine($"{students[i].fam} Имеет стипендию: 0р");
                }
            }

            Console.WriteLine($"Отличники: {a}");
            Console.WriteLine($"Хорошисты: {b}");
            Console.WriteLine($"Троечники: {c}");
        }
        static void Main(string[] args)
        {
            List<student> students = new List<student>();
            string path = @"C:\Users\SKR-X\Desktop\text.txt";
            StreamReader sr = new StreamReader(path);
            string line = sr.ReadLine();
            while (line != null)
            {
                students.Add(new student(new int[5] { int.Parse(line.Split(' ')[0]), int.Parse(line.Split(' ')[1]), int.Parse(line.Split(' ')[2]), int.Parse(line.Split(' ')[3]), int.Parse(line.Split(' ')[4]) }, line.Split(' ')[5]));
                line = sr.ReadLine();
            }

            students = removeUnA(students);
            
            List<student> bestMarks = new List<student>();
            List<student> goodMarks = new List<student>();
            List<student> okMarks = new List<student>();

            students = getSrMarks(students);

            students = sortStudents(students);

            showList(students);

            getMarksInfo(students);



            Console.ReadLine();

        }
    }
}


//text.txt
/*
3 5 5 5 5 Ivanov	
2 4 4 4 4 Sidorov
3 4 5 5 5 Makarov
2 5 5 5 5 Tereshkin
*/
