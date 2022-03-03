using System;
using Travel_Library.Core.QueryFilters;
using Travel_Library.Infrastructure.Interfaces;

namespace Travel_Library.Infrastructure.Services
{
    public class UriService : IUriService
    {

        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetPostPaginationUri(PostQueryFilter filter, string actionUrl)
        {
            string baseUrl = $"{_baseUri}{actionUrl}";
            return new Uri(baseUrl);
        }
    }
}
