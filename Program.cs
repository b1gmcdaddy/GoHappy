using AutoMapper;
using GoHappy.API.Data;
using GoHappy.API.Mappers;
using GoHappy.API.Services;
using Microsoft.EntityFrameworkCore;

namespace GoHappy.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddControllers().AddNewtonsoftJson(options => {
				options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
			});

			builder.Services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
			});

			builder.Services.AddScoped<IListingRepository, ListingRepository>();
			builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

	

			// Add AutoMapper and specify the assembly where the profiles are located
			builder.Services.AddAutoMapper(typeof(MappingProfile));

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
