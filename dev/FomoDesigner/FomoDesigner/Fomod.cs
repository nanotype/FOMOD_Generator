using System.Collections.Generic;

namespace FomoDesigner
{
    class Fomod
    {
        public List<InstallStep> InstallSteps { get; set; }

        public Fomod()
        {
            InstallSteps = new List<InstallStep>();
        }

        public List<string> GetInstallStepBinding()
        {
            List<string> returnList = new List<string>();
            foreach(InstallStep installStep in InstallSteps)
            {
                returnList.Add(installStep.Name);
            }
            return returnList;
        }

        //public List<>

        public void AddInstallStep(string name)
        {
            InstallSteps.Add(new InstallStep(name));
        }

        public void DeleteInstallStep(int index)
        {
            InstallSteps.RemoveAt(index);
        }
    }
}
