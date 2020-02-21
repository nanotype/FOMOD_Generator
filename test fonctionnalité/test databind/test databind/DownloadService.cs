using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

namespace test_databind
{
    class DownloadService : INotifyPropertyChanged
    {
        private System.Timers.Timer timer = new System.Timers.Timer();
        private double actualTimer = 0;
        private readonly double waiting = 1000;

        public event PropertyChangedEventHandler PropertyChanged;

        public double Percent { get; set; }

        public DownloadService()
        {
            timer.Elapsed += Timer_Elapsed;
        }

        public void StartTimer()
        {
            Percent = 0;
            timer.Interval = 100;
            timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            actualTimer += timer.Interval;

            Percent = (actualTimer / waiting) * 100;
            NotifyPropertyChanged("Percent");

            if (Percent >= 100)
            {
                timer.Enabled = false;
                MessageBox.Show("Téléchargement terminé !!!", "Fake download");
            }
        }

        public void NotifyPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
