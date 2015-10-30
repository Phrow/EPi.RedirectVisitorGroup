﻿using System.Linq;
using System.Web.Mvc;
using EPiServer.Core;
using EPiServer.Editor;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;

namespace Geta.EPi.RedirectVisitorGroup
{
    public class RedirectAttribute : ActionFilterAttribute
    {
        public Injected<PageRouteHelper> PageRouteHelper { get; set; }
        public Injected<UrlResolver> UrlResolver { get; set; }
 
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (PageEditing.PageIsInEditMode)
            {
                return;
            }

            PageData page = PageRouteHelper.Service.Page;

            // ReSharper disable once SuspiciousTypeConversion.Global
            if (!(page is IRedirectVisitorGroup))
            {
                return;
            }

            // ReSharper disable once SuspiciousTypeConversion.Global
            var redirectPage = (page as IRedirectVisitorGroup).RedirectContentArea.FilteredItems.Select(x => x.GetContent()).FirstOrDefault();
            if (redirectPage == null)
            {
                return;
            }

            // TODO look for shortcut external page
            filterContext.Result = new RedirectResult(UrlResolver.Service.GetUrl(redirectPage.ContentLink));
        }
    }
}