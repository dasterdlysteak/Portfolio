using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment02;

namespace DotNetDoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Course PRG517 = new Course("PRG517", "Programming", 2500.00); 
            DoublyLinkedList<Student> list = new DoublyLinkedList<Student>();
            list.Add(new Student("Jesse", "jessehamilton@gmail.com", "0431811047", "programming", new DateTime(2023, 05, 22), "12", "methodist st", "Willunga", "3530", "SA", new DateTime(2023, 05, 23), "distinction", "S1"));
            list.Add(new Student("John", "johnjones@gmail.com", "0431911084", "programming", new DateTime(2023, 05, 23), "12", "methodist st", "Willunga", "3530", "SA", new DateTime(2023, 05, 23), "distinction", "S1"));
            list.Add(new Student("James", "jessehamiltonyoung@gmail.com", "0431811047", "programming", new DateTime(2023, 05, 22), "12", "methodist st", "Willunga", "3530", "SA", new DateTime(2023, 05, 23), "distinction", "S1"));
            list.Add(new Student("Jillian", "jessen@gmail.com", "04318110887", "programming", new DateTime(2023, 05, 22), "12", "methodist st", "Willunga", "3530", "SA", new DateTime(2023, 05, 23), "distinction", "S1"));


            foreach (Student value in list)
            {
                Console.WriteLine(value.GetHashCode());

            }
            Console.WriteLine(list.Count());
            Console.ReadLine();

            Utility tools = new Utility();
            tools.DoubleBubbleSortASC<Student>(list);
            
            foreach (Student value in list)
            {
                Console.WriteLine(value.GetHashCode());

            }

            Console.ReadLine();
            tools.DoubleBubbleSortDESC<Student>(list);

            foreach (Student value in list)
            {
                Console.WriteLine(value.GetHashCode());
            }
            Console.ReadLine();

            Assignment02.LinkedList<Student> list2 = new Assignment02.LinkedList<Student>();
            list2.Add(new Student("Jesse", "jessehamilton@gmail.com", "0431811047", "programming", new DateTime(2023, 05, 22), "12", "methodist st", "Willunga", "3530", "SA", new DateTime(2023, 05, 23), "distinction", "S1"));
            list2.Add(new Student("John", "johnjones@gmail.com", "0431911084", "programming", new DateTime(2023, 05, 23), "12", "methodist st", "Willunga", "3530", "SA", new DateTime(2023, 05, 23), "distinction", "S1"));
            list2.Add(new Student("James", "jessehamilton-young@gmail.com", "0431811047", "programming", new DateTime(2023, 05, 22), "12", "methodist st", "Willunga", "3530", "SA", new DateTime(2023, 05, 23), "distinction", "S1"));
            list2.Add(new Student("Jillian", "jessen@gmail.com", "04318110887", "programming", new DateTime(2023, 05, 22), "12", "methodist st", "Willunga", "3530", "SA", new DateTime(2023, 05, 23), "distinction", "S1"));
            foreach (Student value in list2)
            {
                Console.WriteLine(value.GetHashCode());

            }

            Console.ReadLine();
            tools.SingleBubbleSortASC<Student>(list2);

            foreach (Student value in list2)
            {
                Console.WriteLine(value.GetHashCode());

            }
            Console.ReadLine();
            tools.SingleBubbleSortDESC<Student>(list2);

            foreach (Student value in list2)
            {
                Console.WriteLine(value.GetHashCode());
            }
            Console.ReadLine();

            foreach (Student value in list)
            {
                Console.WriteLine(value.GetHashCode());

            }

            Console.ReadLine();

            Student jillian = new Student("Jillian", "jessen@gmail.com", "04318110887", "programming", new DateTime(2023, 05, 22), "12", "methodist st", "Willunga", "3530", "SA", new DateTime(2023, 05, 23), "distinction", "S1");
            tools.DoubleBubbleSortASC<Student>(list);
            tools.SingleBubbleSortASC<Student>(list2);
            DoublyLinkedListNode<Student> jj = tools.DoubleBinarySearch<Student>(list, jillian);
            DoublyLinkedListNode<Student> oj = tools.DoubleSequentialSearch<Student>(list, jillian);
            Console.WriteLine(jj.Value);
            Console.ReadLine();
            Console.WriteLine(oj.Value);
            Console.ReadLine();
            Student dj = tools.SingleBinarySearch<Student>(list2, jillian);
            Console.WriteLine(dj);
            Console.ReadLine();
            jillian.Enrollment.AddCourse(PRG517);
            Console.WriteLine(jillian);
            Console.ReadLine();
            List<Student> students = new List<Student>();
            students.Add(new Student("Jesse", "jessehamilton@gmail.com", "0431811047", "programming", new DateTime(2023, 05, 22), "12", "methodist st", "Willunga", "3530", "SA", new DateTime(2023, 05, 23), "distinction", "S1"));
            students.Add(new Student("Anthony", "johnjones@gmail.com", "0431911084", "programming", new DateTime(2023, 05, 23), "12", "methodist st", "Willunga", "3530", "SA", new DateTime(2023, 05, 23), "distinction", "S1"));
            students.Add(new Student("James", "jessehamilton-young@gmail.com", "0431811047", "programming", new DateTime(2023, 05, 22), "12", "methodist st", "Willunga", "3530", "SA", new DateTime(2023, 05, 23), "distinction", "S1"));
            students.Add(new Student("Jillian", "jessen@gmail.com", "04318110887", "programming", new DateTime(2023, 05, 22), "12", "methodist st", "Willunga", "3530", "SA", new DateTime(2023, 05, 23), "distinction", "S1"));

            foreach (Student student in students)
            {
                Console.WriteLine(student + "\n");
            }

            students.Sort((s1, s2) => s1.Name.CompareTo(s2.Name));
            foreach(Student student in students)
            {
                Console.WriteLine(student);
            }
            Console.ReadLine();
        }
    }
}
