using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UTIL
{
    public class Atribute
    {
        public bool Apend { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
    public static class ViewExtensions
    {
        public static MvcHtmlString CustomValidationSummary(this HtmlHelper html, bool closeable = true, bool hideProperties = true, string validationMessage = "", object htmlAttributes = null)
        {
            if (!html.ViewData.ModelState.IsValid)
            {

                TagBuilder div = new TagBuilder("div");
                string properties = string.Empty;

                // adiciona os atributos
                if (htmlAttributes != null)
                {
                    var type = htmlAttributes.GetType();
                    var props = type.GetProperties();

                    foreach (var item in props)
                    {
                        div.MergeAttribute(item.Name, item.GetValue(htmlAttributes, null).ToString());
                    }
                }

                if (closeable)
                {
                    div.InnerHtml += @"<button type=""button"" class=""close"" data-dismiss=""alert"">×</button>";
                    div.AddCssClass("fade in");
                }

                // adiciona mensagem na div
                div.InnerHtml += validationMessage;

                if (!hideProperties)
                {
                    foreach (var key in html.ViewData.ModelState.Keys)
                    {
                        foreach (var err in html.ViewData.ModelState[key].Errors)
                        {
                            properties += "<p>" + html.Encode(err.ErrorMessage) + "</p>";
                        }
                    }

                    if (!string.IsNullOrEmpty(properties))
                    {
                        div.InnerHtml += properties;
                    }
                }

                return MvcHtmlString.Create(div.ToString());
            }

            return null;
        }

        public static MvcHtmlString CustomActionLink(this HtmlHelper html, string linkText, string actionName, object htmlAttributes, object icons = null, bool hideText = false)
        {
            return CustomActionLink(html, linkText, actionName, null, new { }, htmlAttributes, icons, hideText);
        }

        public static MvcHtmlString CustomActionLink(this HtmlHelper html, string linkText, string actionName, object routeValues, object htmlAttributes, object icons = null, bool hideText = false)
        {
            return CustomActionLink(html, linkText, actionName, null, routeValues, htmlAttributes, icons, hideText);
        }

        public static MvcHtmlString CustomActionLink(this HtmlHelper html, string linkText, string actionName, string controllerName, object routeValues, object htmlAttributes, object icons = null, bool hideText = false)
        {
            UrlHelper urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            string iconLeft = string.Empty,
                    iconRight = string.Empty,
                    innerHtml = string.Empty;

            TagBuilder a = new TagBuilder("a");
            TagBuilder i;
            bool hasTitle = false;

            if (string.IsNullOrEmpty(controllerName))
            {
                a.Attributes.Add("href", actionName.StartsWith("#") ? actionName : urlHelper.Action(actionName, routeValues));
            }
            else
            {
                a.Attributes.Add("href", actionName.StartsWith("#") ? actionName : urlHelper.Action(actionName, controllerName, routeValues));
            }

            // adiciona os atributos
            var htmlAttributesDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            foreach (var attribute in htmlAttributesDictionary)
            {
                if (!hasTitle)
                {
                    hasTitle = attribute.Key.ToLower().Equals("title");
                }

                a.MergeAttribute(attribute.Key, Convert.ToString(attribute.Value));
            }

            // adiciona os icones
            if (icons != null)
            {
                var type = icons.GetType();
                var props = type.GetProperties();
                foreach (var item in props)
                {
                    if (item.Name.ToLower().Equals("left"))
                    {
                        iconLeft = item.GetValue(icons, null).ToString();
                    }
                    else if (item.Name.ToLower().Equals("right"))
                    {
                        iconRight = item.GetValue(icons, null).ToString();
                    }
                }
            }

            if (!string.IsNullOrEmpty(iconLeft))
            {
                i = new TagBuilder("i");
                i.AddCssClass(iconLeft);
                innerHtml += i.ToString() + " ";
            }

            if (!hideText)
            {
                innerHtml += linkText;
            }

            if (!hasTitle && hideText)
            {
                a.Attributes.Add("title", linkText);
            }

            if (!string.IsNullOrEmpty(iconRight))
            {
                i = new TagBuilder("i");
                i.AddCssClass(iconRight);
                innerHtml += " " + i.ToString();
            }

            a.InnerHtml = innerHtml;

            return MvcHtmlString.Create(a.ToString());
        }

        public static MvcHtmlString CustomButton(this HtmlHelper html, string buttonText, object htmlAttributes, object icons = null, bool hideText = false)
        {
            return CustomButton(html, buttonText, null, htmlAttributes, icons, hideText);
        }

        public static MvcHtmlString CustomButton(this HtmlHelper html, string buttonText, string buttonType, object htmlAttributes, object icons = null, bool hideText = false)
        {
            UrlHelper urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            string iconLeft = string.Empty,
                    iconRight = string.Empty,
                    innerHtml = string.Empty;

            TagBuilder button = new TagBuilder("button");
            TagBuilder i;
            bool hasTitle = false;

            if (string.IsNullOrEmpty(buttonType))
            {
                button.Attributes.Add("type", "button");
            }
            else
            {
                button.Attributes.Add("type", buttonType);
            }


            // adiciona os atributos
            if (htmlAttributes != null)
            {
                var type = htmlAttributes.GetType();
                var props = type.GetProperties();
                foreach (var item in props)
                {
                    if (!hasTitle)
                    {
                        hasTitle = item.Name.ToLower().Equals("title");
                    }

                    button.MergeAttribute(item.Name, item.GetValue(htmlAttributes, null).ToString());
                }
            }

            // adiciona os icones
            if (icons != null)
            {
                var type = icons.GetType();
                var props = type.GetProperties();
                foreach (var item in props)
                {
                    if (item.Name.ToLower().Equals("left"))
                    {
                        iconLeft = item.GetValue(icons, null).ToString();
                    }
                    else if (item.Name.ToLower().Equals("right"))
                    {
                        iconRight = item.GetValue(icons, null).ToString();
                    }
                }
            }

            if (!string.IsNullOrEmpty(iconLeft))
            {
                i = new TagBuilder("i");
                i.AddCssClass(iconLeft);
                innerHtml += i.ToString() + " ";
            }

            if (!hideText)
            {
                innerHtml += buttonText;
            }

            if (!hasTitle && hideText)
            {
                button.Attributes.Add("title", buttonText);
            }

            if (!string.IsNullOrEmpty(iconRight))
            {
                i = new TagBuilder("i");
                i.AddCssClass(iconRight);
                innerHtml += " " + i.ToString();
            }

            button.InnerHtml = innerHtml;

            return MvcHtmlString.Create(button.ToString());
        }

        public static MvcHtmlString CustomLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {
            return CustomLabelFor(html, expression, string.Empty, htmlAttributes);
        }

        public static MvcHtmlString CustomLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string labelText, object htmlAttributes = null)
        {
            TagBuilder lbl = new TagBuilder("label");
            var metadata = ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData);

            if (string.IsNullOrEmpty(labelText))
            {
                labelText = metadata.DisplayName;
            }

            lbl.Attributes.Add("for", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(ExpressionHelper.GetExpressionText(expression)));
            lbl.SetInnerText(labelText);

            // adiciona os atributos
            if (htmlAttributes != null)
            {
                var type = htmlAttributes.GetType();
                var props = type.GetProperties();
                foreach (var item in props)
                {
                    lbl.MergeAttribute(item.Name, item.GetValue(htmlAttributes, null).ToString());
                }
            }

            return MvcHtmlString.Create(lbl.ToString());
        }
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
        public static IDisposable BeginFormContainer<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
        {
            var attributes = AnonymousToDictionary(htmlAttributes);
            if (!attributes.ContainsKey("class"))
            {
                attributes.Add("class", "form-container");
            }
            else if (attributes["class"].IndexOf("form-container") < 0)
            {
                attributes["class"] += " form-container";
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
                attributes.Add("class", "form-container");
            }
            else if (attributes["class"].IndexOf("form-container") < 0)
            {
                attributes["class"] += " form-container";
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

    public static partial class HtmlExtensions
    {
        public static MvcHtmlString ClientPrefixName(this HtmlHelper htmlHelper)
        {
            return MvcHtmlString.Create(htmlHelper.ViewContext.ViewData.TemplateInfo.HtmlFieldPrefix.Replace('.', '_'));
        }

        public static MvcHtmlString ClientNameFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return MvcHtmlString.Create(htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(expression)));
        }

        public static MvcHtmlString ClientIdFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return MvcHtmlString.Create(htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(ExpressionHelper.GetExpressionText(expression)));
        }
    }

    public static class FatHtml
    {
        const string keyForBlockScript = "__key_For_Js_Block";
        const string keyForBlockStyle = "__key_For_Css_Block";

        private static MvcHtmlString AddBlock(HtmlHelper helper, Func<dynamic, System.Web.WebPages.HelperResult> template, string type)
        {
            var scriptBuilder = helper.ViewContext.HttpContext.Items[type] as StringBuilder ?? new StringBuilder();
            scriptBuilder.Append(template(null).ToHtmlString());
            helper.ViewContext.HttpContext.Items[type] = scriptBuilder;
            return new MvcHtmlString(string.Empty);
        }

        /// <summary>
        /// Adiciona um bloco JavaScript ao fim da lista de bloco de scripts
        /// </summary> 
        public static MvcHtmlString AddScriptBlock(this HtmlHelper helper, Func<dynamic, System.Web.WebPages.HelperResult> template)
        {
            return AddBlock(helper, template, keyForBlockScript);
        }

        /// <summary>
        /// Adiciona um bloco Css ao fim da lista de bloco de estilos
        /// </summary>
        public static MvcHtmlString AddStyleBlock(this HtmlHelper helper, Func<dynamic, System.Web.WebPages.HelperResult> template)
        {
            return AddBlock(helper, template, keyForBlockStyle);
        }

        /// <summary>
        /// Renderiza todos blocos de scripts
        /// </summary>
        public static MvcHtmlString RenderScriptBlocks(this HtmlHelper helper)
        {
            var scriptBuilder = helper.ViewContext.HttpContext.Items[keyForBlockScript] as StringBuilder ?? new StringBuilder();
            string content = scriptBuilder.ToString();

            if (!HttpContext.Current.IsDebuggingEnabled && !string.IsNullOrEmpty(content))
            {
                string clearContent = System.Text.RegularExpressions.Regex.Replace(content, "<script[^>]*>|</script>", string.Empty);
                var minifier = new Microsoft.Ajax.Utilities.Minifier();
                content = string.Format("<script type=\"text/javascript\">{0}</script>", minifier.MinifyJavaScript(clearContent));
            }

            return new MvcHtmlString(content);
        }

        /// <summary>
        /// Renderiza todos blocos de estilos
        /// </summary>
        public static MvcHtmlString RenderStyleBlocks(this HtmlHelper helper)
        {
            var scriptBuilder = helper.ViewContext.HttpContext.Items[keyForBlockStyle] as StringBuilder ?? new StringBuilder();
            string content = scriptBuilder.ToString();

            if (!HttpContext.Current.IsDebuggingEnabled && !string.IsNullOrEmpty(content))
            {
                string clearContent = System.Text.RegularExpressions.Regex.Replace(content, "<style[^>]*>|</style>", string.Empty);
                var minifier = new Microsoft.Ajax.Utilities.Minifier();
                content = string.Format("<style type=\"text/css\">{0}</style>", minifier.MinifyStyleSheet(clearContent));
            }

            return new MvcHtmlString(content);
        }
    }

}