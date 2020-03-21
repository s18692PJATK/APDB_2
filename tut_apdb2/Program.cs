using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.CompilerServices;
using tut_apdb2.models;

namespace tut_apdb2
{
    class Program
    {
        private static readonly StreamWriter LogWriter = new StreamWriter(@"log.txt");
        private const int FirstNameIndex = 0;
        private const int LastNameIndex = 1;
        private const int StudiesIndex = 2;
        private const int StudiesTypeIndex = 3;
        private const int IndexNumber = 4;
        private const int BirthDateIndex = 5;
        private const int MailIndex = 6;
        private const int MotherNameIndex = 7;
        private const int FatherNameIndex = 8;

        private static void Main(string[] args)
        {
            var students = ReadData("/home/piotr/RiderProjects/tut_apdb2/tut_apdb2/Data/dane.csv");
            //for some reason only absolute path works, you might want to change that
            var activeStudiesMap = GetCountOfStudies(students);
            var activeStudies =  convertToSet(activeStudiesMap);
            SerializeData(students,".xml");
            SerializeData(activeStudies,".xml");
            
        }
        
        private static IEnumerable<Student> ReadData(string source)
        {
            if (!Regex.IsMatch (source, "((?:[a-zA-Z]\\:){0,1}(?:[\\/][\\w.]+){1,})"))
            {
                throw new ArgumentException("The path is incorrect");
            }
            var fi = new FileInfo(source);
            if(!fi.Exists)
                throw new FileNotFoundException("The file is not found");
            
            using var stream = new StreamReader(fi.OpenRead());
            string line;
            var students = new HashSet<Student>(new PersonComparator());
            while ((line = stream.ReadLine()) != null)
            {
                var student = ProcessLine(line);
                if (student != null)
                    students.Add(student);
            }

            return students;

        }

        private static Dictionary<string,int> GetCountOfStudies(IEnumerable<Student> students)
        {
            var map = new Dictionary<string,int>();
            foreach (var student in students)
            {
                var name = student.Studies.name;
                if (!map.ContainsKey(name))
                {
                    map.Add(name,1);
                }
                else
                    map[name]++;
            }

            return map;
        }

       
        private static void SerializeData(IEnumerable<Student> students,IEnumerable<ActiveStudies>,string format)
        {
            var writer = new FileStream(@"result"+format,FileMode.Create);
            var serializer = SelectSerializer(format);
            serializer.serializeStudents(students,writer);
            
        }

        private static IEnumerable<ActiveStudies> convertToSet(Dictionary<string, int> dictionary)
        {
        var set = new HashSet<ActiveStudies>();
            foreach (var VARIABLE in dictionary)
            {
                set.Add(new ActiveStudies
                {
                    name = VARIABLE.Key,
                    number = VARIABLE.Value
                });
            }

            return set;
        }
        
        
        private static Student ProcessLine(string line)
        {
            var words = line.Split(",");
            if (words.Length != 9)
            {
                LogWriter.WriteLine("incorrect line " + line);
                return null;
            }

            foreach (var word in words)
            {
                if (!String.IsNullOrEmpty(word)) continue;
                LogWriter.WriteLine(word);
                return null;
            }

            var student = new Student
            {
                FirstName = words[FirstNameIndex],
                LastName = words[LastNameIndex],
                Studies = new Studies
                {
                    name =  words[StudiesIndex],
                    mode = words[StudiesTypeIndex]
                },
                IndexNumber = words[IndexNumber],
                BirthDate = DateTime.Parse(words[BirthDateIndex]),
                Email = words[MailIndex],
                MotherName = words[MotherNameIndex],
                FatherName = words[FatherNameIndex]
            };
            return student;
        }
        
        private static ISerializer SelectSerializer(string format)
        {
            ISerializer serializer;
            switch (format.ToUpper())
            {
                case ".XML":
                {
                    serializer = new MyXmlSerializer();
                    break;
                }
                case ".JSON":
                {
                    serializer = new MyJsonSerializer();
                    break;
                }
                default: throw new ArgumentException("this format is not supported");
            }

            return serializer;
        }

        
    }
}