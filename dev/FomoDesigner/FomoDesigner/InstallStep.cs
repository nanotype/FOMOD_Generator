﻿using System.Collections.Generic;
using System.Windows.Controls;

namespace FomoDesigner
{
    class InstallStep
    {
        public string Name { get; set; }
        public List<GroupeModule> ListGroupeModule { get; set; }

        public InstallStep(string name=null)
        {
            Name = name;
            ListGroupeModule = new List<GroupeModule>();
        }

        public void AddGroupeModule(string name)
        {
            ListGroupeModule.Add(new GroupeModule(name));
        }

        public void DeleteGroupeModule(int index)
        {
            ListGroupeModule.RemoveAt(index);
        }

        public List<TreeViewItem> GetGroupModuleBinding()
        {
            List<TreeViewItem> returnList = new List<TreeViewItem>();
            foreach(GroupeModule groupeModule in ListGroupeModule)
            {
                TreeViewItem treeViewItem = new TreeViewItem
                {
                    Header = groupeModule.Label,
                    Tag = "GroupModule",
                    IsExpanded = true
                };

                foreach (Module module in groupeModule.ListModule)
                {
                    TreeViewItem treeViewItem_child = new TreeViewItem
                    {
                        Header = module.Label,
                        Tag = "Module"
                    };
                    treeViewItem.Items.Add(treeViewItem_child);
                }
                returnList.Add(treeViewItem);
            }
            return returnList;
        }
    }
}
