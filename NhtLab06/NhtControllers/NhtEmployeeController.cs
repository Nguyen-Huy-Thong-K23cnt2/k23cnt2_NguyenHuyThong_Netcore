using Microsoft.AspNetCore.Mvc;
using NhtLab06.Models;

namespace NhtLab06.NhtControllers
{
    public class NhtEmployeeController : Controller
    {
        static List<NhtEmployee> nhtListEmployee = new List<NhtEmployee>()
        {
            new NhtEmployee{ NhtId=1, NhtName="Nguyễn Huy Thông", NhtBirthDay=new DateTime(2005,1,1), NhtEmail="thong@example.com", NhtPhone="0123456789", NhtSalary=1000, NhtStatus=true },
            new NhtEmployee{ NhtId=2, NhtName="Trần Văn A", NhtBirthDay=new DateTime(1995,5,1), NhtEmail="a@example.com", NhtPhone="0123456788", NhtSalary=2000, NhtStatus=true },
            new NhtEmployee{ NhtId=3, NhtName="Lê Thị B", NhtBirthDay=new DateTime(1998,4,4), NhtEmail="b@example.com", NhtPhone="0123456787", NhtSalary=1500, NhtStatus=false },
            new NhtEmployee{ NhtId=4, NhtName="Ngô Văn C", NhtBirthDay=new DateTime(1990,3,3), NhtEmail="c@example.com", NhtPhone="0123456786", NhtSalary=3000, NhtStatus=true },
            new NhtEmployee{ NhtId=5, NhtName="Phạm Thị D", NhtBirthDay=new DateTime(1993,2,2), NhtEmail="d@example.com", NhtPhone="0123456785", NhtSalary=2500, NhtStatus=false }
        };

        public ActionResult NhtIndex()
        {
            return View(nhtListEmployee);
        }

        [HttpGet]
        public ActionResult NhtCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NhtCreateSubmit(NhtEmployee emp)
        {
            emp.NhtId = nhtListEmployee.Max(e => e.NhtId) + 1;
            nhtListEmployee.Add(emp);
            return RedirectToAction("NhtIndex");
        }

        [HttpGet]
        public ActionResult NhtEdit(int id)
        {
            var emp = nhtListEmployee.FirstOrDefault(e => e.NhtId == id);
            return View(emp);
        }

        [HttpPost]
        public ActionResult NhtEditPUT(NhtEmployee emp)
        {
            var old = nhtListEmployee.FirstOrDefault(e => e.NhtId == emp.NhtId);
            if (old != null)
            {
                old.NhtName = emp.NhtName;
                old.NhtBirthDay = emp.NhtBirthDay;
                old.NhtEmail = emp.NhtEmail;
                old.NhtPhone = emp.NhtPhone;
                old.NhtSalary = emp.NhtSalary;
                old.NhtStatus = emp.NhtStatus;
            }
            return RedirectToAction("NhtIndex");
        }

        public ActionResult NhtDelete(int id)
        {
            var emp = nhtListEmployee.FirstOrDefault(e => e.NhtId == id);
            if (emp != null) nhtListEmployee.Remove(emp);
            return RedirectToAction("NhtIndex");
        }
    }
}
