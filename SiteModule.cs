using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.Responses;

namespace BlogRedirect
{
    public class SiteModule : NancyModule
    {
        private const string newBaseUrl = "http://thatextramile.be/blog/";

        public SiteModule()
        {
            Get["/"] = p => Redirect("");
            Get["/blog"] = p => Redirect("");
            Get["/blog/new-here"] = p => Redirect("new-here");
            Get["/blog/recommended-books"] = p => Redirect("recommended-books");

            // some special cases
            Get["/blog/2007/07/nhibernate-mapping-examples/"] = p => Redirect("2011/04/nhibernate-examples/");
            Get["/blog/2008/06/batching-wcf-calls/"] = p => Redirect("2009/11/requestresponse-service-layer-series/");
            Get["/blog/2008/06/the-service-call-batcher/"] = p => Redirect("2009/11/requestresponse-service-layer-series/");
            Get["/blog/2008/07/the-request-response-service-layer/"] = p => Redirect("2009/11/requestresponse-service-layer-series/");

            Get["/blog/(?<year>[\\d]{4})/(?<month>[\\d]{4})/{slug}"] = p => Redirect(string.Format("{0}/{1}/{2}", p.year, p.month, p.slug));
            Get["/blog/page/(?<page>[\\d]*)"] = p => Redirect("page/" + p.page);
            Get["/blog/category/{category}"] = p => Redirect("category/" + p.category);
            Get["/blog/category/{category}/page/(?<page>[\\d]*)"] = p => Redirect(string.Format("category/{0}/page/{1}", p.category, p.page));
        }

        private dynamic Redirect(string urlSuffix)
        {
            return new RedirectResponse(newBaseUrl + urlSuffix, RedirectResponse.RedirectType.Permanent);
        }
    }
}