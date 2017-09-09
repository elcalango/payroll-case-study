using System;

namespace Payroll.Domain
{
    public class AddCommissionedEmployee : AddEmployTransaction
    {
        private readonly double monthlySalary;
        private readonly double commonRate;
        public AddCommissionedEmployee(int empId, string name, string address, double monthlySalary, double commonRate) 
            : base(empId, name, address)
        {
            this.monthlySalary = monthlySalary;
            this.commonRate = commonRate;
        }

        protected override PaymentClassification MakeClassification()
        {
            return new CommissionedClassification(500.0, 10.0);
        }

        protected override PaymentSchedule MakeSchedule()
        {
            return new BiweeklySchedule();
        }
    }
}