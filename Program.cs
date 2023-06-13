using Microsoft.EntityFrameworkCore;
using praktika.Database;
using praktika.Handlers;
using Twilio.Clients;

namespace praktika
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHttpClient<ITwilioRestClient, TwiliClient>();

            var connection = builder.Configuration.GetConnectionString("PraktikaConnection");
            builder.Services.AddDbContext<PraktikaContext>(options => options.UseSqlServer(connection));

            var app = builder.Build();

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