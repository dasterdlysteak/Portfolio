using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Assignment02;



namespace Assignment02UnitTest
{
    [TestFixture]
    public class Assignment02Tests
    {
        public Assignment02.LinkedList<Student> list;
        public Student s1;
        public Student s2;
        public Utility tools;
        [OneTimeSetUp]
        public void Init()
        {
            s1 = new Student("Jesse", "jessehamilton@gmail.com", "0431811047", "programming", new DateTime(2023, 05, 22), "12", "methodist st", "Willunga", "3530", "SA", new DateTime(2023, 05, 23), "distinction", "S1");
            s2 = new Student("Anabelle", "Abell@gmail.com", "0439871047", "algebra", new DateTime(2023, 05, 30), "15", "colonic st", "salsbury", "3500", "SA", new DateTime(2023, 05, 30), "distinction", "S1");


            list = new Assignment02.LinkedList<Student>();
            list.Add(new Student("John", "johnjones@gmail.com", "0431911084", "programming", new DateTime(2023, 05, 23), "12", "methodist st", "Willunga", "3530", "SA", new DateTime(2023, 05, 23), "distinction", "S1"));
            list.Add(new Student("James", "jessehamiltonyoung@gmail.com", "0431811047", "programming", new DateTime(2023, 05, 22), "12", "methodist st", "Willunga", "3530", "SA", new DateTime(2023, 05, 23), "distinction", "S1"));
            list.Add(new Student("Jillian", "jessen@gmail.com", "04318110887", "programming", new DateTime(2023, 05, 22), "12", "methodist st", "Willunga", "3530", "SA", new DateTime(2023, 05, 23), "distinction", "S1"));

            tools = new Utility();
        }
        [Test]
        public void addFirst()
        {
            list.AddFirst(s1);
            Assert.AreEqual(s1, list.Head.Value);
            //list.RemoveFirst();
            

        }
        
        [Test]
        public void addLast()
        {
            list.AddLast(s2);
            Assert.AreEqual(s2, list.Tail.Value);
            //list.RemoveLast();
            
        }
        [Test]
        public void find()
        {
            //list.AddLast(s2);

            Assert.IsTrue(list.Contains(s2));
            //list.RemoveLast();
        }
        [Test]
        public void removeFirst()
        {
            //list.AddFirst(s1);
            list.RemoveFirst();
            Assert.AreNotEqual(s1, list.Head.Value);
        }
        [Test]
        public void removeLast()
        {
            //list.AddLast(s2);
            list.RemoveLast();
            Assert.AreNotEqual(s2, list.Tail.Value);

        }
    }
    public class DoublyLinkedListTests
    {
        public Assignment02.DoublyLinkedList<Student> list;
        public Student s1;
        public Student s2;
        public Utility tools;
        [OneTimeSetUp]
        public void Init()
        {
            s1 = new Student("Jesse", "jessehamilton@gmail.com", "0431811047", "programming", new DateTime(2023, 05, 22), "12", "methodist st", "Willunga", "3530", "SA", new DateTime(2023, 05, 23), "distinction", "S1");
            s2 = new Student("Anabelle", "Abell@gmail.com", "0439871047", "algebra", new DateTime(2023, 05, 30), "15", "colonic st", "salsbury", "3500", "SA", new DateTime(2023, 05, 30), "distinction", "S1");


            list = new Assignment02.DoublyLinkedList<Student>();
            list.Add(new Student("John", "johnjones@gmail.com", "0431911084", "programming", new DateTime(2023, 05, 23), "12", "methodist st", "Willunga", "3530", "SA", new DateTime(2023, 05, 23), "distinction", "S1"));
            list.Add(new Student("James", "jessehamiltonyoung@gmail.com", "0431811047", "programming", new DateTime(2023, 05, 22), "12", "methodist st", "Willunga", "3530", "SA", new DateTime(2023, 05, 23), "distinction", "S1"));
            list.Add(new Student("Jillian", "jessen@gmail.com", "04318110887", "programming", new DateTime(2023, 05, 22), "12", "methodist st", "Willunga", "3530", "SA", new DateTime(2023, 05, 23), "distinction", "S1"));

            tools = new Utility();
        }
        [Test]
        public void addFirst()
        {
            list.AddFirst(s1);
            Assert.AreEqual(s1, list.Head.Value);
            //list.RemoveFirst();
        }

        [Test]
        public void addLast()
        {
            list.AddLast(s2);
            Assert.AreEqual(s2, list.Tail.Value);
            //list.RemoveLast();
        }
        [Test]
        public void find()
        {
            //list.AddLast(s2);
            Assert.IsTrue(list.Contains(s2));
            //list.RemoveLast();
        }
        [Test]
        public void removeFirst()
        {
            //list.AddFirst(s1);
            list.RemoveFirst();
            Assert.AreNotEqual(s1, list.Head.Value);
        }
        [Test]
        public void removeLast()
        {
            //list.AddLast(s2);
            list.RemoveLast();
            Assert.AreNotEqual(s2, list.Tail.Value);
        }
    }

