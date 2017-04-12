using CentiSoftCore.BLL;
using CentiSoftCore.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CentiSoftMVCWebCourse3.Controllers
{
    public class SecurityAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
            string tokenkey = "centisoft_token";

            HttpResponseMessage responseMessage = new HttpResponseMessage();
            IClientFacade clientFacade = new ClientFacade();
            Client client = null;

            if (actionContext.Request.Headers.Contains(tokenkey))
            {
                IEnumerable<string> headerValue = actionContext.Request.Headers.GetValues(tokenkey);
                string token = headerValue.FirstOrDefault();
                client = clientFacade.LoadClient(token);

                if (client == null)
                {
                    responseMessage.StatusCode = HttpStatusCode.Forbidden;
                    responseMessage.ReasonPhrase = "Token is invalid";
                }
                else
                {
                    responseMessage.StatusCode = HttpStatusCode.OK;
                    responseMessage.ReasonPhrase = "Token Valid";
                    responseMessage.Content = new StringContent(client.Id.ToString());
                    actionContext.Request.Properties.Add(new KeyValuePair<string, object>("id", client.Id));
                }
            }
            else
            {
                responseMessage.StatusCode = HttpStatusCode.Forbidden;
                responseMessage.ReasonPhrase = "No token in header";
            }

        }
    }
}