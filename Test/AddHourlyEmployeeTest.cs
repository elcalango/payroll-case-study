using Payroll.Domain;
using NUnit.Framework; 

namespace Test
{
    [TestFixture]
    public class AddHourlyEmployeeTest
    {
        [Test]
        public void TestAddHourlyEmployee()
        {
            int empId = 2;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Neto", "Santa Barbara D' Oeste", 50.0);
            t.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Neto", e.Name);

            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is HourlyClassification);

            HourlyClassification hc = pc as HourlyClassification;
            Assert.AreEqual(50.0, hc.HourlyRate, .001);

            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is WeeklySchedule);

            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);

        }
    }
}
