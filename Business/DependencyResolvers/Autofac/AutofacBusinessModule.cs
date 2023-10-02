using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Helpers.FileHelper;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
	public class AutofacBusinessModule:Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<CarManager>().As<ICarService>().SingleInstance(); //Biri senden IProductService isterse ona Product Manager instance ver demek.
			builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

			builder.RegisterType<CarImageManager>().As<ICarImageService>().SingleInstance();
			builder.RegisterType<EfCarImageDal>().As<ICarImageDal>().SingleInstance();

			builder.RegisterType<FileHelperManager>().As<IFileHelper>().SingleInstance();
			
			builder.RegisterType<AuthManager>().As<IAuthService>();
			builder.RegisterType<JwtHelper>().As<ITokenHelper>();

			builder.RegisterType<UserManager>().As<IUserService>();
			builder.RegisterType<EfUserDal>().As<IUserDal>();

			builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();


			var assembly = System.Reflection.Assembly.GetExecutingAssembly();

			builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
				.EnableInterfaceInterceptors(new ProxyGenerationOptions()
				{
					Selector = new AspectInterceptorSelector()
				}).SingleInstance();



		}
	}
}