    // due to the requirements of part 8 making equality based around name I have created a new student class to accomidate this whilst keeping in line with the type T
    // polymorphic requirements of the utility class
    public class SearchingAndSortingTests
    {
        public List<StudentPart8> students;
        public List<StudentPart8> students2;
        public Utility tools;
        public StudentPart8 s1;
        public StudentPart8 s2;
        public StudentPart8 s3;
        public StudentPart8 s4;
        public StudentPart8 s5;
        public StudentPart8 s6;
        public StudentPart8 s7;
        public StudentPart8 s8;
        public StudentPart8 s9;
        public StudentPart8 s10;
        [OneTimeSetUp]
        public void Init()
        {
            students = new List<StudentPart8>();
            students2 = new List<StudentPart8>();
            s1 = new StudentPart8("John", "johnjones@gmail.com", "0431911084", "programming", new DateTime(2023, 05, 23), "12", "methodist st", "Willunga", "3530", "SA", new DateTime(2023, 05, 23), "distinction", "S1");
            s2 = new StudentPart8("James", "jessehamiltonyoung@gmail.com", "0431811047", "programming", new DateTime(2023, 05, 22), "12", "methodist st", "Willunga", "3530", "SA", new DateTime(2023, 05, 23), "distinction", "S1");
            s3 = new StudentPart8("Jillian", "jessen@gmail.com", "04318110887", "programming", new DateTime(2023, 05, 22), "12", "methodist st", "Willunga", "3530", "SA", new DateTime(2023, 05, 23), "distinction", "S1");
            s4 = new StudentPart8("Jesse", "jessehamilton@gmail.com", "0431811047", "programming", new DateTime(2023, 05, 22), "12", "methodist st", "Willunga", "3530", "SA", new DateTime(2023, 05, 23), "distinction", "S1");
            s5 = new StudentPart8("Anabelle", "Abell@gmail.com", "0439871047", "algebra", new DateTime(2023, 05, 30), "15", "colonic st", "salsbury", "3500", "SA", new DateTime(2023, 05, 30), "distinction", "S1");
            s6 = new StudentPart8("Karen", "kk@gmail.com", "0439871047", "programming", new DateTime(2023, 05, 30), "15", "colonic st", "salsbury", "3500", "SA", new DateTime(2023, 05, 30), "distinction", "S1");
            s7 = new StudentPart8("Aaron", "Alex@gmail.com", "0439871047", "algebra", new DateTime(2023, 05, 30), "15", "colonic st", "salsbury", "3500", "SA", new DateTime(2023, 05, 30), "distinction", "S1");
            s8 = new StudentPart8("Jameson", "jdawger@gmail.com", "0439871047", "programming", new DateTime(2023, 05, 30), "15", "colonic st", "salsbury", "3500", "SA", new DateTime(2023, 05, 30), "distinction", "S1");
            s9 = new StudentPart8("Ned", "nearlyheadless@gmail.com", "0439871047", "algebra", new DateTime(2023, 05, 30), "15", "colonic st", "salsbury", "3500", "SA", new DateTime(2023, 05, 30), "distinction", "S1");
            s10 = new StudentPart8("Zackary", "beeroclock@gmail.com", "0439871047", "Math", new DateTime(2023, 05, 30), "15", "colonic st", "salsbury", "3500", "SA", new DateTime(2023, 05, 30), "distinction", "S1");
            tools = new Utility();
            students.Add(s1);
            students.Add(s2);
            students.Add(s3);
            students.Add(s4);
            students.Add(s5);
            students.Add(s6);
            students.Add(s7);
            students.Add(s8);
            students.Add(s9);
            students.Add(s10);

            students2.Add(s1);
            students2.Add(s2);
            students2.Add(s3);
            students2.Add(s4);
            students2.Add(s5);
            students2.Add(s6);
            students2.Add(s7);
            students2.Add(s8);
            students2.Add(s9);
            students2.Add(s10);

        }
        [Test]
        public void LinearSearchOfList()
        {

            StudentPart8 target = s5;

            StudentPart8 outcome = tools.ListLinearSearch<StudentPart8>(students, target);
            Assert.AreEqual(target, outcome);

        }

        [Test]
        public void BinarySearchOfList()
        {
            students.Sort((s1, s2) => s1.Name.CompareTo(s2.Name));
            StudentPart8 target = s6;

            StudentPart8 outcome = tools.ListBinarySearch<StudentPart8>(students, target);

            Assert.AreEqual(target, outcome);
        }
        
