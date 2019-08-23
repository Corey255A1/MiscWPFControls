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

namespace MiscWPFControls.Controls.Compass
{
    /// <summary>
    /// Interaction logic for Compass.xaml
    /// </summary>
    public partial class Compass : UserControl, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName]string name="") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private Brush starColor = Brushes.Red;
        public Brush StarColor
        {
            get => starColor;
            set
            {
                starColor = value;
                NotifyPropertyChanged();
            }
        }

        private Brush backgroundFill = Brushes.Gray;
        public Brush BackgroundFill
        {
            get => backgroundFill;
            set
            {
                backgroundFill = value;
                NotifyPropertyChanged();
            }
        }

        private double centerWidth = 225;
        public double CenterWidth
        {
            get => centerWidth;
            set
            {
                centerWidth = value;
                NotifyPropertyChanged();
            }
        }

        private double centerHeight = 225;
        public double CenterHeight
        {
            get => centerHeight;
            set
            {
                centerHeight = value;
                NotifyPropertyChanged();
            }
        }


        public double NeedleAngle
        {
            get { return (double)GetValue(NeedleAngleProperty); }
            set { SetValue(NeedleAngleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NeedleAngle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NeedleAngleProperty =
            DependencyProperty.Register("NeedleAngle", typeof(double), typeof(Compass), new PropertyMetadata(45.0));




        private double needleLength = 0.9;
        public double NeedleLength
        {
            get => needleLength;
            set
            {
                needleLength = value;
                NotifyPropertyChanged();
            }
        }

        private double needleStart = (450 - 450 * 0.9)/2;
        public double NeedleStart
        {
            get => needleStart;
            private set
            {
                needleStart = value;
                NotifyPropertyChanged();
            }
        }
        private double needleEnd = 450 - (450 - 450 * 0.9) / 2;
        public double NeedleEnd
        {
            get => needleEnd;
            private set
            {
                needleEnd = value;
                NotifyPropertyChanged();
            }
        }

        public Compass()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            switch (e.Property.Name)
            {
                case "ActualWidth": CenterWidth = ActualWidth / 2; break;
                case "ActualHeight":
                    {
                        CenterHeight = ActualHeight / 2;
                        var offset = (ActualHeight - needleLength * ActualHeight) / 2;
                        NeedleStart = offset;
                        NeedleEnd = ActualHeight - offset;
                    }
                    break;
            }
        }


    }
}
