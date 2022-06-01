using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace StellaguardProductAssociation.Helpers
{
    public static class HtmlExtensions
    {
        public static IHtmlString ConditionallyReadOnlyTextBoxFor<TModel, TProperty>(
        this HtmlHelper<TModel> htmlHelper,
        Expression<Func<TModel, TProperty>> expression,
        object htmlAttributes,
        bool disabled
    )
        {
            var attributes = new RouteValueDictionary(htmlAttributes);
            if (disabled)
            {
                attributes["readonly"] = "readonly";
            }
            return htmlHelper.TextBoxFor(expression, attributes);
        }

    }
}