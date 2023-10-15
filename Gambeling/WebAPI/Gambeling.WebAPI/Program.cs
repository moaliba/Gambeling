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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<GambelingDbContext>();
builder.Services.AddScoped<IGambelingDbContext>(x => x.GetService<GambelingDbContext>()!);
builder.Services.AddTransient<IQueryHandler<GetTokenByCredentialQuery, string>, GetTokenByCredentialQueryHandler>();
builder.Services.AddTransient<ICommandHandler<CreateBetRequestCommand, Participant>, CreateBetRequestCommandHandler>();
builder.Services.AddTransient<IParticipantsRepository, ParticipantsRepository>();
builder.Services.AddTransient<IUsersRepository, UsersRepository>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddControllers();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
