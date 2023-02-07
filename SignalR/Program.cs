using SignalR.Business;
using SignalR.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR(); 



builder.Services.AddCors(
    options => options.AddDefaultPolicy(
        policy => policy.AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .SetIsOriginAllowed(origin =>true)));

IServiceCollection services = builder.Services;
services.AddTransient<MyBusiness>();
services.AddControllers();

var app = builder.Build();
app.UseCors();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<MyHub>("/myhub");
    endpoints.MapHub<MessageHub>("/messageHub");
    endpoints.MapControllers();
});


app.Run();
