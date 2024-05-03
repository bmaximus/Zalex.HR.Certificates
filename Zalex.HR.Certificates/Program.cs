

using Microsoft.EntityFrameworkCore;
using Zalex.HR.Certificates.Api.Constants;
using Zalex.HR.Certificates.Dal;
using Zalex.HR.Certificates.Dal.Services.Repositories;

QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
Constants.ApiKey = configuration["ApiKey"];

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("https://google.com")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<CertificatesContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultSqlDb")));
builder.Services.AddTransient<ICertificateRequestRepository, CertificateRequestRepository>();
builder.Services.AddTransient<ICertificatePdfRepository, CertificatePdfRepository>();


var app = builder.Build();

//Swagger has to be Enabled for the scope of this assessment
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
