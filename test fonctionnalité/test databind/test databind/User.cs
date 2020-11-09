using System.ComponentModel;

namespace test_databind
{
	public class User : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string name;

        public int Age { get; set; } = -1;
        public string Mail { get; set; } = "NoMail";
        public SexType Sex { get; set; } = SexType.Escargot;

        public string Name
        {
            get { return name; }
            set
            {
                if(name != value)
                {
                    name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        public void NotifyPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

		public override string ToString()
		{
            return Name + ", " + Age + " years old";
		}
	}
}
