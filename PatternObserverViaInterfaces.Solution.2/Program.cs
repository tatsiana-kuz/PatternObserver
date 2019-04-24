using System;
using System.Collections.Generic;
using System.Threading;

namespace PatternObserverViaInterfaces.Solution._2
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
        void Update(IObservable sender, int info);
    }

    //интерфейс наблюдаемого класса 
    public interface IObservable
    {
        void Register(IObserver observer);
        void Unregister(IObserver observer);
        void Notify();
    }

    public class Cooler 
    {
        //TODO
    }

    public class Heater 
    {
        //TODO
    }

    public class Thermostat
    {
        //TODO
    }
}