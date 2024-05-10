using SigmaTask.Domain;
using Microsoft.EntityFrameworkCore;
using SigmaTask.Services.Abstraction;
using SigmaTask.Services.Implmentation;
using SigmaTask.Repository.Abstraction;
using SigmaTask.Repository.Implmentation;
using Microsoft.AspNetCore.Mvc;
using SigmaTask.Services.DTO;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<SigmaDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("sigmaDBConnection")));
builder.Services.AddScoped<IJobCandidateService, JobCandidateService>();
builder.Services.AddScoped<IJobCandidateRepository, JobCandidateRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = actionContext =>
    {
        var errors = actionContext.ModelState
        .Where(e => e.Value.Errors.Count > 0)
        .SelectMany(x => x.Value.Errors)
        .Select(x => x.ErrorMessage).ToArray();

        var errorResponse = new EmptyResponse
        {
            Message = string.Join(", ", errors)
        };

        return new OkObjectResult(errorResponse);
    };
});

builder.Services.AddControllers();
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
app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
