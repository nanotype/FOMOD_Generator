using System.Collections.Generic;

namespace FomoDesigner
{
    class GroupeModule
    {
        public string Label { get; set; }
        public List<Module> ListModule { get; set; }

        public GroupeModule(string label = null)
        {
            Label = label;
            ListModule = new List<Module>();
        }

        public void AddModule(string label)
        {
            ListModule.Add(new Module(label));
        }

        public void DeleteModule(int index)
        {
            ListModule.RemoveAt(index);
        }
    }
}
