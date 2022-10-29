using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Project.BLL.ManagerServices.Abstracts;
using Project.COREUI.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Project.COREUI.Controllers
{
    public class ReportController : Controller
    {
        IContactManager _cMan;
        INewManager _nMan;

        public ReportController(IContactManager cMan, INewManager nMan)
        {
            _cMan = cMan;
            _nMan = nMan;
        }

        public IActionResult Index()
        {
            return View();
        }

     


        public List<ContactModel> ContactList()
        {
            List<ContactModel> contactModels = new List<ContactModel>();
            _cMan.SelectViaClass(x => new ContactModel
            {
                ContactID = x.ID,
                ContactName = x.Name,
                ContactDate = x.CreatedDate,
                ContactMail = x.Mail,
                ContactMessage = x.Message
            }).ToList();
                
            return contactModels;
        }

        public IActionResult ContactReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Mesaj Listesi");
                workSheet.Cell(1, 1).Value = "Mesaj ID";
                workSheet.Cell(1, 2).Value = "Mesaj Gönderen";
                workSheet.Cell(1, 3).Value = "Mail Adresi";
                workSheet.Cell(1, 4).Value = "Mesaj İçeriği";
                workSheet.Cell(1, 5).Value = "Mesaj Tarihi";

                int contactRowCount = 2;
                foreach (var item in ContactList())
                {
                    workSheet.Cell(contactRowCount, 1).Value = item.ContactID;
                    workSheet.Cell(contactRowCount, 2).Value = item.ContactName;
                    workSheet.Cell(contactRowCount, 3).Value = item.ContactMail;
                    workSheet.Cell(contactRowCount, 4).Value = item.ContactMessage;
                    workSheet.Cell(contactRowCount, 5).Value = item.ContactDate;
                    contactRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MesajRapor.xlsx");
                }
            }
        }

        public List<NewModel> NewList()
        {
            List<NewModel> announcementModels = new List<NewModel>();

            _nMan.SelectViaClass(x=> new NewModel
            {
                NewID = x.ID,
                Description = x.Description,
                Title = x.Title,
                CreatedDate = x.CreatedDate
            }).ToList();
            return announcementModels;
           
         
        }

        public IActionResult DuyuruReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Duyuru Listesi");
                workSheet.Cell(1, 1).Value = "Duyuru ID";
                workSheet.Cell(1, 2).Value = "Duyuru Başlığı";
                workSheet.Cell(1, 3).Value = "Duyuru Tarihi";
                workSheet.Cell(1, 4).Value = "Duyuru İçeriği";
            

                int contactRowCount = 2;
                foreach (var item in NewList())
                {
                    workSheet.Cell(contactRowCount, 1).Value = item.NewID;
                    workSheet.Cell(contactRowCount, 2).Value = item.Title;
                    workSheet.Cell(contactRowCount, 3).Value = item.CreatedDate;
                    workSheet.Cell(contactRowCount, 4).Value = item.Description;
          
                    contactRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DuyuruRapor.xlsx");
                }
            }
        }

    }
}
