using System;
using System.Collections.Generic;
using System.Threading;

namespace PatternObserverViaInterfaces.Solution._1
{
    static class Program
    {
        static void Main(string[] args)
        {
            //coздать объект класса Thermostat

            //coздать объект класса Heater установив начальную температуру равную 30 градусов

            //coздать объект класса Cooler установив начальную температуру равную 40 градусов

            //объект класса Heater - подписаться на событие изменения температуры класса Thermostat

            //объект класса Cooler - подписаться на событие изменения температуры класса Thermostat

            //эмуляция изменения температуры объекта класса Thermostat

            //объект класса Cooler - отписаться от события изменения температуры класса Thermostat

            //эмуляция изменения температуры объекта класса Thermostat на 45 градусов
        }
    }

    //интерфейс класса наблюдателя
    public interface IObserver
    {
        void Update(IObservable sender, TemperatureInfo info);
    }

    //интерфейс наблюдаемого класса 
    public interface IObservable
    {
        void Register(IObserver observer);
        void Unregister(IObserver observer);
        void Notify();
    }

    //базовый класс, предоставляющий дополнительную информацию о событии
    // для событий не предоставляющих дополнительную информацию свойство Empty
    public class EventArgs
    {
        public static readonly EventArgs Empty;
    }

    // класс, предоставляющий дополнительную информацию о событии изменения температуры
    public class TemperatureInfo : EventArgs
    {
        //TODO
    }

    public class Cooler
    {

    }

    public class Heater
    {

    }

    public class Thermostat
    {

    }
}