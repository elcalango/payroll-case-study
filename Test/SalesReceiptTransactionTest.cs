using Payroll.Domain;
using NUnit.Framework;
using System;

namespace Test
{
    [TestFixture]
    public class SalesReceiptTransactionTest
    {
        [Test]
        public void TestSalesReceiptTransaction()
        {
            int empId = 6;
            AddCommissionedEmployee t = new AddCommissionedEmployee(empId, "Commissioned", "Sertãozinho", 1000, 10);
            t.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);

            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is CommissionedClassification);

            SalesReceiptTransaction srt = new SalesReceiptTransaction(empId, new DateTime(2017, 09, 07), 100.00);
        }
    }
}
