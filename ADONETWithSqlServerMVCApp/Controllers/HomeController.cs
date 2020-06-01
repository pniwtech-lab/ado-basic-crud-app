using ADONETWithSqlServerMVCApp.Constants;
using ADONETWithSqlServerMVCApp.DBAccessLayer;
using ADONETWithSqlServerMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace ADONETWithSqlServerMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeeInfoAccess dbAccess = new EmployeeInfoAccess();

        public ActionResult Index()
        {
            try
            {
                DataSet ds = dbAccess.Show_data();
                ViewBag.emp = ds.Tables[0];
            }
            catch (Exception)
            {
                throw;
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Demo Application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddRecord()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRecord(EmployeeInfo info)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool boolIsRecordAdded = dbAccess.Add_record(info);
                    if (boolIsRecordAdded)
                    {
                        TempData["AlertMessage"] = new AlertMessage
                        {
                            AlertTypeCss = AlertTypeCss.SUCCSESS,
                            AlertTitle = "Record Added Successfully !",
                        };

                        ModelState.Clear();
                    }
                    else
                    {
                        TempData["AlertMessage"] = new AlertMessage
                        {
                            AlertTypeCss = AlertTypeCss.FAILED,
                            AlertTitle = "Failed to Add record !",
                            Message = "Some server issue is occured, Please contact to ADMIN.."
                        };
                    }
                }
            }
            catch
            {
                TempData["AlertMessage"] = new AlertMessage
                {
                    AlertTypeCss = AlertTypeCss.FAILED,
                    AlertTitle = "Server Issue!",
                    Message = "Some problem is occured, Please contact to ADMIN.."
                };
                ModelState.Clear();
            }
            return View();
        }

        public ActionResult EditRecord(int id)
        {
            try
            {
                EmployeeInfo employeeInfo = dbAccess.Get_employee_by_id(id);
                return View(employeeInfo);
            }
            catch
            {
                throw;
            }
            
        }

        [HttpPost]
        public ActionResult EditRecord(EmployeeInfo info)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool boolIsRecordUpdated = dbAccess.Update_record(info);

                    if (boolIsRecordUpdated)
                    {
                        TempData["AlertMessage"] = new AlertMessage
                        {
                            AlertTypeCss = AlertTypeCss.SUCCSESS,
                            AlertTitle = "Record Updated Successfully !",
                        };
                    }
                    else
                    {
                        TempData["AlertMessage"] = new AlertMessage
                        {
                            AlertTypeCss = AlertTypeCss.FAILED,
                            AlertTitle = "Failed to update record !",
                            Message = "Some server issue is occured, Please contact to ADMIN.."
                        };
                    }
                }
            }
            catch
            {
                TempData["AlertMessage"] = new AlertMessage
                {
                    AlertTypeCss = AlertTypeCss.FAILED,
                    AlertTitle = "Server Issue!",
                    Message = "Some problem is occured, Please contact to ADMIN.."
                };
            }

            return View();
        }

        public ActionResult DeleteRecord(int id)
        {
            bool boolIsRecordDeleted = dbAccess.Delete_record(id);

            if (boolIsRecordDeleted)
            {
                TempData["AlertMessage"] = new AlertMessage
                {
                    AlertTypeCss = AlertTypeCss.SUCCSESS,
                    AlertTitle = "Record Deleted Successfully !",
                    Message = "Record is permanently deleted. "
                };
            }
            else
            {
                TempData["AlertMessage"] = new AlertMessage
                {
                    AlertTypeCss = AlertTypeCss.FAILED,
                    AlertTitle = "Failed to delete record !",
                    Message = "Some server issue occured, Please contact to ADMIN.."
                };
            }

            return RedirectToAction("Index");
        }

        // This action is used for Dummy page only
        //public ActionResult showData()
        //{
        //    Employee emp = new Employee();
        //    List<EmployeeAccessLayer> List_EmployeeAccess = emp.GetData();
        //    return View(List_EmployeeAccess);
        //}
    }
}