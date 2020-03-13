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
                // var pathCsv = @"/Users/admin/Desktop/Schools4/APBD/projects/Cw2/Cw2/Cw2/Data/dane.csv";
                var pathCsv = args.Length > 0 ? args[0] : "data.csv";
                var destination = args.Length > 1 ? args[1] : "result.xml";
                var fileFormat = args.Length > 2 ? args[2] : "xml";
                
                var lines = File.ReadLines(pathCsv);
                
                var uczelnia = new Uczelnia();
                var students = new HashSet<Student>(new MyComparer());
                var activeStudiesDictionary = new Dictionary<string,int>();

                foreach (var line in lines)
                {
                    try
                    {
                        var data = line.Split(",");
                        if (data.Length == 9 && !Array.Exists(data, element => element == ""))
                        {
                            Student tmp = new Student(data);
                            if (students.Add(tmp))
                            { 
                                if (!activeStudiesDictionary.ContainsKey(tmp.studies.name))
                                    activeStudiesDictionary.Add(tmp.studies.name, 1);
                                else
                                    activeStudiesDictionary[tmp.studies.name] += 1;
                            }
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

                uczelnia.studenci = students;
                uczelnia.activeStudies = new List<ActiveStudies>();
                
                foreach (KeyValuePair<string, int> kvp in activeStudiesDictionary)
                {
                    uczelnia.activeStudies.Add(new ActiveStudies
                    {
                        name = kvp.Key,
                        numberOfStudents = kvp.Value
                    });
                }
                
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