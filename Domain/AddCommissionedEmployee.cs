using System;

namespace Payroll.Domain
{
    public class AddCommissionedEmployee : AddEmployTransaction
    {
        private readonly double monthlySalary;
        private readonly double commissionRate;
        public AddCommissionedEmployee(int empId, string name, string address, double monthlySalary, double commissionRate) 
            : base(empId, name, address)
        {
            this.monthlySalary = monthlySalary;
            this.commissionRate = commissionRate;
        }

        protected override PaymentClassification MakeClassification()
        {
            return new CommissionedClassification(monthlySalary, commissionRate);
        }

        protected override PaymentSchedule MakeSchedule()
        {
            return new BiweeklySchedule();
        }
    }
}