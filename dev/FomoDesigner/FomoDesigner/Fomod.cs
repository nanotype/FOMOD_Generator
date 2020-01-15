using System.Collections.Generic;

namespace FomoDesigner
{
    class Fomod
    {
        public List<InstallStep> ListInstallStep { get; set; }

        public Fomod()
        {
            ListInstallStep = new List<InstallStep>();
        }

        public List<string> GetInstallStepBinding()
        {
            List<string> returnList = new List<string>();
            foreach(InstallStep installStep in ListInstallStep)
            {
                returnList.Add(installStep.Name);
            }
            return returnList;
        }

        //public List<>

        public void AddInstallStep(string name)
        {
            ListInstallStep.Add(new InstallStep(name));
        }

        public void DeleteInstallStep(int index)
        {
            ListInstallStep.RemoveAt(index);
        }
    }
}
