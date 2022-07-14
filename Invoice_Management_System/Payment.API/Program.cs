var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region CORS

builder.Services.AddCors();

string corsUrl = builder.Configuration["Cors:site"];
string[] corsUrls;
if (corsUrl.Contains(";"))
    corsUrls = corsUrl.Split(';').ToArray();
else
{
    corsUrls = new string[1];
    corsUrls[0] = corsUrl;
}
builder.Services.AddCors(options =>
{
    options.AddPolicy("WebApp",
        builder =>
        {
            builder.WithOrigins(corsUrls)
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseCors();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
