using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FomoDesigner
{
    public class GroupeModule
    {
        public string Label { get; set; }
        public SelectionTypeEnum SelectionType { get; set; }
        public ObservableCollection<Module> Modules { get; set; } = new ObservableCollection<Module>();

        public GroupeModule(string label = "New Group Module")
        {
            Label = label;
        }

        public void AddModule(string label)
        {
            Modules.Add(new Module(label));
        }

        public void DeleteModule(int index)
        {
            Modules.RemoveAt(index);
        }
    }
}
