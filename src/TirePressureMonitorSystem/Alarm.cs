namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm
    {
        private const double LowPressureThreshold = 17.00;
        private const double HighPressureThreshold = 21.00;

        private readonly ISensor _sensor;
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
            double psiPressureValue = _sensor.PopNextPressurePsiValue();

            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                AlarmOn = true;
            }
        }
    }
}
