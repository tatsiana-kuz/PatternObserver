using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternObserverViaInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Thermostat thermostat = new Thermostat();

            thermostat.CurrentTemperature = 60;

            float temperature = thermostat.CurrentTemperature;

            Heater heater = new Heater(temperature);

            Cooler cooler = new Cooler(temperature);

            thermostat.CurrentTemperature = 100;

            heater.Temperature = thermostat.CurrentTemperature;

            cooler.Temperature = thermostat.CurrentTemperature;
        }
    }

    public class Cooler
    {
        public Cooler(float temperature) => Temperature = temperature;

        public float Temperature { get; set; }

        public void Update(float newTemperature)
            =>  Console.WriteLine(newTemperature > Temperature
                ? $"Cooler: On. Changed:{Math.Abs(newTemperature - Temperature)}"
                : $"Cooler: Off. Changed:{Math.Abs(newTemperature - Temperature)}");
    }

    public class Heater
    {
        public Heater(float temperature) => Temperature = temperature;

        public float Temperature { get; set; }

        public void OnTemperatureChanged(float newTemperature)
            =>  Console.WriteLine(newTemperature < Temperature
                ? $"Heater: On. Changed:{Math.Abs(newTemperature - Temperature)}"
                : $"Heater: Off. Changed:{Math.Abs(newTemperature - Temperature)}");
    }

    public class Thermostat
    {
        private float currentTemperature;

        private const float Tolerance = 0.00001f;

        public float CurrentTemperature
        {
            get => currentTemperature;
            set
            {
                if (Math.Abs(value - currentTemperature) > Tolerance)
                {
                    currentTemperature = value;
                }
            }
        }
    }
}
