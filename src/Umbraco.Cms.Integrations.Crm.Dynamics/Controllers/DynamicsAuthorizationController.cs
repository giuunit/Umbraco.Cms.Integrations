﻿using System.Threading.Tasks;

using Umbraco.Cms.Integrations.Crm.Dynamics.Configuration;
using Umbraco.Cms.Integrations.Crm.Dynamics.Services;
using Umbraco.Cms.Integrations.Crm.Dynamics.Models;

using static Umbraco.Cms.Integrations.Crm.Dynamics.DynamicsComposer;

#if NETCOREAPP
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using Umbraco.Cms.Web.Common.Controllers;
#else
using System.Web.Mvc;
using System.Configuration;

using Umbraco.Web.WebApi;
#endif

namespace Umbraco.Cms.Integrations.Crm.Dynamics.Controllers
{
    public class DynamicsAuthorizationController : UmbracoApiController
    {
        [HttpGet]
#if NETCOREAPP
        public IActionResult OAuth(string code)
#else
        public ActionResult OAuth(string code)
#endif
        { 
            return new ContentResult
            {
                Content = string.IsNullOrEmpty(code)
                    ? JavascriptResponse.Fail("Authorization process failed.")
                    : JavascriptResponse.Ok(code),
                ContentType = "text/html"
            };
        }
    }
}
