using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EmployeeWebserviceREST
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeNew" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmployeeNew.svc or EmployeeNew.svc.cs at the Solution Explorer and start debugging.
    public class EmployeeNew : IEmployeeNew
    {
        EmployeeDataDataContext data = new EmployeeDataDataContext();

        public bool AddEmployee(Employee emp)
        {
            //try {
                data.Employees.InsertOnSubmit(emp);
                data.SubmitChanges();
                return true;
            //}
            //catch {
            //    return false;
            //}
        }

        public bool DeleteEmployee(string idE)
        {
            try
            {
                var empDelete = data.Employees.Where(e => e.empID==idE).Single();
                data.Employees.DeleteOnSubmit(empDelete);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Employee> GetProductList()
        {
            try {
                return data.Employees.ToList();
            }
            catch {
                return null;
            }
        }

        public bool UpdateEmployee(Employee emp)
        {
            try {
                var empUpdate = data.Employees.Where(e => e.empID== emp.empID).Single();
                empUpdate.empAge = emp.empAge;
                empUpdate.empAddress = emp.empAddress;
                empUpdate.empFirstName = emp.empFirstName;
                empUpdate.empLastName = emp.empLastName;
                data.SubmitChanges();
                return true;
            }
            catch {
                return false;
            }
        }
    }
}
