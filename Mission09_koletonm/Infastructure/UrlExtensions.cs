using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_koletonm.Infastructure
{
    // We use the Url Extensions to add the ability to return to the url and exact category you were previously at
    public static class UrlExtensions
    {
        public static string PathAndQuery(this HttpRequest request) =>
            request.QueryString.HasValue? $"{request.Path}{request.QueryString}" : request.Path.ToString();
    }
}
