using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using NhtLesson08.Models;

namespace NhtLesson08.Controllers
{
    public class NhtAccountController : Controller
    {
        private static List<NhtAccount> nhtListAccount = new List<NhtAccount>()
        {
            new NhtAccount
                {
                    NhtId = 230022113,
                    NhtFullName = "Nguyễn Huy Thông",
                    NhtEmail = "buythong04@gmail.com@gmail.com",
                    NhtPhone = "0978611889",
                    NhtAddress = "Lớp K23CNT2",
                    NhtAvatar = "",
                    NhtBirthday = new DateTime(1979, 5, 25),
                    NhtGender = "Nam",
                    NhtPassword = "0967599269",
                    NhtFacebook = ""
                },
                new NhtAccount
                {
                    NhtId = 2,
                    NhtFullName = "Trần Thị B",
                    NhtEmail = "tranthib@example.com",
                    NhtPhone = "0987654321",
                    NhtAddress = "456 Đường B, Quận 3, TP.HCM",
                    NhtAvatar = "avatar2.jpg",
                    NhtBirthday = new DateTime(1992, 8, 15),
                    NhtGender = "Nữ",
                    NhtPassword = "password2",
                    NhtFacebook = "https://facebook.com/tranthib"
                },
                new NhtAccount
                {
                    NhtId = 3,
                    NhtFullName = "Lê Văn C",
                    NhtEmail = "levanc@example.com",
                    NhtPhone = "0911222333",
                    NhtAddress = "789 Đường C, Quận 5, TP.HCM",
                    NhtAvatar = "avatar3.jpg",
                    NhtBirthday = new DateTime(1988, 12, 1),
                    NhtGender = "Nam",
                    NhtPassword = "password3",
                    NhtFacebook = "https://facebook.com/levanc"
                },
                new NhtAccount
                {
                    NhtId = 4,
                    NhtFullName = "Phạm Thị D",
                    NhtEmail = "phamthid@example.com",
                    NhtPhone = "0909876543",
                    NhtAddress = "321 Đường D, Quận 7, TP.HCM",
                    NhtAvatar = "avatar4.jpg",
                    NhtBirthday = new DateTime(1995, 3, 10),
                    NhtGender = "Nữ",
                    NhtPassword = "password4",
                    NhtFacebook = "https://facebook.com/phamthid"
                },
                new NhtAccount
                {
                    NhtId = 5,
                    NhtFullName = "Hoàng Văn E",
                    NhtEmail = "hoangvane@example.com",
                    NhtPhone = "0933444555",
                    NhtAddress = "654 Đường E, Quận 10, TP.HCM",
                    NhtAvatar = "avatar5.jpg",
                    NhtBirthday = new DateTime(1991, 7, 22),
                    NhtGender = "Nam",
                    NhtPassword = "password5",
                    NhtFacebook = "https://facebook.com/hoangvane"
                }
        };

        // GET: NhtAccountController
        public ActionResult NhtIndex()
        {
            return View(nhtListAccount);
        }

        // GET: NhtAccountController/NhtDetails/5
        public ActionResult NhtDetails(int id)
        {
            var account = nhtListAccount.FirstOrDefault(a => a.NhtId == id);
            if (account == null) return NotFound();
            return View(account);
        }


        // GET: NhtAccountController/NhtCreate
        public ActionResult NhtCreate()
        {
            var nhtModel = new NhtAccount();
            return View(nhtModel);
        }

        // POST: NhtAccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NhtCreate(NhtAccount nhtModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    nhtListAccount.Add(nhtModel);
                    return RedirectToAction(nameof(NhtIndex));
                }

                return View(nhtModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Có lỗi xảy ra khi thêm mới: " + ex.Message);
                return View(nhtModel);
            }
        }

        // GET: NhtAccountController/NhtEdit/5
        public ActionResult NhtEdit(int id)
        {
            var account = nhtListAccount.FirstOrDefault(a => a.NhtId == id);
            if (account == null) return NotFound();
            return View(account);
        }

        // POST: NhtAccountController/NhtEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NhtEdit(int id, NhtAccount nhtModel)
        {
            try
            {
                var account = nhtListAccount.FirstOrDefault(a => a.NhtId == id);
                if (account == null) return NotFound();

                if (ModelState.IsValid)
                {
                    // Cập nhật thông tin
                    account.NhtFullName = nhtModel.NhtFullName;
                    account.NhtEmail = nhtModel.NhtEmail;
                    account.NhtPhone = nhtModel.NhtPhone;
                    account.NhtAddress = nhtModel.NhtAddress;
                    account.NhtAvatar = nhtModel.NhtAvatar;
                    account.NhtBirthday = nhtModel.NhtBirthday;
                    account.NhtGender = nhtModel.NhtGender;
                    account.NhtPassword = nhtModel.NhtPassword;
                    account.NhtFacebook = nhtModel.NhtFacebook;

                    return RedirectToAction(nameof(NhtIndex));
                }

                return View(nhtModel);
            }
            catch
            {
                return View(nhtModel);
            }
        }


        // GET: NhtAccountController/NhtDelete/5
        public ActionResult NhtDelete(int id)
        {
            var account = nhtListAccount.FirstOrDefault(a => a.NhtId == id);
            if (account == null) return NotFound();
            return View(account);
        }

        // POST: NhtAccountController/NhtDeleteConfirmed/5
        [HttpPost, ActionName("NhtDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult NhtDeleteConfirmed(int id)
        {
            try
            {
                var account = nhtListAccount.FirstOrDefault(a => a.NhtId == id);
                if (account != null)
                {
                    nhtListAccount.Remove(account);
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
