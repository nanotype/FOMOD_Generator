using System.Collections.Generic;

namespace FomoDesigner
{
    public class Module
    {
        public string Label { get; set; }
        public string Description { get; set; } = "";
        public string ImagePath { get; set; }
        public List<string> ListFile { get; set; }
        public List<string> ListDirectory { get; set; }

        public Module(string label)
        {
            Label = label;
            ListFile = new List<string>();
            ListDirectory = new List<string>();
        }
    }
}
