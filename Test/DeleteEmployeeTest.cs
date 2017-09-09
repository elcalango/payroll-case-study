﻿using Payroll.Domain;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class DeleteEmployeeTest
    {
        [Test]
        public void TestDeleteEmployee()
        {
            int empId = 4;

            AddCommissionedEmployee t = new AddCommissionedEmployee(  empId, "Bill", "Home", 2500, 3.2);
            t.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);

            DeleteEmployeeTransaction dt = new DeleteEmployeeTransaction(empId);
            dt.Execute();

            e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNull(e);
        }
    }
}
