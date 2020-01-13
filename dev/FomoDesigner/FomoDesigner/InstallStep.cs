using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FomoDesigner
{
    class InstallStep
    {
        private string name;
        private List<GroupeModule> ListGroupeModule;

        public InstallStep(string name=null)
        {
            this.name = name;
            ListGroupeModule = new List<GroupeModule>();
        }

        public string getName()
        {
            return name;
        }
    }
}
