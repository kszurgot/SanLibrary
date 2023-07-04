using Microsoft.Extensions.DependencyInjection;
using SanLibrary.Core.Books.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanLibrary.Core
{
    public static class Extensions
    {
        public static IServiceCollection AddCoreLayer(this IServiceCollection services)
        => services
            .AddScoped<IBorrowingBookDomainService, BorrowingBookDomainService>();
    }
}
