﻿using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace OmegaSample.Infrastructure
{
    public class EtagHandlerFeature : IEtagHandlerFeature
    {
        private IHeaderDictionary _headers;

        public EtagHandlerFeature(IHeaderDictionary headers)
        {
            _headers = headers;
        }

        public bool NoneMatch(IEtaggable entity)
        {
            if (!_headers.TryGetValue("If-None-Match", out var etags)) return true;

            var entityEtag = entity.GetEtag();
            if (string.IsNullOrEmpty(entityEtag)) return true;

            if (!entityEtag.Contains('"'))
            {
                entityEtag = $"\"{entityEtag}\"";
            }

            return !etags.Contains(entityEtag);
        }
    }
}
