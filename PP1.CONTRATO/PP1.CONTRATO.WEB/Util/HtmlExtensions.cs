using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PP1.CONTRATO.WEB.Util
{
    public class Atribute
    {
        public bool Apend { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
    public static class HtmlHelperExtensions
    {
        public static RouteValueDictionary DisabledIf(this object htmlAttributes, bool disabled)
        {
            return htmlAttributes.AppendIf(disabled, "disabled", "disabled");
        }

        public static RouteValueDictionary ReadOnlyIf(this object htmlAttributes, bool disabled)
        {
            return htmlAttributes.AppendIf(disabled, "readonly", "readonly");
        }

        public static RouteValueDictionary HideIf(this object htmlAttributes, bool disabled)
        {
            return htmlAttributes.AppendIf(disabled, "class", "hide");
        }

        public static RouteValueDictionary AppendIf(this object htmlAttributes, bool condition, string attributeName, string attributeValue)
        {
            var attributes = new RouteValueDictionary(htmlAttributes);

            if (condition)
                attributes[attributeName] = attributeValue;

            return attributes;
        }

        public static RouteValueDictionary AppendIf(this object htmlAttributes, List<Atribute> atributes)
        {
            var attributes = new RouteValueDictionary(htmlAttributes);

            foreach (var item in atributes.Where(u => u.Apend))
            {
                attributes[item.Key] = item.Value;
            }
            return attributes;
        }

        public static MvcHtmlString JavascriptAlert(this HtmlHelper htmlhelper, string message = null)
        {
            const string alert = "<div class=\"alert alert-danger\" ng-if=\"alert.show\">" +
                                 "    <button class=\"close\" ng-click=\"alert.show = false\">&times;</button>" +
                                 "    {0}" +
                                 "</div>";

            const string defaultMessage = "<strong>Atenção!</strong> Existem erros no seu formulário, verifique!";

            return MvcHtmlString.Create(string.Format(alert, !string.IsNullOrEmpty(message) ? message : defaultMessage));
        }

        public static MvcHtmlString CustomValidationSummary(this HtmlHelper htmlhelper)
        {
            return System.Web.Mvc.Html.ValidationExtensions.ValidationSummary(htmlhelper, true, "Campos obrigatórios não preenchidos, verifique!", new { @class = "alert alert-danger" });
        }

        public static IDisposable BeginFormGroup(this HtmlHelper helper, object htmlAttributes = null)
        {
            var attributes = AnonymousToDictionary(htmlAttributes);
            if (!attributes.ContainsKey("class"))
            {
                attributes.Add("class", "form-group");
            }
            else if (attributes["class"].IndexOf("form-group") < 0)
            {
                attributes["class"] += " form-group";
                attributes["class"] = attributes["class"].Trim();
            }

            return new CustomView(helper, "div", attributes);
        }

        public static IDisposable BeginFormGroupFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
        {
            var attributes = AnonymousToDictionary(htmlAttributes);
            if (!attributes.ContainsKey("class"))
            {
                attributes.Add("class", "form-group");
            }
            else if (attributes["class"].IndexOf("form-group") < 0)
            {
                attributes["class"] += " form-group";
                attributes["class"] = attributes["class"].Trim();
            }

            if (helper.ViewData.ModelState.ContainsKey(ExpressionHelper.GetExpressionText(expression)))
            {
                attributes["class"] += " has-error";
                attributes["class"] = attributes["class"].Trim();
            }

            return new CustomView(helper, "div", attributes);
        }


        public static IDisposable BeginFormContainer<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
        {
            var attributes = AnonymousToDictionary(htmlAttributes);
            if (!attributes.ContainsKey("class"))
            {
                attributes.Add("class", "form-layout");
            }
            else if (attributes["class"].IndexOf("form-layout") < 0)
            {
                attributes["class"] += " form-layout";
                attributes["class"] = attributes["class"].Trim();
            }

            if (helper.ViewData.ModelState.ContainsKey(ExpressionHelper.GetExpressionText(expression)))
            {
                var state = helper.ViewData.ModelState[ExpressionHelper.GetExpressionText(expression)];
                if (state.Errors.Any())
                {
                    attributes["class"] += " has-error";
                    attributes["class"] = attributes["class"].Trim();
                }
            }

            return new CustomView(helper, "div", attributes);
        }

        public static IDisposable BeginFormContainer<TModel>(this HtmlHelper<TModel> helper, string expression, object htmlAttributes = null)
        {
            var attributes = AnonymousToDictionary(htmlAttributes);
            if (!attributes.ContainsKey("class"))
            {
                attributes.Add("class", "form-layout");
            }
            else if (attributes["class"].IndexOf("form-layout") < 0)
            {
                attributes["class"] += " form-layout";
                attributes["class"] = attributes["class"].Trim();
            }

            if (helper.ViewData.ModelState.ContainsKey(ExpressionHelper.GetExpressionText(expression)))
            {
                var state = helper.ViewData.ModelState[ExpressionHelper.GetExpressionText(expression)];
                if (state.Errors.Any())
                {
                    attributes["class"] += " has-error";
                    attributes["class"] = attributes["class"].Trim();
                }
            }

            return new CustomView(helper, "div", attributes);
        }

        public static Dictionary<string, string> AnonymousToDictionary(object data)
        {
            if (data == null) return new Dictionary<string, string>();

            return (from x in data.GetType().GetProperties() select x).ToDictionary(x => x.Name, x => (x.GetGetMethod().Invoke(data, null) == null ? "" : x.GetGetMethod().Invoke(data, null).ToString()));
        }
    }

    class CustomView : IDisposable
    {
        private HtmlHelper helper;
        private string _tagName;

        public CustomView(HtmlHelper helper, string tagName, Dictionary<string, string> htmlAttributes)
        {
            #region properties
            TagBuilder div = new TagBuilder(tagName);

            foreach (var prop in htmlAttributes)
            {
                div.Attributes.Add(prop.Key, prop.Value);
            }
            #endregion

            _tagName = tagName;
            this.helper = helper;
            this.helper.ViewContext.Writer.Write(div.ToString().Replace(string.Format("</{0}>", tagName), string.Empty));
        }

        public void Dispose()
        {
            this.helper.ViewContext.Writer.Write(string.Format("</{0}>", _tagName));
        }
    }
}