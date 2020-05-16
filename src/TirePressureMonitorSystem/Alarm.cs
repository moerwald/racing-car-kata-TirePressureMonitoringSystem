using System;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm
    {
        private const double LowPressureThreshold = 17.00;
        private const double HighPressureThreshold = 21.00;

        private readonly ISensor _sensor;
        private double _psiPressureValue;

        public bool AlarmOn { get; private set; }

        public Alarm() : this (new Sensor())
        {
        }

        public Alarm(ISensor sensor)
        {
            _sensor = sensor;
        }

        public void Check()
        {
            _psiPressureValue = _sensor.PopNextPressurePsiValue();
            PressureIsNotInRange(() => AlarmOn = true);
        }

        private void PressureIsNotInRange(Action notInRange)
        {
            if (_psiPressureValue < LowPressureThreshold || HighPressureThreshold < _psiPressureValue)
            {
                notInRange?.Invoke();
            }
        }
    }
}
