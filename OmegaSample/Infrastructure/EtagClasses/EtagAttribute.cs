using Microsoft.AspNetCore.Mvc.Filters;
using OmegaSample.Filters;
using System;

namespace OmegaSample.Infrastructure
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class EtagAttribute : Attribute, IFilterFactory
    {
        public bool IsReusable => true;

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
            => new EtagHeaderFilter();
    }
}
