using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ElevationService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ElevatorService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ElevatorService.svc or ElevatorService.svc.cs at the Solution Explorer and start debugging.
    public class ElevatorService : IElevatorService
    {
        ElevatorDataDataContext db =new ElevatorDataDataContext();

        public bool addFeedback(Feedback f)
        {
            db.Feedbacks.InsertOnSubmit(f);
            db.SubmitChanges();
            return true;
        }

        public bool addMaintenance(Maintenance m)
        {
            db.Maintenances.InsertOnSubmit(m);
            db.SubmitChanges();
            return true;
        }

        public bool addOrder(Order od)
        {
            db.Orders.InsertOnSubmit(od);
            db.SubmitChanges();
            return true;
        }

        public bool addOrderDetail(OrderDetail odetail)
        {
            db.OrderDetails.InsertOnSubmit(odetail);
            db.SubmitChanges();
            return true;
        }

        public bool addProduct(Elevator ele)
        {
            if ((db.Elevators.Where(e => e.idElevator == ele.idElevator).FirstOrDefault()) == null) {
                db.Elevators.InsertOnSubmit(ele);
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public int countFeedback()
        {
            return (db.Feedbacks.Where(f => f.statusFeedback==0).ToList().Count);
        }

        public int countMaintenance()
        {
            return (db.Maintenances.Where(m => m.statusMaintenace==0).ToList().Count);
        }

        public int coutNewOrder()
        {
            int count = db.Orders.Where(o => o.OrderStatus==0).ToList().Count;
            return count;
        }

        public bool createCustomer(Customer cs)
        {
            db.Customers.InsertOnSubmit(cs);
            db.SubmitChanges();
            return true;
        }

        public bool deleteProduct(string id)
        {
            var pd = db.Elevators.Where(e => e.idElevator == id).FirstOrDefault();
            db.Elevators.DeleteOnSubmit(pd);
            db.SubmitChanges();
            return true;
        }

        public bool editProduct(Elevator ele)
        {
            var pd = db.Elevators.Where(p => p.idElevator==ele.idElevator).FirstOrDefault();
            pd.number = ele.number;
            pd.functionElevator = ele.functionElevator;
            pd.descriptionElevator = ele.descriptionElevator;
            pd.design = ele.design;
            pd.cost = ele.cost;
            pd.systemType = ele.systemType;
            db.SubmitChanges();
            return true;
        }

        public List<string> getAllCustomerID()
        {
            List<string> rt = (from cs in db.Customers select cs.emailCustomer).ToList();
            return rt;
        }

        public List<Feedback> getFeedBack()
        {
            return (db.Feedbacks.ToList());
        }

        public List<Maintenance> getMaintenance()
        {
            return (db.Maintenances.ToList());
        }

        public List<Order> getOrder()
        {
            return db.Orders.ToList();
        }

        public List<Order> getOrderByEmail(string email)
        {
            return db.Orders.Where(o => o.emailCustomer==email).ToList();
        }

        public Order getOrderByID(string id)
        {
            return (db.Orders.Where(o => o.idOder==id).FirstOrDefault());
        }

        public List<OrderDetail> getOrderDetail(string idOD)
        {
            return db.OrderDetails.Where(od => od.idOder== idOD).ToList();
        }

        public List<Elevator> getProduct()
        {
            return db.Elevators.Where(e => e.design=="0").ToList();
        }

        public List<Elevator> getProductByDesign(string dedign)
        {
            return db.Elevators.Where(e => e.design == dedign).ToList();
        }

        public Elevator getProductByID(string ID)
        {
            return db.Elevators.Where(e =>  e.idElevator==ID).FirstOrDefault();
        }

        public Customer loginCustomer(Customer cs)
        {
            var cus = db.Customers.Where(c => (c.emailCustomer==cs.emailCustomer) && (c.passwordCustomer==cs.passwordCustomer)).FirstOrDefault();
            if (cus != null) {
                return cus;
            }
            return null;
        }

        public Employee loginEmployee(Employee cs)
        {
            var em = db.Employees.Where(e => e.emailEmployee== cs.emailEmployee && e.passwordEmployee==cs.passwordEmployee).FirstOrDefault();
            if (em != null) {
                return em;
            }
            return null;
        }

        public void seenFeedback()
        {
            var fb = db.Feedbacks.Where(f => f.statusFeedback==0).ToList();
            fb.ForEach(f => f.statusFeedback=1);
            db.SubmitChanges();
        }

        public void seenMaintenance()
        {
            var fb = db.Maintenances.Where(f => f.statusMaintenace == 0).ToList();
            fb.ForEach(f => f.statusMaintenace = 1);
            db.SubmitChanges();
        }

        public bool updateOrder(string id, int status, string emailEmployee)
        {
            var odUpdate = db.Orders.Where(o => o.idOder == id).FirstOrDefault();
            odUpdate.OrderStatus = status;
            odUpdate.emailEmployee = emailEmployee;
            db.SubmitChanges();
            return true;
        }
    }
}
