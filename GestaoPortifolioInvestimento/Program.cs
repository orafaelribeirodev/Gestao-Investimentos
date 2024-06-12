using GestaoPortifolioInvestimento.Application;
using GestaoPortifolioInvestimento.Repositories.Helps;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<GestaoPortifolioInvestimento.Repositories.IProdutoRepositories, GestaoPortifolioInvestimento.Repositories.ProdutoRepositories>();
builder.Services.AddScoped<GestaoPortifolioInvestimento.Application.IProdutoService, GestaoPortifolioInvestimento.Application.ProdutoService>();
builder.Services.AddScoped<GestaoPortifolioInvestimento.Repositories.IProdutoEstoqueRepositories, GestaoPortifolioInvestimento.Repositories.ProdutoEstoqueRepositories>();
builder.Services.AddScoped<GestaoPortifolioInvestimento.Application.IProdutoEstoqueService, GestaoPortifolioInvestimento.Application.ProdutoEstoqueService>();
builder.Services.AddScoped<GestaoPortifolioInvestimento.Repositories.IEstoqueSaidaRepositories, GestaoPortifolioInvestimento.Repositories.EstoqueSaidaRepositories>();
builder.Services.AddScoped<GestaoPortifolioInvestimento.Application.IEstoqueSaidaService, GestaoPortifolioInvestimento.Application.EstoqueSaidaService>();
builder.Services.AddScoped<GestaoPortifolioInvestimento.Repositories.IEstoqueSaidaProdutoRepositories, GestaoPortifolioInvestimento.Repositories.EstoqueSaidaProdutoRepositories>();
builder.Services.AddScoped<GestaoPortifolioInvestimento.Application.IEstoqueSaidaProdutoService, GestaoPortifolioInvestimento.Application.EstoqueSaidaProdutoService>();
builder.Services.AddHostedService<EmailNotificacaoService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

Settings.StrConnection = app.Configuration.GetConnectionString("DefaultConnection");

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Investment Portfolio API V1");
    });
}

app.UseCors(x => x.AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowAnyOrigin());
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
