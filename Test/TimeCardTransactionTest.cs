using Payroll.Domain;
using NUnit.Framework;
using System;

namespace Test
{
    [TestFixture]
    public class TimeCardTransactionTest
    {
        [Test]
        public void TestTimeCardTransaction()
        {
            int empId = 5;

            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();

            TimeCardTransaction tct = new TimeCardTransaction(new DateTime(2017, 8, 25), 8.0, empId);
            tct.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);

            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is HourlyClassification);

            HourlyClassification hc = pc as HourlyClassification;

            TimeCard tc = hc.GetTimeCard(new DateTime(2017, 8, 25));

            Assert.IsNotNull(tc);
            Assert.AreEqual(8.0, tc.Hours);
        }
    }
}
