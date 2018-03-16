using System;

namespace Payroll.Domain
{
    public class ServiceChargeTransaction 
    {
        private readonly int memberId;
        private readonly DateTime time;
        private readonly Double charge;

        public ServiceChargeTransaction(int memberId, DateTime dateTime, Double charge)
        {
            this.memberId = memberId;
            this.time = dateTime;
            this.charge = charge;
        }

        public void Execute()
        {
            Employee e = PayrollDatabase.GetUnionMember(memberId);

            if (e != null)
            {
                UnionAffiliation ua = null;
                if (e.Affiliation is UnionAffiliation)
                    ua = e.Affiliation as UnionAffiliation;

                if (ua != null)
                {
                    ua.AddServiceCharge(new ServiceCharge(time, charge));
                }
                else
                {
                    throw new InvalidOperationException("Tries to add service charge to union. Member without a union affiliation");
                }
            }
            else
            {
                throw new InvalidOperationException("No such union member");
            }
        }
    }
}