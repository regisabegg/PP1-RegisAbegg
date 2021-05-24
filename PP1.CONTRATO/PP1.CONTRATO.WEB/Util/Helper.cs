using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace PP1.CONTRATO.WEB.Util
{

    public static class Helper
    {
        public const string Table = "table-hover table table-condensed table-bordered table-striped";
        public const string Label = "control-label col-lg-2 col-md-2 col-sm-3 col-xs-12";
        public const string LabelSM = "control-label col-lg-3 col-md-3 col-sm-3 col-xs-12";
        public const string LabelXS = "control-label col-lg-2 col-md-2 col-sm-2 col-xs-12";
        public const string LabelXXS = "control-label col-lg-1 col-md-1 col-sm-1 col-xs-12";
        public const string LabelHiden = "control-label hidden-lg hidden-md hidden-sm visible-xs col-xs-12";
        public const string LabelHidenXS = "control-label col-lg-2 col-md-2 col-sm-3 hidden-xs control-label-hiden-xs";

        public const string InputLG = "col-lg-9 col-md-9 col-sm-9 col-xs-12";
        public const string InputMDLG = "col-lg-7 col-md-7 col-sm-7 col-xs-12";
        public const string InputMD = "col-lg-6 col-md-6 col-sm-6 col-xs-12";
        public const string Input5 = "col-lg-5 col-md-5 col-sm-5 col-xs-12";
        public const string InputSMMD = "col-lg-4 col-md-4 col-sm-4 col-xs-12";
        public const string InputSM = "col-lg-3 col-md-3 col-sm-3 col-xs-12";
        public const string InputXS = "col-lg-2 col-md-2 col-sm-2 col-xs-12";
        private static string ToQueryString(NameValueCollection nvc)
        {
            return "?" + string.Join("&", Array.ConvertAll(nvc.AllKeys, key => string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(nvc[key]))));
        }



        public enum eSimNao
        {
            Sim,
            Não
        }
        public enum eNaoSim
        {
            Sim,
            Não
        }
        public enum eSN
        {
            S,
            N
        }

        public static SelectListItem[] SimNaoUpperCase(eSimNao? defaultValue = null)
        {
            return new[] {
                new SelectListItem { Text = "SIM", Value = "Sim",  Selected=(defaultValue == eSimNao.Sim) },
                new SelectListItem { Text = "NÃO", Value = "Não" , Selected=(defaultValue == eSimNao.Não)}
            };
        }

        public static SelectListItem[] SimNao(eSimNao? defaultValue = null)
        {
            return new[] {
                new SelectListItem { Text = "Sim", Value = "Sim",  Selected=(defaultValue == eSimNao.Sim) },
                new SelectListItem { Text = "Não", Value = "Não" , Selected=(defaultValue == eSimNao.Não)}
            };
        }

        public static SelectListItem[] NaoSim(eNaoSim? defaultValue = null)
        {
            return new[] {
                new SelectListItem { Text = "Não", Value = "Não" , Selected=(defaultValue == eNaoSim.Não) },
                new SelectListItem { Text = "Sim", Value = "Sim",  Selected=(defaultValue == eNaoSim.Sim) }
            };
        }

        public static SelectListItem[] SN(eSN? defaultValue = null)
        {
            return new[] {
                new SelectListItem { Text = "Sim", Value = "S",  Selected=(defaultValue == eSN.S) },
                new SelectListItem { Text = "Não", Value = "N" , Selected=(defaultValue == eSN.N)}
            };
        }

        public static readonly SelectListItem[] AtivoInativo = new[] {
            new SelectListItem { Text = "Ativo", Value = "A" },
            new SelectListItem { Text = "Inativo", Value = "I" },
        };

        public static readonly SelectListItem[] TipoTelefone = new[] {
            new SelectListItem { Text = "" , Value = ""},
            new SelectListItem { Text = "Celular", Value = "Celular" },
            new SelectListItem { Text = "Fixo", Value = "Fixo" },
            new SelectListItem { Text = "Fax", Value = "Fax" }
        };

        public static SelectListItem[] UF
        {
            get
            {
                return new[]
                {
                    new SelectListItem { Text = "Não informado", Value = "NI" },
                    new SelectListItem { Text = "Acre", Value = "AC" },
                    new SelectListItem { Text = "Alagoas", Value = "AL" },
                    new SelectListItem { Text = "Amapá", Value = "AP" },
                    new SelectListItem { Text = "Amazonas", Value = "AM" },
                    new SelectListItem { Text = "Bahia", Value = "BA" },
                    new SelectListItem { Text = "Ceará", Value = "CE" },
                    new SelectListItem { Text = "Distrito Federal", Value = "DF" },
                    new SelectListItem { Text = "Espirito Santo", Value = "ES" },
                    new SelectListItem { Text = "Goiás", Value = "GO" },
                    new SelectListItem { Text = "Maranhão", Value = "MA" },
                    new SelectListItem { Text = "Mato Grosso", Value = "MT" },
                    new SelectListItem { Text = "Mato Grosso do Sul", Value = "MS" },
                    new SelectListItem { Text = "Minas Gerais", Value = "MG" },
                    new SelectListItem { Text = "Pará", Value = "PA" },
                    new SelectListItem { Text = "Paraíba", Value = "RB" },
                    new SelectListItem { Text = "Paraná", Value = "PR" },
                    new SelectListItem { Text = "Pernambuco", Value = "PE" },
                    new SelectListItem { Text = "Piauí", Value = "PI" },
                    new SelectListItem { Text = "Rio de Janeiro", Value = "RJ" },
                    new SelectListItem { Text = "Rio Grande do Norte", Value = "RN" },
                    new SelectListItem { Text = "Rio Grande do Sul", Value = "RS" },
                    new SelectListItem { Text = "Rondônia", Value = "RO" },
                    new SelectListItem { Text = "Roraima", Value = "RR" },
                    new SelectListItem { Text = "Santa Catarina", Value = "SC" },
                    new SelectListItem { Text = "São Paulo", Value = "SP" },
                    new SelectListItem { Text = "Sergipe", Value = "SE" },
                    new SelectListItem { Text = "Tocantins", Value = "TO" }
                };
            }
        }

        //public static Form Editor(this HtmlHelper helper)
        //{
        //    Form _form = new Form();

        //    return _form;
        //}

        public static MvcHtmlString BindParam(this HtmlHelper helper, NameValueCollection querystring, string notBind)
        {
            string hiddens = string.Empty;
            List<string> k = new List<string>(notBind.Split(',').Select(s => s.Trim()));
            k = k.Distinct().ToList();
            foreach (string key in querystring)
            {
                if (!k.Contains(key.Trim()))
                {
                    hiddens += "<input type='hidden' name='" + key + "' value='" + querystring[key] + "' />";
                }
            }
            return MvcHtmlString.Create(hiddens);
        }

        public static string getInputName(string name, string prefixo)
        {
            return (string.IsNullOrEmpty(prefixo) ? "" : prefixo + ".") + name;
        }

        public static string getInputId(string id, string prefixo)
        {
            return ((string.IsNullOrEmpty(prefixo) ? "" : prefixo + "_") + id).Replace('.', '_');
        }

        public static string Concat(string str1, string str2)
        {
            return ((string.IsNullOrEmpty(str1) ? "" : str1 + "_") + str2).Replace('.', '_');
        }

        public static object KeepFilter(this Controller controller, string filter = null)
        {
            if (string.IsNullOrEmpty(filter))
            {
                object result = controller.Session[controller.ToString() + "filter"];
                if (result != null)
                {
                    return controller.Session[controller.ToString() + "filter"].ToString();
                }
            }
            else
            {
                controller.Session[controller.ToString() + "filter"] = filter;
                return null;
            }

            return null;
        }

        public static DateTime GetDtHr(DateTime? date, string hour, bool setHora = true)
        {
            var dt = date ?? DateTime.Now.Date;
            if (!string.IsNullOrEmpty(hour))
            {
                int hh = 0;
                if (int.TryParse(hour.Substring(0, 2), out hh))
                {
                    dt = dt.AddHours(hh);
                }
                else
                {
                    dt = dt.AddHours(DateTime.Now.Hour);
                }
                int mm = 0;
                if (int.TryParse(hour.Substring(3, 2), out mm))
                {
                    dt = dt.AddMinutes(mm);
                }
                else
                {
                    dt = dt.AddMinutes(DateTime.Now.Minute);
                }
            }
            else if (setHora)
            {
                dt = dt.AddHours(DateTime.Now.Hour);
                dt = dt.AddMinutes(DateTime.Now.Minute);
            }
            return dt;
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

    public static class Extensions
    {

        public static string logParse(this int? value)
        {
            if (value == null)
                return string.Empty;
            return value.Value.ToString();
        }

        public static string logParse(this DateTime? value, string format)
        {
            if (value == null)
                return string.Empty;
            return value.Value.ToString(format);
        }
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
                    div.InnerHtml += @"<button type=""button"" class=""close"" data-dismiss=""alert"" aria-label=""Close"">×</button>";
                    div.AddCssClass("print");
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

   
}