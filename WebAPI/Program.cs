
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			//Autofac, Ninject,CastleWindsor,StructureMap,LightInect,DryInject -->IoC Container Altyap�s� sunarlar.
			//AOP -- Autofac Aop imkan� sunuyor.
			//Postsharp 

			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();



			//builder.Services.AddSingleton<IProductService,ProductManager>();
			//builder.Services.AddSingleton<IProductDal,EfProductDal>();


			//Farkl� bir IoC ortam� kullanmak istiyorsak <Autofac> bu syntax � kullan�r�z.
			builder.Host.UseServiceProviderFactory(services => new AutofacServiceProviderFactory())
				.ConfigureContainer<ContainerBuilder>
				(builder => { builder.RegisterModule(new AutofacBusinessModule()); });



			var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

			builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateLifetime = true,
						ValidIssuer = tokenOptions.Issuer,
						ValidAudience = tokenOptions.Audience,
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
					};
				});
			ServiceTool.Create(builder.Services);

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthentication(); //Keydir
			app.UseAuthorization(); //Buras� keyden sonra ne yap�lacaksa ona izin verendir. �nce Authentication olmas� gerekir.


			app.MapControllers();

			app.Run();
		}
	}
}