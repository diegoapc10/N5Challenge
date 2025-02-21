using Aplication.Handlers;
using Domain.Mapper;
using Infrastructure.Implementation.Commands;
using Infrastructure.Interfaces.Commands;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Implementation;
using Repositories.Interfaces;
using Repositories.Services;
using UnitOfWork.Interfaces;
using UnitOfWork.Implementation;
using Infrastructure.Interfaces.Queries;
using Infrastructure.Implementation.Queries;

namespace N5ChallengeAPI.Extensions
{
    public static class DependencyInjectionService
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services, string urlElasticsearch, string indexName)
        {
            //Agregamos los repositorios
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<UnitOfWork.Interfaces.IUnitOfWork, UnitOfWork.Implementation.UnitOfWork>();
            services.AddScoped<IRequestPermissionCommand, RequestPermissionCommand>();
            services.AddScoped<IModifyPermissionCommand, ModifyPermissionCommand>();
            services.AddScoped<IGetPermissionsQuery, GetPermissionsQuery>();

            services.AddAutoMapper(typeof(N5ChallengeMapper));

            //services.AddTransient<RequestPermissionHandler>();
            services.AddTransient(serviceProvider => new RequestPermissionHandler(serviceProvider.GetRequiredService<IRequestPermissionCommand>(), urlElasticsearch, indexName));
            //services.AddTransient<ModifyPermissionHandler>();
            services.AddTransient(serviceProvider => new ModifyPermissionHandler(serviceProvider.GetRequiredService<IModifyPermissionCommand>(), urlElasticsearch, indexName));
            //services.AddTransient<GetPermissionsHandler>();
            services.AddTransient(serviceProvider => new GetPermissionsHandler(serviceProvider.GetRequiredService<IGetPermissionsQuery>(), urlElasticsearch, indexName));
        }
    }
}
