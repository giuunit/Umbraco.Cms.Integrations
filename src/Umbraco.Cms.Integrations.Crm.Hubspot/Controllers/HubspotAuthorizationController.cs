﻿using Umbraco.Cms.Integrations.Crm.Hubspot.Models;

#if NETCOREAPP
using Microsoft.AspNetCore.Mvc;

using Umbraco.Cms.Web.Common.Controllers;
#else
using System.Web.Mvc;

using Umbraco.Web.WebApi;
#endif

namespace Umbraco.Cms.Integrations.Crm.Dynamics.Controllers
{
    public class HubspotAuthorizationController : UmbracoApiController
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
