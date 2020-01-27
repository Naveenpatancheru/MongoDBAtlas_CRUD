using BenchmarkDotNet.Toolchains.Roslyn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;

namespace Crud_MongoDB.Controllers
{
    public class DocketController : Controller
    {
        // GET: Docket
        public ActionResult Index()
        {
            Models.MongoHelper.ConnectionToMongo();
            Models.MongoHelper.dockets_collection =
                Models.MongoHelper.database.GetCollection<Models.Docket>("Dockets");
            var filter = Builders<Models.Docket>.Filter.Ne("_id","");
            var result = Models.MongoHelper.dockets_collection.Find(filter).ToList();
            return View(result);
        }

        // GET: Docket/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Docket/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Docket/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Models.MongoHelper.ConnectionToMongo();
                Models.MongoHelper.dockets_collection =
                    Models.MongoHelper.database.GetCollection<Models.Docket>("Dockets");

                object id = GenerateRandomId(24);
                Models.MongoHelper.dockets_collection.InsertOneAsync(new Models.Docket
                {

                    _id = id,
                    docketDescription = collection["docketDescription"],
                    docketCaseId = collection["docketCaseId"],
                    docketCode = collection["docketCode"],
                    myProperty = collection["myProperty"]
    });
                
               return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private static Random random = new Random();
        private object GenerateRandomId(int v)
        {
            string strarray = "ABCDEFGHIJKLMNOP123456789";
            return new string(Enumerable.Repeat(strarray, v).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        // GET: Docket/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Docket/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Docket/Delete/5
        public ActionResult Delete(string id)
        {
            Models.MongoHelper.ConnectionToMongo();
            Models.MongoHelper.dockets_collection =
                Models.MongoHelper.database.GetCollection<Models.Docket>("Dockets");
            var filter = Builders<Models.Docket>.Filter.Eq("_id", id);
            var result = Models.MongoHelper.dockets_collection.Find(filter).FirstOrDefault();
            return View(result);
        }

        // POST: Docket/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Models.MongoHelper.ConnectionToMongo();
                Models.MongoHelper.dockets_collection =
                    Models.MongoHelper.database.GetCollection<Models.Docket>("Dockets");
                var filter = Builders<Models.Docket>.Filter.Eq("_id", id);
                var result = Models.MongoHelper.dockets_collection.DeleteOneAsync(filter);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
