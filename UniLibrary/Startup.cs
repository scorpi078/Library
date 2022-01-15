using Library.BL.Interfaces;
using Library.BL.Services;
using Library.DL.Interfaces;
using Library.DL.Repositories;

using Library.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using FluentValidation.AspNetCore;

namespace UniLibrary
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Log.Logger);

            services.AddAutoMapper(typeof(Startup));

            services.AddSingleton<IBookRepository, BookInMemoryRepository>();
            services.AddSingleton<IBorrowingRepository, BorrowingInMemoryRepository>();
            services.AddSingleton<ILibrarianRepository, LibrarianInMemoryRepository> ();
            services.AddSingleton<IReaderRepository, ReaderInMemoryRepository>();

            services.AddSingleton<IBookService, BookService>();
            services.AddSingleton<IBorrowingService, BorrowingService>();
            services.AddSingleton<ILibrarianService, LibrarianService>();
            services.AddSingleton<IReaderService, ReaderService>();


            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Library", Version = "v1" });
            });

            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Library v1"));
            }

           
            app.ConfigureExceptionHandler(logger);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
