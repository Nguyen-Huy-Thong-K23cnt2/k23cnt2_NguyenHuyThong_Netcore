using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhtLesson07.Models;

namespace NhtLesson07.Controllers
{
    public class NhtEmplyeeController : Controller
    {
        //Mock data:
        private static List<NhtEmplyee> nhtListEmlylee = new List<NhtEmplyee>()
        {
            new NhtEmplyee
                {
                    NhtID = 231090010,
                    NhtName = "Nguyễn Nguyễn Huy Thông",
                    NhtBirthDay = new DateTime(2005, 9, 4),
                    NhtEmail = "bhuythong04@gmail.com",
                    NhtPhone = "0967599296",
                    NhtSalary = 15000000m,
                    NhtStatus = true
                },
                new NhtEmplyee
                {
                    NhtID = 2,
                    NhtName = "Trần Thị Bình",
                    NhtBirthDay = new DateTime(1993, 11, 15),
                    NhtEmail = "binh.tran@example.com",
                    NhtPhone = "0911123456",
                    NhtSalary = 18000000m,
                    NhtStatus = true
                },
                new NhtEmplyee
                {
                    NhtID = 3,
                    NhtName = "Lê Văn Cường",
                    NhtBirthDay = new DateTime(1988, 2, 9),
                    NhtEmail = "cuong.le@example.com",
                    NhtPhone = "0903344556",
                    NhtSalary = 20000000m,
                    NhtStatus = false
                },
                new NhtEmplyee
                {
                    NhtID = 4,
                    NhtName = "Phạm Thị Dung",
                    NhtBirthDay = new DateTime(1990, 7, 30),
                    NhtEmail = "dung.pham@example.com",
                    NhtPhone = "0932123456",
                    NhtSalary = 17000000m,
                    NhtStatus = false
                },
                new NhtEmplyee
                {
                    NhtID = 5,
                    NhtName = "Đỗ Minh Huy",
                    NhtBirthDay = new DateTime(1992, 4, 10),
                    NhtEmail = "huy.do@example.com",
                    NhtPhone = "0987654321",
                    NhtSalary = 6000000m,
                    NhtStatus = true
                }
           
            };
        // GET: NhtEmplyeeController
        public ActionResult NhtIndex()
        {
            return View(nhtListEmlylee);
        }

        // GET: NhtEmplyeeController/Details/5
        public ActionResult NhtDetails(int id)
        {
            var nhtEmplyee = nhtListEmlylee.FirstOrDefault(x => x.NhtID == id);
            return View(nhtEmplyee);
        }

        // GET: NhtEmplyeeController/NhtCreate
        public ActionResult NhtCreate()
        {
            var nhtEmplylee = new NhtEmplyee();
            return View(nhtEmplylee);
        }

        // POST: NhtEmplyeeController/NhtCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NhtCreate(NhtEmplyee nhtModel)
        {
            try
            { 
                //thêm mới nhân viên
                nhtModel.NhtID = nhtListEmlylee.Max(x=> x.NhtID) +1 ;
                nhtListEmlylee.Add(nhtModel);
                return RedirectToAction(nameof(NhtIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: NhtEmplyeeController/NhtEdit/5
        public ActionResult NhtEdit(int id)
        {
            var nhtEmplyee = nhtListEmlylee.FirstOrDefault(x=>x.NhtID == id);
            return View();
        }

        // POST: NhtEmplyeeController/NhtEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NhtEdit(int id, NhtEmplyee nhtModel)
        {
            try
            {
                for (int i = 0; i < nhtListEmlylee.Count; i++)
                {
                    if (nhtListEmlylee[i].NhtID == id )
                    {
                        nhtListEmlylee[i] = nhtModel;
                        break;
                    }    
                }
                return RedirectToAction(nameof(NhtIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: NhtEmplyeeController/Delete/5
        public ActionResult NhtDelete(int id)
        {
            var nhtEmplyee = nhtListEmlylee.FirstOrDefault(x => x.NhtID == id);
            return View(nhtEmplyee);
        }

        // POST: NhtEmplyeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, NhtEmplyee nhtModel)
        {
            try
            {
                for (int i = 0; i < nhtListEmlylee.Count; i++)
                {
                    if (nhtListEmlylee[i].NhtID == id)
                    {
                        nhtListEmlylee[i] = nhtModel;
                        break;
                    }
                }
                return RedirectToAction(nameof(NhtIndex));
            }
            catch
            {
                return View();
            }
        }
    }
}
