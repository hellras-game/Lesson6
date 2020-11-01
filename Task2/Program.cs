using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /*Выполнила Ярмолинская Анастасия
    Переделать программу Пример использования коллекций для решения следующих задач:
    а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
    б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся (*частотный массив);
    в) отсортировать список по возрасту студента;
    г) *отсортировать список по курсу и возрасту студента;*/
    class Program
    {
        /// <summary>
        /// Сортировка по возрасту.
        /// </summary>
        /// <param name="st1">Строка первого студента.</param>
        /// <param name="st2">Строка второго студента.</param>
        /// <returns></returns>
        static int MyDelegat1(Student st1, Student st2)
        {
            return String.Compare(Convert.ToString(st1.age), Convert.ToString(st2.age));
        }
        /// <summary>
        /// Сортировка по курсам.
        /// </summary>
        /// <param name="st1">Строка первого студента.</param>
        /// <param name="st2">Строка второго студента.</param>
        /// <returns></returns>
        static int MyDelegat2(Student st1, Student st2)
        {
            return String.Compare(Convert.ToString(st1.course), Convert.ToString(st2.course));
        }

        static void Main(string[] args)
        {
            int five = 0, six = 0;
            List<Student> list = new List<Student>();//Создаем список студентов
            StreamReader sr = new StreamReader("students.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    list.Add(new Student(s[0], s[1], int.Parse(s[2]), int.Parse(s[3])));//Добавляем в список новый экземпляр класса Student
                    if (int.Parse(s[2]) == 5)//учатся на пятом курсе
                    {
                        five++;
                    }
                    else if (int.Parse(s[2]) == 6)//учатся на шестом курсе
                    {
                        six++;
                    }

                    if (int.Parse(s[3]) >= 18 && int.Parse(s[3]) <= 20)
                    {

                    }
                    /*int[][] Array = new int[2][];
                    Array[0] = new int[list.Count];
                    Array[0].Copy(int.Parse(s[2]), Array[0], list.Count);
                    Array[1] = new int[list.Count];
                    Console.WriteLine(Array[0] + " " + Array[1]);*/
                }
                catch (Exception e)//обработка исключений
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;//выход из программы
                }
            }
            sr.Close();
            list.Sort(new Comparison<Student>(MyDelegat1));
            list.Sort(new Comparison<Student>(MyDelegat2));
            Console.WriteLine("Всего студентов:" + list.Count);
            Console.WriteLine("Магистров:{0}", five);
            Console.WriteLine("Бакалавров:{0}", six);
            foreach (var v in list)
            {
                Console.WriteLine($"{v.lastName} {v.firstName} {v.course} курс, {v.age} лет");
            }
            Console.ReadKey();
        
    }

}

public class Student
    {
        public string lastName;
        public string firstName;
        public int course;
        public int age;
        public Student(string lastName,
                       string firstName,
                       int course,
                       int age)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.course = course;
            this.age = age;
        }
    }
}
