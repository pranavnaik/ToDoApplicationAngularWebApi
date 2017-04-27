using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoApplication.DAL;
using ToDoApplication.Models;

namespace ToDoApplication.Controllers
{
    public class ToDoController : ApiController
    {
        public List<Task> Post(Task obj)
        {
            obj.AssignedBy = "Admin";//Prnv: hardcoded for the time being
            //TODO: get username from viewbag and assign here


            DbAccessLayer dal = new DbAccessLayer();
            if (ModelState.IsValid)
            {
                dal.Tasks.Add(obj);
            dal.SaveChanges();
            }
            DbAccessLayer dl = new DbAccessLayer();
            List<Task> TaskAll = dl.Tasks.ToList<Task>();
            return TaskAll;

        }

        public List<Task> Get()
        {
            //Read the query string to know wheter to load all tasks or a selected task
            var UrlKeyValues = ControllerContext.Request.GetQueryNameValuePairs();

            string TaskCode = UrlKeyValues.SingleOrDefault(x => x.Key == "TaskCode").Value;


      
            DbAccessLayer dal = new DbAccessLayer();
            List<Task> TaskAll = new List<Task>();//Empty list for the first time 

            if (TaskCode != null)
            {
                TaskAll = (from t in dal.Tasks
                           where t.TaskCode == TaskCode
                           select t).ToList<Task>();

            }
            else
            {
                TaskAll = dal.Tasks.ToList<Task>();

            }

            // Thread.Sleep(2000);//Prnv: this daley was put just to check ajax behaviour of the appln 
            return TaskAll;
        }

        public List<Task> Put(Task t)
        {
            //update the selected task n reload the entries
            DbAccessLayer db = new DbAccessLayer();
            Task taskupdate = (from temp in db.Tasks
                               where temp.TaskCode == t.TaskCode
                               select temp).ToList<Task>()[0];

            taskupdate.TaskName = t.TaskName;
            taskupdate.TaskDescription = t.TaskDescription;
            taskupdate.IsComplete = Convert.ToBoolean(t.IsComplete);
            taskupdate.EnteredDate =t.EnteredDate;
            taskupdate.AssignedTo = t.AssignedTo;
  
            List<Task> tasks = db.Tasks.ToList<Task>();
            return tasks;
        }


        public List<Task> Delete(Task t)
        {
            //delete the selected task n reload the entries
            DbAccessLayer db = new DbAccessLayer();
            Task taskDelete = (from temp in db.Tasks
                               where temp.TaskCode == t.TaskCode
                               select temp).ToList<Task>()[0];
            db.Tasks.Remove(taskDelete);
            db.SaveChanges();
            //return refreshed list
            List<Task> tasks = db.Tasks.ToList<Task>();
            return tasks;

        }


    }
}
