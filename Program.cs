var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers(); 
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "Проба версия"
    });

    // Раскомментируйте, когда создадите XML файл
    // string PathFile = Path.Combine(System.AppContext.BaseDirectory, "WebApplication2.xml");
    // option.IncludeXmlComments(PathFile);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Добавляем Swagger (обычно только для разработки)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Проба версия")
    );
}

app.MapRazorPages();
app.MapControllers(); // Маппинг контроллеров

app.Run();