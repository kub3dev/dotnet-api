using Keycloak.AuthServices.Authentication;
using Microsoft.OpenApi.Models;
using Voucher.API.Data.Repositories;
using Voucher.API.Data.Services;
using Voucher.API.Domain.Repositories;
using Voucher.API.Domain.Services;
using Voucher.API.Domain.UseCases;
using Voucher.API.Presentation.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddKeycloakWebApiAuthentication(builder.Configuration);
builder.Services.AddAuthorization();

builder.Services.AddSingleton<IVoucherRepository, VoucherRepository>();
builder.Services.AddSingleton<IVoucherService, VoucherService>();
builder.Services.AddSingleton<CreateVoucherUseCase>();
builder.Services.AddSingleton<GetVoucherUseCase>();
builder.Services.AddSingleton<UpdateVoucherUseCase>();
builder.Services.AddSingleton<DeleteVoucherUseCase>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Voucher | API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",

    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
             new OpenApiSecurityScheme {
                 Reference = new OpenApiReference {
                     Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                 }
             },
            new string[] {}
        }
    });
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/health", () => "health!").AllowAnonymous();

app.MapVoucher();

app.Run();