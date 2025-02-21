
using N5ChallengeAPI.Extensions;

namespace N5ChallengeAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;
            var connectionString = configuration.GetConnectionString("BaseDeDatos");
            var pathSeriLog = configuration.GetValue<string>("SeriLog:Path");
            var urlElasticsearch = configuration.GetValue<string>("Elasticsearch:Url");
            var indexName = configuration.GetValue<string>("Elasticsearch:IndexName");
            // Add services to the container.
            builder.Services.ConfigureDataBaseConnection(connectionString);
            builder.Services.ConfigureDependencyInjection(urlElasticsearch, indexName);
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.ConfigureSeriLog(pathSeriLog);

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
