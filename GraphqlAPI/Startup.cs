using GraphQL;
using GraphQL.Execution;
using GraphQL.Instrumentation;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using GraphQL.Validation;
using GraphQL.Validation.Complexity;
using GraphqlAPI.Operations;
using GraphqlAPI.Schemas;
using GraphqlBusiness.Repository;
using GraphqlBusiness.Repository.ePortal;
using GraphqlDomain.Contract;
using GraphqlDomain.Contract.ePortal;
using Microsoft.Extensions.Options;
using System.Reflection.Metadata.Ecma335;

namespace GraphqlAPI
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
            services.AddGraphQL(builder => builder
           .AddSystemTextJson()
           .AddErrorInfoProvider((opts, serviceProvider) =>
           {
               var settings = serviceProvider.GetRequiredService<IOptions<GraphQLSettings>>();
               opts.ExposeExceptionDetails = settings.Value.ExposeExceptions;
           }).AddSchema<OpenNetSchema>()
           .AddGraphTypes(typeof(QueryOpenNet).Assembly)
            .UseMiddleware<CountFieldMiddleware>(false) // do not auto-install middleware
            .UseMiddleware<InstrumentFieldsMiddleware>(false) // do not auto-install middleware
            .ConfigureSchema((schema, serviceProvider) =>
            {
                // install middleware only when the custom EnableMetrics option is set
                var settings = serviceProvider.GetRequiredService<IOptions<GraphQLSettings>>();
                if (settings.Value.EnableMetrics)
                {
                    var middlewares = serviceProvider.GetRequiredService<IEnumerable<IFieldMiddleware>>();
                    foreach (var middleware in middlewares)
                        schema.FieldMiddleware.Use(middleware);
                }
            }));


            services.AddSingleton<ISchema, OpenNetSchema>(services => new OpenNetSchema(new SelfActivatingServiceProvider(services))); 
            services.AddHttpContextAccessor();
            services.AddSingleton<IUserRepository,UserRepository>();
            services.AddSingleton<IIRDRepository, IRDRepository>();
            services.AddSingleton<INotificationsRepository, NotificationsRepository>();
            services.AddSingleton<QueryOpenNet>();
            services.AddSingleton<MutationOpenNet>();
            services.AddSingleton<GraphQLMiddleware>();
            services.Configure<GraphQLSettings>(Configuration);
            services.Configure<GraphQLSettings>(settings => settings.BuildUserContext = ctx => new GraphQLUserContext { User = ctx.User });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseWebSockets();
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            app.UseMiddleware<GraphQLMiddleware>();

            app.UseGraphQLGraphiQL();
            app.UseGraphQLPlayground();

            app.UseHttpsRedirection();
            
        }
    }
}
