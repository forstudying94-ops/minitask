using System.Numerics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapGet("/app/markus_kek_mail_ru", (string? x, string? y) =>
{
    if (!long.TryParse(x, out long numx) || !long.TryParse(y, out long numy) || numx <= 0 || numy <= 0)
    {
        return Results.Text("NaN");
    }

    BigInteger gcd = BigInteger.GreatestCommonDivisor(numx,numy);
    var lcm = (numx / gcd) * numy;
    return Results.Text(lcm.ToString());
});
app.Run();
