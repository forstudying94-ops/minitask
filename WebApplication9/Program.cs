var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();
app.MapGet("/app/forstudying94_gmail_com", (string? x, string? y) =>
{
    if (!long.TryParse(x, out long numx) || !long.TryParse(y, out long numy) || numx < 0 || numy < 0)
    {
        return Results.Text("NaN");
    }

    long lcm = CalculateLCM(numx, numy);
    return Results.Text(lcm.ToString());
});
static long CalculateGCD(long a, long b) => b == 0 ? a : CalculateGCD(b, a % b);
static long CalculateLCM(long a, long b) => (a * b) / CalculateGCD(a, b);
app.Run();
