using Microsoft.EntityFrameworkCore;
using PMB_Backend.Data;
using PMB_Backend.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<DatabaseContext>(options => 
    options.UseSqlite("Data Source=pmb.db"));


builder.Services.AddScoped<AuthService>();


var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), 
    builder.Configuration["FileStorage:UploadPath"]);
if (!Directory.Exists(uploadsFolder))
{
    Directory.CreateDirectory(uploadsFolder);
}

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    db.Database.Migrate(); 
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();

app.Run();