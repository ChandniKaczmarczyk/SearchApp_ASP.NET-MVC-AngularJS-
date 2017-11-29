using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SearchApp.DataAccessLayer;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using SearchApp.Models;
namespace SearchApp.Controllers
{
    public class HomeController : Controller
    {
        DataBaseClass dbClass = new DataBaseClass();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // Write Action method to Get Data from the DataAccess Layer 
        [HandleError]
        public JsonResult GetAccounts()
        {
            try
            {
                DataSet ds = dbClass.GetAccounts();
                List<Accounts> listAccounts = new List<Accounts>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    listAccounts.Add(new Accounts
                    {
                        Number = dr["Number"].ToString(),
                        Name = dr["Name"].ToString(),
                        Balance = dr["Balance"].ToString()
                    });
                }
                return Json(listAccounts, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}