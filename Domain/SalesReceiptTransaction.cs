﻿using System;

namespace Payroll.Domain
{
    public class SalesReceiptTransaction : Transaction
    {
        private readonly int empId;
        private readonly DateTime dateTime;
        private readonly double amount;

        public SalesReceiptTransaction(int empId, DateTime dateTime, double amount)
        {
            this.empId = empId;
            this.dateTime = dateTime;
            this.amount = amount;
        }

        public void Execute()
        {
            Employee e = PayrollDatabase.GetEmployee(empId);

            if (e != null)
            {
                CommissionedClassification cc = e.Classification as CommissionedClassification;
                if (cc != null)
                    cc.AddSalesReceipt(new SalesReceipt(dateTime, amount));
                else
                    throw new InvalidOperationException("Tried to add a commission to no commissioned employee.");
            }
            else
            {
                throw new InvalidOperationException("No such employee.");
            }
        }
    }
}