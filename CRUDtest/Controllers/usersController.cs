using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUDtest.Models;

namespace CRUDtest.Controllers
{
    public class usersController : Controller
{
    private userDBEntities db = new userDBEntities();

    // GET: users
    public ActionResult Index()
    {
        return View(db.users.ToList());
    }

    // GET: users/Details/5
    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        user user = db.users.Find(id);
        if (user == null)
        {
            return HttpNotFound();
        }
        return View(user);
    }

    // GET: users/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: users/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "id,title,content,created_at,admin_id")] user user)
    {
        if (ModelState.IsValid)
        {
            db.users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(user);
    }

    // GET: users/Edit/5
    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        user user = db.users.Find(id);
        if (user == null)
        {
            return HttpNotFound();
        }
        return View(user);
    }

    // POST: users/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "id,title,content,created_at,admin_id")] user user)
    {
        if (ModelState.IsValid)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(user);
    }

    // GET: users/Delete/5
    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        user user = db.users.Find(id);
        if (user == null)
        {
            return HttpNotFound();
        }
        return View(user);
    }

    // POST: users/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        user user = db.users.Find(id);
        db.users.Remove(user);
        db.SaveChanges();
        return RedirectToAction("Index");
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