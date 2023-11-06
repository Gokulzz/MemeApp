using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FluentValidation;
using memeApp.BLL.Implementations;
using memeApp.BLL.Services;
using memeApp.BLL.Validation;
using memeApp.DAL.Data;
using memeApp.DAL.Implementations;
using memeApp.DAL.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ConfigureManager
{
    public static class ConfigureDependencies
    {
        public static void ConfigureDepedency(this IServiceCollection services)
        {
            services.AddScoped<DataContext>();
            services.AddHttpContextAccessor();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IUploadRepository, UploadRepository>();
            services.AddScoped<IDownloadRepository, DownloadRepository>();
            services.AddScoped<IUserDownloadRepository, UserDownloadRepository>();
            services.AddScoped<IUnitofWork, UnitofWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IMemeTemplateDownload, DownloadService>();
            services.AddScoped<IMemeTemplateUpload, UploadService>();  
            services.AddValidatorsFromAssemblyContaining<UserValidator>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        }
    }
}
