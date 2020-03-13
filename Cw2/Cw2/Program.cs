using Cw2.Models;
using Cw2.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;


namespace Cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = new Log();
            try
            {
                var pathCsv = @"/Users/admin/Desktop/Schools4/APBD/projects/Cw2/Cw2/Cw2/Data/dane.csv";
                // var pathCsv = args.Length > 0 ? args[0] : "data.csv";
                var destination = args.Length > 1 ? args[1] : "result.xml";
                var fileFormat = args.Length > 2 ? args[2] : "xml";
                
                var lines = File.ReadLines(pathCsv);
                
                var students = new HashSet<Student>(new MyComparer());
                

                foreach (var line in lines)
                {
                    try
                    {
                        var data = line.Split(",");
                        if (data.Length == 9 && !Array.Exists(data, element => element == ""))
                        {
                            students.Add(new Student(data));
                        }
                        else
                        {
                            throw new StudentException(line);
                        }
                    } 
                    catch (StudentException e)
                    {
                        log.WriteLine(e.Msg + " nie został dodany");
                    }
                }

                Console.WriteLine(students.Count);

                var uczelnia = new Uczelnia
                {
                    studenci = students
                };

                if (fileFormat.Equals("xml"))
                {
                    FileStream writer = new FileStream(destination, FileMode.Create);
                    XmlSerializer serializer = new XmlSerializer(typeof(Uczelnia));
                    serializer.Serialize(writer, uczelnia);
                }
                else if (fileFormat.Equals("json"))
                {
                    var jsonString = JsonSerializer.Serialize(uczelnia);
                    File.WriteAllText("data.json", jsonString);
                }
            }
            catch (ArgumentException e)
            {
                log.WriteLine($"Podana sciezka jest niepoprawna: {e.ParamName}");
            }
            catch (FileNotFoundException e)
            {
                log.WriteLine($"Plik {e.FileName} nie istnieje");
            }
        }
    }
}