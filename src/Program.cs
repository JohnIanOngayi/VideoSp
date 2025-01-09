using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger(opt =>
{
    opt.RouteTemplate = "openapi/{documentName}.json";
});
app.MapScalarApiReference(opt =>
{
    opt.Title = "Scalar Example";
    opt.Theme = ScalarTheme.DeepSpace;
    opt.DefaultHttpClient = new(ScalarTarget.Http, ScalarClient.Http11);
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
