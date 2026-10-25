using HomeDriveAPI;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;

// read connection properties (only one line, stores the db connection string).
const string ConnPropFile = "ConnProp.hddata";
if (!File.Exists(ConnPropFile)) {
    Console.WriteLine($"Connection Properties File Lost. ({ConnPropFile})\n" +
        $"Please use HomeDrive Configure to set up.");
    return;
}

using var sr = new StreamReader(ConnPropFile);
string connStr = sr.ReadToEnd().Trim();

var builder = WebApplication.CreateBuilder(args);

const long MaxFileSize = 10L * 1024 * 1024 * 1024;

builder.WebHost.ConfigureKestrel(options => {
    options.Limits.MaxRequestBodySize =
        MaxFileSize + 1024 * 1024;
});

builder.Services.Configure<FormOptions>(options => {
    options.MultipartBodyLengthLimit =
        MaxFileSize + 1024 * 1024;
});

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<HomeDriveDbContext>(options =>
    options.UseSqlServer(connStr));

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (builder.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
