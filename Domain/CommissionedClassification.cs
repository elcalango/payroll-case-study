using System;

namespace Payroll.Domain
{
    public class CommissionedClassification : PaymentClassification
    {
        public double MonthlySalary { get; set; }
        public double CommonRate { get; set; }

        public CommissionedClassification(double monthlySalary, double commonRate)
        {
            this.MonthlySalary = monthlySalary;
            this.CommonRate = commonRate;
        }

        public void AddSalesReceipt(SalesReceipt salesReceipt)
        {
            throw new NotImplementedException();
        }
    }
}