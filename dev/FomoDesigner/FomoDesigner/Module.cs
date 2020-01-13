using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FomoDesigner
{
    class Module
    {
        private string Description;
        private string ImagePath;

        private List<string> ListFile;
        private List<string> ListDirectory;

        public Module()
        {
            ListFile = new List<string>();
            ListDirectory = new List<string>();
        }
    }
}
