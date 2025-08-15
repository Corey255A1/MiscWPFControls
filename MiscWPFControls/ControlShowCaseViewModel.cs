using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MiscWPFControls
{
    public class ControlShowCaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void Notify([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        private double _angle = 45;
        public double Angle
        {
            get => _angle;
            set
            {
                _angle = value;
                Notify();
            }
        }

        private double _temperature = 45;
        public double Temperature
        {
            get => _temperature;
            set
            {
                _temperature = value;
                Notify();
            }
        }
    }
}
