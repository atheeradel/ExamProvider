using ExamProvider.core.ICommon;
using ExamProvider.core.IRepositary;
using ExamProvider.core.IService;
using ExamProvider.infra.Common;
using ExamProvider.infra.Repositary;
using ExamProvider.infra.Service;

namespace ExamProvider
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IDbContext, DbContext>();
            builder.Services.AddScoped<IExamRepositary,ExamRepositary >();
            builder.Services.AddScoped<IExamService,ExamService >();
            



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
