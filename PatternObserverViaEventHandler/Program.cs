using System;
using System.Reflection;

namespace PatternObserverViaEventHandler
{
    static class Program
    {
        static void Main(string[] args)
        {
            //coздать объект класса Thermostatact
            Thermostat thermostat = new Thermostat();

            //coздать объект класса Heater установив начальную температуру равную 30 градусов
            Heater heater = new Heater(30);

            //coздать объект класса Cooler установив начальную температуру равную 40 градусов
            Cooler cooler = new Cooler(40);

            //объект класса Heater - подписаться на событие изменения температуры класса Thermostat
            thermostat.TemperatureChanged += heater.Update;

            //объект класса Cooler - подписаться на событие изменения температуры класса Thermostat
            thermostat.TemperatureChanged += cooler.UpdateForColler;

            //эмуляция изменения температуры объекта класса Thermostat
            thermostat.EmulateTemperatureChange();

            //объект класса Cooler - отписаться от события изменения температуры класса Thermostat
            thermostat.TemperatureChanged -= cooler.UpdateForColler;

            //эмуляция изменения температуры объекта класса Thermostat на 45 градусов
            thermostat.EmulateTemperatureChange();

            Type type = thermostat.GetType();

            foreach (var t in type.GetMethods(BindingFlags.Instance | BindingFlags.Public|BindingFlags.NonPublic))
            {
                Console.WriteLine(t.Name);
            }

            Console.ReadKey();
        }
    }

    public class TemperatureArgs : EventArgs
    {
        //TODO
    }

    public class Cooler
    {
        public Cooler(int temperature) => Temperature = temperature;

        public int Temperature { get; private set; }

        public void UpdateForColler(object sender, EventArgs args)
        {
            TemperatureChangedEventArgs newTemperature = args as TemperatureChangedEventArgs;
            Console.WriteLine(newTemperature.Temperature > Temperature
                        ? $"Cooler: sOn. Changed:{Math.Abs(newTemperature.Temperature - Temperature)}"
                        : $"Cooler: sOff. Changed:{Math.Abs(newTemperature.Temperature - Temperature)}");
        }
    }

    public class Heater
    {
        public Heater(int temperature) => Temperature = temperature;

        public int Temperature { get; private set; }

        public void Update(object sender, EventArgs args)
        {
            TemperatureChangedEventArgs newTemperature = args as TemperatureChangedEventArgs;
            Console.WriteLine(newTemperature.Temperature < Temperature
                ? $"Heater: sOn. Changed:{Math.Abs(newTemperature.Temperature - Temperature)}"
                : $"Heater: sOff. Changed:{Math.Abs(newTemperature.Temperature - Temperature)}");
        }
    }

    // класс, предоставляющий дополнительную информацию о событии изменения температуры
    public class TemperatureChangedEventArgs : EventArgs
    {
        public TemperatureChangedEventArgs(int temperature)
        {
            Temperature = temperature;
        }

        public int Temperature { get; set; }
    }

    public sealed class Thermostat
    {

        private int currentTemperature;

        private Random random = new Random(Environment.TickCount);

        public Thermostat()
        {
            currentTemperature = 5;
        }

        public EventHandler<TemperatureChangedEventArgs> TemperatureChanged { get; set; }

        public int CurrentTemperature
        {
            get => currentTemperature;
            private set
            {
                if (value > currentTemperature)
                {
                    currentTemperature = value;
                    OnTemperatureChanged();
                }
            }
        }

        public void EmulateTemperatureChange()
        {
            this.CurrentTemperature = random.Next(0, 100);
        }

        #region interface

        private void OnTemperatureChanged()
        {
            var local = TemperatureChanged;
            local?.Invoke(this, new TemperatureChangedEventArgs(CurrentTemperature));
        }

        //public void Register(IObserver observer)
        //{
        //    observers.Add(observer);
        //}

        //public void Unregister(IObserver observer)
        //{
        //    observers.Remove(observer);
        //}

        #endregion
    }
}
