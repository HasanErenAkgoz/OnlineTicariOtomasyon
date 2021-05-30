using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class QrCodeController : Controller
    {
        // GET: QrCode
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Code)
        {
            using (MemoryStream memoryStream=new MemoryStream())
            {
                QRCodeGenerator qRCodeCreate = new QRCodeGenerator();
                QRCodeGenerator.QRCode qrCode = qRCodeCreate.CreateQrCode(Code, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap picture=qrCode.GetGraphic(10))
                {
                    picture.Save(memoryStream, ImageFormat.Png);
                    ViewBag.QrCode = "data:image/png;base64,"+Convert.ToBase64String(memoryStream.ToArray());
                }

            }
            return View();
        }
    }
}