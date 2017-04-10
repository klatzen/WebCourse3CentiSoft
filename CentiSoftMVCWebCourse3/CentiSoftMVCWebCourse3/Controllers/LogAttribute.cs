using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CentiSoftMVCWebCourse3.Controllers
{
    public class LogAttribute : ActionFilterAttribute {

        private Stopwatch stopwatch;

        public LogAttribute()
        {
            this.stopwatch = new Stopwatch();
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            stopwatch.Start();
            base.OnActionExecuted(actionExecutedContext);
            Trace.WriteLine(string.Format("Action Method {0} executing at {1}", actionExecutedContext.ActionContext.ActionDescriptor, DateTime.Now));
            
    }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
            stopwatch.Stop();
            Trace.WriteLine(string.Format("Action Method {0} executed at {1}. Time elapsed: {2}", actionContext.ActionDescriptor.ActionName, DateTime.Now, stopwatch.ElapsedMilliseconds));
        }
    }
}