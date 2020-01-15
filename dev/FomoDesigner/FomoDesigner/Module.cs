using System.Collections.Generic;

namespace FomoDesigner
{
    class Module
    {
        public string Label { get; set; }
        private string Description;
        private string ImagePath;

        private List<string> ListFile;
        private List<string> ListDirectory;

        public Module(string label)
        {
            Label = label;
            ListFile = new List<string>();
            ListDirectory = new List<string>();
        }
    }
}
