﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Http.Routing;

namespace SDSK.API
{
    internal class JiraIdConstraint : IHttpRouteConstraint
    {
        private readonly string _regEx;
        public JiraIdConstraint()
        {
            _regEx = "jira-[1-9].*";
        }
        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName,
            IDictionary<string, object> values, HttpRouteDirection routeDirection)
        {
            if (values[parameterName] != RouteParameter.Optional)
            {
                object value;
                values.TryGetValue(parameterName, out value);
                string pattern = "^(" + _regEx + ")$";
                string input = Convert.ToString(value, CultureInfo.InvariantCulture);

                return Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
            }
            return true;
        }
    }
}