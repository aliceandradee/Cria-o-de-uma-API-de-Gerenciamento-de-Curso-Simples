using APIGerenciamentodoCurso.Data;
using APIGerenciamentodoCurso.Repositories;
using APIGerenciamentodoCurso.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuração dos Controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. CONEXÃO COM O BANCO DE DADOS (SQLite)
// Isso cria um arquivo chamado "cursos.db" na pasta do seu projeto
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=cursos.db"));

// 3. INJEÇÃO DE DEPENDÊNCIA (A "ponte" entre a Interface e o Repositório)
// É isso que faz o seu APICursoController funcionar sem dar erro no construtor
builder.Services.AddScoped<IPCursoRepository, CursoRepository>();

var app = builder.Build();

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