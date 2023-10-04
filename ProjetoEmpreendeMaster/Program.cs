using Microsoft.EntityFrameworkCore;
using ProjetoEmpreendeMaster.Data;
using ProjetoEmpreendeMaster.Interfaces;
using ProjetoEmpreendeMaster.Repositories;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Configuration.AddJsonFile("appsettings.json", optional: false);
builder.Services.AddControllers();
builder.Services.AddMvc();
builder.Services.AddCors();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ITipoUsuarioRepository, TipoUsuarioRepository>();
builder.Services.AddScoped<IAtividadeRepository, AtividadeRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseOracle("Data Source=SEUSERVIDOR/XE;User Id=SEUUSUARIO;Password=SUASENHA;"); //alterar valores de acordo com a conexção do seu banco de dados
});
var app = builder.Build();

app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
