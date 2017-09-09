﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Domain
{
    public class PayrollDatabase
    {
        private static Hashtable employees = new Hashtable(); 
       
        public static void AddEmployee(int id, Employee employee)
        {
            employees[id] = employee;
        }

        

        public static void DeleteEmployee(int id)
        {
            employees.Remove(id);
        }

        public static Employee GetEmployee(int empId)
        {
            return employees[empId] as Employee;
        }
    }
}