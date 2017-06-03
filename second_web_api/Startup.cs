using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RawRabbit.vNext;
using RawRabbit.vNext.Disposable;
using second_devwarsztaty.Framework;
using second_devwarsztaty.Handlers;
using third_devwarsztaty.Commands;

namespace second_devwarsztaty
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            ConfigureRabbitMq(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            ConfigureHandlers(app);
            app.UseMvc();
        }

        private void ConfigureRabbitMq(IServiceCollection services)
        {
            var options = new RabbitMqOptions();
            IConfigurationSection section = Configuration.GetSection("rabbitmq");
            section.Bind(options);
            services.Configure<RabbitMqOptions>(section);

            IBusClient client = BusClientFactory.CreateDefault(options);
            services.AddSingleton(client);

            services.AddScoped<ICommandHandler<CreateRecord>, CreateRecordHandler>();
        }

        private void ConfigureHandlers(IApplicationBuilder app)
        {
            var client = app.ApplicationServices.GetService<IBusClient>();
            client.SubscribeAsync<CreateRecord>((msg, ctx) =>
                app.ApplicationServices.GetService
                    <ICommandHandler<CreateRecord>>().HandleAsync(msg));
        }

    }
}