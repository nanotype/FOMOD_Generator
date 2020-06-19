using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace FomoDesigner
{
    public class InstallStep
    {
        public string Name { get; set; }
        public ObservableCollection<GroupeModule> GroupeModules { get; set; } = new ObservableCollection<GroupeModule>();

        public InstallStep(string name="New InstallStep")
        {
            Name = name;
        }

        public void AddGroupeModule(string name)
        {
            GroupeModules.Add(new GroupeModule(name));
        }

        public void DeleteGroupeModule(int index)
        {
            GroupeModules.RemoveAt(index);
        }
    }
}
