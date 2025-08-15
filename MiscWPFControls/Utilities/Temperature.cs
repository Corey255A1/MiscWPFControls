using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscWPFControls.Utilities
{
    public enum TemperatureUnit
    {
        Celsuis,
        Fahrenheit,
        Kelvin
    }

    public class Temperature
    {
        public static double ConvertFromCelsius(double celsius, TemperatureUnit convertTo)
        {
            switch (convertTo)
            {
                case TemperatureUnit.Fahrenheit: return (celsius * 9.0) / 5.0 + 32.0;
                case TemperatureUnit.Kelvin: return celsius + 273.15;
                case TemperatureUnit.Celsuis:
                default:
                    return celsius;
            }
        }

        public static string Format(double celsius, TemperatureUnit temperatureUnit = TemperatureUnit.Celsuis)
        {
            switch (temperatureUnit)
            {
                case TemperatureUnit.Fahrenheit:
                    return $"{ConvertFromCelsius(celsius, temperatureUnit)} °F";
                case TemperatureUnit.Kelvin:
                    return $"{ConvertFromCelsius(celsius, temperatureUnit)} °K";
                case TemperatureUnit.Celsuis:
                default:
                    return $"{celsius} °C";
            }
        }
    }
}