        [Test]
        public void BubbleSortOfList()
        {
            tools.ListBubbleSort<StudentPart8>(students2);
            Assert.AreEqual(students2[0], s7);
            Assert.AreEqual(students2[9], s10);

        }
    }
    public class LinkedListSearchAndSort
    {
        public DoublyLinkedList<StudentPart8> students;
        public DoublyLinkedList<StudentPart8> students2;
        public Utility tools;
        public StudentPart8 s1;
        public StudentPart8 s2;
        public StudentPart8 s3;
        public StudentPart8 s4;
        public StudentPart8 s5;
        public StudentPart8 s6;
        public StudentPart8 s7;
        public StudentPart8 s8;
        public StudentPart8 s9;
        public StudentPart8 s10;
        [OneTimeSetUp]
        public void Init()
        {
            students = new DoublyLinkedList<StudentPart8>();
            students2 = new DoublyLinkedList<StudentPart8>();
            s1 = new StudentPart8("John", "johnjones@gmail.com", "0431911084", "programming", new DateTime(2023, 05, 23), "12", "methodist st", "Willunga", "3530", "SA", new DateTime(2023, 05, 23), "distinction", "S1");
            s2 = new StudentPart8("James", "jessehamiltonyoung@gmail.com", "0431811047", "programming", new DateTime(2023, 05, 22), "12", "methodist st", "Willunga", "3530", "SA", new DateTime(2023, 05, 23), "distinction", "S1");
            s3 = new StudentPart8("Jillian", "jessen@gmail.com", "04318110887", "programming", new DateTime(2023, 05, 22), "12", "methodist st", "Willunga", "3530", "SA", new DateTime(2023, 05, 23), "distinction", "S1");
            s4 = new StudentPart8("Jesse", "jessehamilton@gmail.com", "0431811047", "programming", new DateTime(2023, 05, 22), "12", "methodist st", "Willunga", "3530", "SA", new DateTime(2023, 05, 23), "distinction", "S1");
            s5 = new StudentPart8("Anabelle", "Abell@gmail.com", "0439871047", "algebra", new DateTime(2023, 05, 30), "15", "colonic st", "salsbury", "3500", "SA", new DateTime(2023, 05, 30), "distinction", "S1");
            s6 = new StudentPart8("Karen", "kk@gmail.com", "0439871047", "programming", new DateTime(2023, 05, 30), "15", "colonic st", "salsbury", "3500", "SA", new DateTime(2023, 05, 30), "distinction", "S1");
            s7 = new StudentPart8("Aaron", "Alex@gmail.com", "0439871047", "algebra", new DateTime(2023, 05, 30), "15", "colonic st", "salsbury", "3500", "SA", new DateTime(2023, 05, 30), "distinction", "S1");
            s8 = new StudentPart8("Jameson", "jdawger@gmail.com", "0439871047", "programming", new DateTime(2023, 05, 30), "15", "colonic st", "salsbury", "3500", "SA", new DateTime(2023, 05, 30), "distinction", "S1");
            s9 = new StudentPart8("Ned", "nearlyheadless@gmail.com", "0439871047", "algebra", new DateTime(2023, 05, 30), "15", "colonic st", "salsbury", "3500", "SA", new DateTime(2023, 05, 30), "distinction", "S1");
            s10 = new StudentPart8("Zackary", "beeroclock@gmail.com", "0439871047", "Math", new DateTime(2023, 05, 30), "15", "colonic st", "salsbury", "3500", "SA", new DateTime(2023, 05, 30), "distinction", "S1");
            tools = new Utility();
            students.Add(s1);
            students.Add(s2);
            students.Add(s3);
            students.Add(s4);
            students.Add(s5);
            students.Add(s6);
            students.Add(s7);
            students.Add(s8);
            students.Add(s9);
            students.Add(s10);

            students2.Add(s1);
            students2.Add(s2);
            students2.Add(s3);
            students2.Add(s4);
            students2.Add(s5);
            students2.Add(s6);
            students2.Add(s7);
            students2.Add(s8);
            students2.Add(s9);
            students2.Add(s10);

        }
        [Test]
        public void LinearSearchOfLinkedList()
        {

            StudentPart8 target = s5;

            DoublyLinkedListNode<StudentPart8> outcome = tools.DoubleSequentialSearch<StudentPart8>(students, target);
            Assert.AreEqual(target, outcome.Value);

        }

        [Test]
        public void BinarySearchOfLinkedList()
        {
            tools.DoubleBubbleSortASC(students);
            StudentPart8 target = s6;

            DoublyLinkedListNode<StudentPart8> outcome = tools.DoubleBinarySearch<StudentPart8>(students, target);

            Assert.AreEqual(target, outcome.Value);
        }

        [Test]
        public void BubbleSortOfLinkedList()
        {
            tools.DoubleBubbleSortASC<StudentPart8>(students2);
            Assert.AreEqual(s7, students2.Head.Value);
            Assert.AreEqual(s10, students2.Tail.Value);

        }
    }

}
