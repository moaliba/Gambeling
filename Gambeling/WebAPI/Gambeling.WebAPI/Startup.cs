using Gambeling.DataAccessContext.Context;
using Gambeling.DomainModels.Participants;
using Gambeling.Persistence.Implementations.Context;
using Gambeling.Persistence.Implementations.Participants;
using Gambeling.Persistence.Implementations.Useers;
using Gambeling.Persistence.Services.Participants;
using Gambeling.Persistence.Services.Users;
using Gambeling.Services.Implementations.BetRequests.Commands;
using Gambeling.Services.Implementations.Token;
using Gambeling.Services.Implementations.Users.Queries;
using Gambeling.Services.Participants.Commands;
using Gambeling.Services.Users.Queries;
using Infrastracture.Commands;
using Infrastracture.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Gambeling.WebAPI;

public class Startup
{
    public IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration)
    {
        this.Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<GambelingDbContext>(options =>
           options.UseInMemoryDatabase("GambelingDB"));
        services.AddScoped<IGambelingDbContext>(x => x.GetService<GambelingDbContext>()!);
        services.AddTransient<IQueryHandler<GetTokenByCredentialQuery, string>, GetTokenByCredentialQueryHandler>();
        services.AddTransient<ICommandHandler<CreateBetRequestCommand, Participant>, CreateBetRequestCommandHandler>();
        services.AddTransient<IParticipantsRepository, ParticipantsRepository>();
        services.AddTransient<IUsersRepository, UsersRepository>();
        services.AddTransient<ITokenService, TokenService>();
        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gambeling.WebAPI", Version = "v1" });
            c.MapType<DateOnly>(() => new OpenApiSchema
            {
                Type = "string",
                Format = "date",
                Example = new OpenApiString("2022-01-01")
            });
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gambeling.WebAPI"));
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

    //protected virtual void ConfigureDatabaseServices(IServiceCollection services)
    //{
    //    services.AddDbContext<CrudTestDbContext>(options =>
    //        options.UseSqlite(
    //            Configuration.GetConnectionString("CrudTestDBConnection"),
    //            builder => builder.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name)
    //        ));
    //}
}

