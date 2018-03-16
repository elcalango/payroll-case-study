using Payroll.Domain;
using NUnit.Framework;
using System;

namespace Test
{
    [TestFixture]
    public class AddServiceChargeTest
    {
        [Test]
        public void TestAddServiceCharge()
        {
            int empId = 7;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            UnionAffiliation af = new UnionAffiliation();
            e.Affiliation = af;

            int memberId = 86; //Maxwell Smart
            PayrollDatabase.AddUnionMember(memberId, e);
            ServiceChargeTransaction sct = new ServiceChargeTransaction(memberId, new DateTime(2018, 3, 16), 12.95);
            sct.Execute();
            ServiceCharge sc = af.GetServiceCharge(new DateTime(2018, 3, 16));

            Assert.IsNotNull(sc);
            Assert.AreEqual(12.95, sc.Amount, .001);
        }

    }
}
