using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MobilePhoneListing.Data;
using MobilePhoneListing.Models;
using System.IO;
using System.Net.Mail;
using System.Text;

namespace MobilePhoneListing.Controllers
{
  
    public class ProductsController : BaseController
    {
        private ProductContext db = new ProductContext();

        // GET: Products
        public ActionResult Index(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                return View(db.Products.ToList().Where(p=>p.ProductName.Contains(searchString)));
            }
            return View(db.Products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
      //  public ActionResult Create([Bind(Include = "Id,ProductName,ShortDescription,LongDescription,Specification,Price,ImagePath")] Product product)
        public ActionResult Create(Product product)
        {
            string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
            string extension = Path.GetExtension(product.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            product.ImagePath = "~/Image/"+fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            product.ImageFile.SaveAs(fileName);

            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                Success(string.Format("<b>{0}</b> was created successfully", product.ProductName), true);
                return RedirectToAction("Index");
            }
            ModelState.Clear();
            return View(product);
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductName,ShortDescription,LongDescription,Specification,Price,ImagePath")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                Success(string.Format("<b>{0}</b> was successfully edited", product.ProductName), true);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            Success(string.Format("<b>{0}</b> was successfully removed", product.ProductName), true);
            return RedirectToAction("Index");
        }

        public ActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(string emailTo,Product product)
        {
            if (emailTo == null||emailTo=="")
            {
                Warning("Email address can not be empty");
                return RedirectToAction("Index");
            }

            string emailFrom = "market@mobilelisting.co.za";
            MailMessage message = new MailMessage(emailFrom,emailTo);
            string mailbody = "This is what you have odered: Product Name " + product.ProductName + ", Description " + product.ShortDescription + ", at a Price of R" + product.Price;
            message.CC.Add(new MailAddress("market@mobilelisting.co.za"));
            message.Subject = product.ProductName + " Product";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com",587);
            NetworkCredential networkCredential = new NetworkCredential("developergman@gmail.com", "Developer_123");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = networkCredential;
            try
            {
                client.Send(message);
                Success(string.Format("Email sent successful", message),true);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                Danger(ViewBag.Message);
            }
           
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
