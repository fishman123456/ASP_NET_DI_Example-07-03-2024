using DI_Example.Crypto;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// сконфигурируем зависимость IEncoder
// builder.Services.AddTransient<IEncoder, MD5Encoder>();
//builder.Services.AddTransient<IEncoder, CesarEncoder>((opts) => new CesarEncoder(5));
builder.Services.AddTransient<IEncoder, SHA512Encoder>();

var app = builder.Build();

app.MapGet("", () => "server is running");
app.MapGet("ping", () => "pong");


app.MapPost("encode", async (HttpContext context) =>
{
    try
    {
        using (StreamReader sr = new(context.Request.Body))
        {
            // 1. считаем входные данные из тела запроса
            string data = await sr.ReadToEndAsync();
            // 2. вызвать логику
            IEncoder encoder = context.RequestServices.GetRequiredService<IEncoder>();
            string encodedData = encoder.Encode(data);
            // 3. вернуть результат
            await context.Response.WriteAsync(encodedData);
        }
    } catch (Exception ex)
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;  
        await context.Response.WriteAsync($"encoder error occurred: {ex.Message}");
    }
});

app.MapGet("encode/algorithm", (IEncoder encoder) =>
{
    return encoder.GetAlgorithmName();
});

// показать все сервисы из IoC-контейнера
app.MapGet("services", () =>
{
    StringBuilder sb = new StringBuilder();
    foreach (ServiceDescriptor service in builder.Services)
    {
        sb.Append(service.ServiceType.FullName).Append("\n");
    }
    return sb.ToString();
});

app.Run();
