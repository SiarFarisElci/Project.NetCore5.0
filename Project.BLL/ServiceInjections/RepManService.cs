using Microsoft.Extensions.DependencyInjection;
using Project.BLL.ManagerServices.Abstracts;
using Project.BLL.ManagerServices.Concrates;
using Project.DAL.Repositories.Abstracts;
using Project.DAL.Repositories.Concrates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServiceInjections
{

    
    public static class RepManService
    {

        public static IServiceCollection AddRepManService(this IServiceCollection services)
        {

            //Repositories

            //Scoped , Transient , singleton
            services.AddScoped(typeof(IRepository<>) , typeof(BaseRepository<>) );
            services.AddScoped<IAdressRepository , AdressRepository>();
            services.AddScoped<IContactRepository , ContactRepository>();
            services.AddScoped<IImageRepository , ImageRepository>();
            services.AddScoped<INewRepository , NewRepository>();
            services.AddScoped<IServiceRepository , ServiceRepository>();
            services.AddScoped<ITeamRepository , TeamRepository>();
            services.AddScoped<IAboutRepository , AboutRepository>();
            services.AddScoped<IAppUserRepository , AppUserRepository>();
         
        



            //Managers

            services.AddScoped(typeof(IManager<>), typeof(BaseManager<>));
            services.AddScoped<IAdressManager , AdressManager>();
            services.AddScoped<IContactManager , ContactManager>();
            services.AddScoped<INewManager , NewManager>();
            services.AddScoped<IImageManager , ImageManager>();
            services.AddScoped<IServiceManager , ServiceManager>();
            services.AddScoped<ITeamManager , TeamManager>();
            services.AddScoped<IAboutManager , AboutManager>();
            services.AddScoped<IAppUserManager , AppUserManager>();
          


            return services;
        }


    }
}
