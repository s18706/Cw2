using System.Collections.Generic;

namespace Cw2.Models
{
    public class Studies
    {
        // public Studies(string name, string mode)
        // {
        //     _name = name.Replace(mode.ToLower(),"");
        //     _mode = mode;
        //
        //     // if (studiesCount.ContainsKey(_name))
        //     // {
        //     //     studiesCount[_name] += 1;
        //     // }
        //     // else
        //     // {
        //     //     studiesCount.Add(_name, 1);
        //     // }
        // }
        
        // public static Dictionary<string,int> studiesCount = new Dictionary<string, int>();
        public string name { get; set; }

        public string mode { get; set; }

        private string _name;
        private string _mode;
    }
}