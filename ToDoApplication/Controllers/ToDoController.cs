using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ToDoApplication.DAL;
using ToDoApplication.Models;
using ToDoApplication.ViewModel;

namespace ToDoApplication.Controllers
{
    [Authorize]
    public class ToDoUIController : Controller
    {
        public ActionResult Enter()
        {
            return View("EnterToDo");
        }

        //#######Prnv: all the code is shifted to webapi and the class name is renamed#######

        //public ActionResult Enter()
        //{
        //    DbAccessLayer db = new DbAccessLayer();
        //    ViewBag.users = db.Users.Select(m => m.UserName).ToList();
        //    TasksVM vm = new TasksVM();
        //    vm.Tasks = new Task();
        //    return View("EnterToDo", vm);
        //}

        //public ActionResult Submit(Task obj)
        //{
        //    obj.AssignedBy = "Admin";
        //    obj.EnteredDate = Convert.ToDateTime("12/12/2014");

        //    DbAccessLayer dal = new DbAccessLayer();
        //    //    if (ModelState.IsValid)
        //    //     {
        //    dal.Tasks.Add(obj); //in-memory updation
        //    dal.SaveChanges(); //physical commit
        //                       //      }
        //    DbAccessLayer dl = new DbAccessLayer();
        //    List<Task> TaskAll = dl.Tasks.ToList<Task>();
        //    return Json(TaskAll, JsonRequestBehavior.AllowGet);//return json result of task collections

        //}


        //public ActionResult GetTasks()
        //{
        //    DbAccessLayer dal = new DbAccessLayer();
        //    List<Task> TaskAll = dal.Tasks.ToList<Task>();
        //    // Thread.Sleep(2000); 
        //    return Json(TaskAll, JsonRequestBehavior.AllowGet);
        //}

        //public List<Task> UpdateSelectedTask(Task t)
        //{
        //    //update the selected task n reload the entries
        //    DbAccessLayer db = new DbAccessLayer();
        //    Task taskupdate = (from temp in db.Tasks
        //                       where temp.TaskCode == t.TaskCode
        //                       select temp).ToList<Task>()[0];

        //    taskupdate.TaskName = Request.Form["Tasks.TaskName"];
        //    taskupdate.TaskDescription = Request.Form["Tasks.TaskDescription"];
        //    taskupdate.IsComplete = Convert.ToBoolean(Request.Form.GetValues("Tasks.IsComplete")[0]);
        //    taskupdate.EnteredDate = DateTime.Parse(Request.Form["Tasks.EnteredDate"]);
        //    taskupdate.AssignedTo = Request.Form["AssignedTo"];
        //    //return refreshed list
        //    List<Task> tasks = db.Tasks.ToList<Task>();
        //    return tasks;
        //}

        //public List<Task> DeleteSelectedTas(Task t)
        //{
        //    //delete the selected task n reload the entries
        //    DbAccessLayer db = new DbAccessLayer();
        //    Task taskDelete = (from temp in db.Tasks
        //                       where temp.TaskCode == t.TaskCode
        //                       select temp).ToList<Task>()[0];
        //    db.Tasks.Remove(taskDelete);
        //    db.SaveChanges();
        //    //return refreshed list
        //    List<Task> tasks = db.Tasks.ToList<Task>();
        //    return tasks;

        //}

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}