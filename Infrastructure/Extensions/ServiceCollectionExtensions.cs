using MosCore.Application.Interfaces.CacheRepositories;
using MosCore.Application.Interfaces.Contexts;
using MosCore.Application.Interfaces.Repositories;
using MosCore.Infrastructure.CacheRepositories;
using MosCore.Infrastructure.DbContexts;
using MosCore.Infrastructure.Repositories;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MosCore.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static void AddPersistenceContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            #region Repositories
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IDeviceRepository, DeviceRepository>();
            services.AddTransient<IDeviceCacheRepository, DeviceCacheRepository>();
            services.AddTransient<IProductCacheRepository, ProductCacheRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IBrandCacheRepository, BrandCacheRepository>();
            services.AddTransient<ILogRepository, LogRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ISmsRepository, SmsRepository>();
            services.AddTransient<ISmsCacheRepository, SmsCacheRepository>();
            #endregion
        }
    }
}
