using MiscWPFControls.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MiscWPFControls.Controls.Thermometer
{
    /// <summary>
    /// Interaction logic for Thermometer.xaml
    /// </summary>
    public partial class Thermometer : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void Notify([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));



        public TemperatureUnit Unit
        {
            get { return (TemperatureUnit)GetValue(UnitProperty); }
            set { 
                SetValue(UnitProperty, value);
                Notify(nameof(MaxTemperatureFormatted));
                Notify(nameof(MinTemperatureFormatted));
                Notify(nameof(TemperatureFormatted));
            }
        }

        public static readonly DependencyProperty UnitProperty =
            DependencyProperty.Register("Unit", typeof(TemperatureUnit), typeof(Thermometer), new PropertyMetadata(TemperatureUnit.Celsuis));



        public string MaxTemperatureFormatted => Utilities.Temperature.Format(MaxTemperature, Unit);
        public double MaxTemperature
        {
            get { return (double)GetValue(MaxTemperatureProperty); }
            set
            {
                SetValue(MaxTemperatureProperty, value);
                Notify(nameof(MaxTemperatureFormatted));
                Notify(nameof(PercentageOfRange));
            }
        }
        
        public static readonly DependencyProperty MaxTemperatureProperty =
            DependencyProperty.Register("MaxTemperature", typeof(double), typeof(Thermometer), new PropertyMetadata(100.0));


        public string MinTemperatureFormatted => Utilities.Temperature.Format(MinTemperature, Unit);
        public double MinTemperature
        {
            get { return (double)GetValue(MinTemperatureProperty); }
            set
            {
                SetValue(MinTemperatureProperty, value);
                Notify(nameof(MinTemperatureFormatted));
                Notify(nameof(PercentageOfRange));
            }
        }
        
        public static readonly DependencyProperty MinTemperatureProperty =
            DependencyProperty.Register("MinTemperature", typeof(double), typeof(Thermometer), new PropertyMetadata(0.0));



        public string TemperatureFormatted => Utilities.Temperature.Format(Temperature, Unit);

        public double Temperature
        {
            get { return (double)GetValue(TemperatureProperty); }
            set
            {
                SetValue(TemperatureProperty, value);
                Notify(nameof(TemperatureFormatted));
                Notify(nameof(PercentageOfRange));
            }
        }

        // Using a DependencyProperty as the backing store for MinTemperature.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TemperatureProperty =
            DependencyProperty.Register("Temperature", typeof(double), typeof(Thermometer), new PropertyMetadata(0.0));


        public double PercentageOfRange => (Temperature - MinTemperature) / MaxTemperature;


        public Thermometer()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            //base.OnPropertyChanged(e);
            //switch (e.Property.Name)
            //{
            //    case "ActualHeight":
            //        {
            //            temperatureStep = (temperatureTube.ActualHeight-(bulb.ActualHeight/2)) / (maxTemp - minTemp);
            //            NotifyPropertyChanged(nameof(TemperatureHeight));
            //        }
            //        break;
            //    case "Temperature":
            //        NotifyPropertyChanged(nameof(TemperatureHeight));
            //        NotifyPropertyChanged(nameof(TemperatureText));
            //        break;
            //}
        }
    }
}
