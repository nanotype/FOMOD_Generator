using System.Collections.Generic;

namespace FomoDesigner
{
    class Fomod
    {
        private List<InstallStep> ListInstallStep;

        public Fomod()
        {
            ListInstallStep = new List<InstallStep>();
        }

        public List<string> GetInstallStepBinding()
        {
            List<string> returnList = new List<string>();
            foreach(InstallStep installStep in ListInstallStep)
            {
                returnList.Add(installStep.getName());
            }
            return returnList;
        }

        //public List<>

        public void addInstallStep(string name)
        {
            ListInstallStep.Add(new InstallStep(name));
        }

        public void deleteInstallStep(int index)
        {
            ListInstallStep.RemoveAt(index);
        }
    }
}
