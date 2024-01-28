using AdaTech.Modulo4.ListaExercicios.Options;
using AdaTech.Modulo4.ListaExercicios.Services;
using BenchmarkDotNet.Running;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;

namespace AdaTech.Modulo4.IOptions
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddTransient<StringOperationsService>();

            builder.Services.AddTransient<ExpressionBalanceService>();

            builder.Services.AddTransient<HotPotatoGameService>();

            builder.Services.AddTransient<WordCounterService>();

            builder.Services.Configure<StringFilterOptions>(builder.Configuration.GetSection("StringFilterOptions"));

            builder.Services.Configure<ExpressionBalanceOptions>(builder.Configuration.GetSection("ExpressionBalanceOptions"));

            builder.Services.Configure<HotPotatoGameOptions>(builder.Configuration.GetSection("HotPotatoGameOptions"));

            builder.Services.Configure<WordCounterOptions>(builder.Configuration.GetSection("WordCounterOptions"));

            builder.Services.AddControllers();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AdaTech.Modulo4.ListaExercicios", Version = "v1" });

                c.DocInclusionPredicate((docName, apiDesc) => true);

                c.TagActionsBy(api =>
                {
                    if (api.GroupName != null)
                    {
                        return new[] { api.GroupName.Replace("StringOperations", "Exercício 1").Replace("ExpressionBalance", "Exercício 2").Replace("HotPotato", "Exercício 3").Replace("WordCounter", "Exercício 4") };
                    }

                    var controllerActionDescriptor = api.ActionDescriptor as ControllerActionDescriptor;
                    if (controllerActionDescriptor != null)
                    {
                        return new[] { controllerActionDescriptor.ControllerName };
                    }

                    throw new InvalidOperationException("Unable to determine tag for endpoint.");
                });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            // Para executar o benchmark antes de o servidor web ser inicializado.
            // Se quiser conhecer mais sobre o projeto dá uma olhada nas docs: https://github.com/dotnet/BenchmarkDotNet?tab=readme-ov-file
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(["-f","*"]);

            app.Run();

        }
    }
}
