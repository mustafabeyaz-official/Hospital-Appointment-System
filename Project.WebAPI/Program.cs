using Project.BLL.DependencyResolvers;

namespace Project.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddIdentityService();
            builder.Services.AddDbContextService();
            builder.Services.AddRepositoryManagerServices();

            //Session
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(x =>
            {
                x.IdleTimeout = TimeSpan.FromMinutes(1);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseSession();
            app.MapControllers();

            app.Run();
        }
    }
}
