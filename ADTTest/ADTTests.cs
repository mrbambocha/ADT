using NUnit.Framework;
using ADT;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;

namespace ADTTest
{
    public class ADTTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void MyLinkedList_Test()
        {
            List<ILab2List<Person>> imp = new List<ILab2List<Person>>
            {
                new MyLinkedList<Person>(),
                new MyArrayList<Person>()
            };
            var l1 = imp[1];
            Assert.Multiple(() =>
            {
                var bilbo = new Person("Bilbo", "Baggins", 111);
                var samwise = new Person("Samwise", "Gamgee", 39);
                l1.AddFirst(bilbo);
                l1.AddFirst(samwise);
                Assert.AreEqual(2, l1.Count());

                Assert.AreEqual("Samwise", l1[0].FirstName);
                l1[0] = new Person("Tom", "Bombadil", 5523);
                Assert.AreEqual("Bombadil", l1[0].LastName);

                Assert.Throws(Is.TypeOf<IndexOutOfRangeException>(), delegate
                {
                    Console.WriteLine(l1[5]);
                });

                var p = new Person("Gandalf", "Grey", 2333);
                l1.AddLast(p);

                Assert.AreEqual(3, l1.Count());
                Assert.AreEqual("Grey", l1[l1.Count() - 1].LastName);

                Assert.IsAssignableFrom(typeof(Person), l1[0]);
                Assert.IsNotAssignableFrom(typeof(string), l1[0]);

                Assert.AreEqual(2, l1.IndexOf(p));

                l1.Remove(l1.Count() - 1);

                l1.AddFirst(p);

                Assert.IsTrue(l1.IndexOf(p) > -1);

                var result = l1.Remove(p);

                Assert.AreEqual(-1, l1.IndexOf(p));

                var arr = l1.ToArray();
                Assert.AreEqual(2, arr.Length);
                Assert.AreEqual(arr[1], bilbo);

                Assert.IsInstanceOf<Person>(l1[1]);

                int i = l1.Count() - 1;
                while (i >= 0)
                {
                    l1.Remove(i);
                    i--;
                }
                Assert.AreEqual(0, l1.Count());
            });
        }

        public bool TestList(ILab2List<Person> l1)
        {
            return true;
        }
    }
    public class Person : IComparable
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }

        public Person()
        {

        }
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + " " + Age.ToString();
        }

        public int CompareTo(object obj)
        {
            Person p = (Person)obj;
            if (p.FirstName == FirstName && p.LastName == LastName && p.Age == Age)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}