
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace WebAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			
			builder.Services.AddSingleton<ICarService, CarManager>();
			builder.Services.AddSingleton<ICarDal, EfCarDal>();
			
			builder.Services.AddSingleton<IColorService, ColorManager>();
			builder.Services.AddSingleton<IColorDal, EfColorDal>();

			builder.Services.AddSingleton<IBrandService, BrandManager>();
			builder.Services.AddSingleton<IBrandDal, EfBrandDal>();

			builder.Services.AddSingleton<ICustomerService, CustomerManager>();
			builder.Services.AddSingleton<ICustomerDal, EfCustomerDal>();

			builder.Services.AddSingleton<IRentalService, RentalManager>();
			builder.Services.AddSingleton<IRentalDal, EfRentalDal>();

			builder.Services.AddSingleton<IUserService,UserManager>();
			builder.Services.AddSingleton<IRentalDal, EfRentalDal>();



			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}