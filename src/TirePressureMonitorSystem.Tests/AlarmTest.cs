using NUnit.Framework;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    [TestFixture]
    public sealed class AlarmTest
    {
        [TestCase(0.0)]
        [TestCase(-1.0)]
        [TestCase(16.99)]
        public void Check_SensorStatesLowPressure_ReturnTrue(double pressure)
            => Assert(pressure, true);

        [TestCase(21.01)]
        [TestCase(1000.0)]
        public void Check_SensorStatesHighPressure_ReturnTrue(double pressure)
            => Assert(pressure, true);

        [TestCase(17.0)]
        [TestCase(17.5)]
        [TestCase(20.0)]
        [TestCase(21.0)]
        public void Check_SensorStatesValidPressure_ReturnFalse(double pressure)
            => Assert(pressure, false);

        private void Assert(double pressure, bool alarmState)
        {
            // Arrange
            var sensorStub = new Moq.Mock<ISensor>();
            sensorStub.Setup(sensor => sensor.PopNextPressurePsiValue()).Returns(pressure);
            var alarm = new Alarm(sensorStub.Object);

            // Act
            alarm.Check();

            // Assert
            NUnit.Framework.Assert.AreEqual(alarmState, alarm.AlarmOn);
        }
    }
}