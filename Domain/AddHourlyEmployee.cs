using System;

namespace Payroll.Domain
{
    public class AddHourlyEmployee : AddEmployTransaction
    {
        private double hourlyRate;

        public AddHourlyEmployee(int id, string name, string address, double hourlyRate)
            : base(id,name,address)
        {
            this.hourlyRate = hourlyRate;
        }

        protected override PaymentClassification MakeClassification()
        {
            return new HourlyClassification(hourlyRate);
        }

        protected override PaymentSchedule MakeSchedule()
        {
            return new WeeklySchedule();
        }
    }
}