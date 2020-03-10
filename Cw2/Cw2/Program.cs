﻿using Cw2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathCsv = @"/Users/admin/Desktop/Schools4/APBD/projects/Cw2/Cw2/Cw2/Data/dane.csv";
            // var pathCsv = args.Length > 0 ? args[0] : "data.csv";
            var destination = args.Length > 1 ? args[1] : "result.xml";
            var fileFormat = args.Length > 2 ? args[2] : "xml";

            var lines = File.ReadLines(pathCsv);

            foreach (var line in lines)
            {
                var data = line.Split(",");
                foreach (var thing in data)
                {
                    Console.Write(thing + { });
                }
                Console.WriteLine();
            }
            //stream.Dispose();

            //XML
            var list = new List<Student>();
            var st = new Student
            {
                FirstName= "Jan",
                LastName= "Kowalski",
                Index= "1234"    
            };
            list.Add(st);

            FileStream writer = new FileStream(destination, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>),
                                       new XmlRootAttribute("uczelnia"));
            serializer.Serialize(writer, list);
            serializer.Serialize(writer, list);

        }
    }
}