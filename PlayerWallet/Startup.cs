using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlayerWallet.BL;
using PlayerWallet.BL.Interfaces;
using PlayerWallet.BL.Repository;
using PlayerWallet.BL.Services;
using PlayerWallet.DAL.DatabasesContext;
using Microsoft.EntityFrameworkCore;
using PlayerWallet.BL.CommonHelper;
using System;
using NLog;
using System.IO;

namespace PlayerWallet
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
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IPlayerWalletRepository, PlayerWalletRepository>();
            services.AddScoped<IUnityOfWork, UnityOfWork>();
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddDbContext<PlayerDbContext>(option => option.UseInMemoryDatabase("PlayersWalletDB"));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSingleton<ILoggerManager, LoggerService>();

            services.AddControllers();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Player's Wallet API");
                c.RoutePrefix = string.Empty;
            });
            
        }
    }
}
