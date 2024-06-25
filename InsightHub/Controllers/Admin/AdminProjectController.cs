using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using InsightHub.Models;
using InsightHub.Data;
using Microsoft.EntityFrameworkCore;

namespace InsightHub.Controllers;

[Route("/gerenciador/projetos")]
public class AdminProjectController : Controller
{
    [Route("/gerenciador/projetos")]
    public async Task<IActionResult> List([FromServices] AppDbContext context, [FromQuery] int? page)
    {
        int pageSize = 10; // Número de itens por página
        int currentPage = page ?? 1; // Página atual, padrão é 1 se não for fornecido

        var projetos = await context.Projeto
            .OrderBy(x => x.Id)
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        int totalItems = await context.Projeto.CountAsync();
        int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

        ViewBag.CurrentPage = currentPage;
        ViewBag.TotalPages = totalPages;
        ViewBag.Projetos = projetos;

        return View();
    }

    [Route("/gerenciador/projetos/edit/{Id?}")]
    public async Task<IActionResult> Edit([FromServices] AppDbContext context, int? Id)
    {
        ViewBag.Areas = await context.AreaConhecimento.ToListAsync();
        ViewBag.Subareas = await context.SubareaConhecimento.ToListAsync();
        ViewBag.Pesquisadores = await context.Pesquisador.ToListAsync();

        ViewBag.Projeto = null;

        if (Id != 0)
        {
            ViewBag.Projeto = await context.Projeto
            .Include(p => p.Subarea)
            .FirstOrDefaultAsync(p => p.Id == Id);
        }

        return View();
    }


    [Route("/gerenciador/projetos/edit-form/{Id?}")]
    public async Task<IActionResult> Update([FromServices] AppDbContext context, [FromForm] Projeto model, int? Id)
    {
        if (Id != null)
        {
            var projeto = await context.Projeto.FindAsync(Id);
            if (projeto != null)
            {
                projeto.Nome = model.Nome;
                projeto.DataInicio = model.DataInicio;
                projeto.DataFim = model.DataFim;
                projeto.SubareaId = model.SubareaId;

                context.Projeto.Update(projeto);
            }
        }
        else
        {
            context.Projeto.Add(model);
        }

        _ = await context.SaveChangesAsync();
        return Redirect("/gerenciador/projetos");
    }

    [Route("/gerenciador/projetos/delete-form/{Id}")]
    public IActionResult Delete([FromServices] AppDbContext context, int? id)
    {
        // Recuperar a instância existente no banco de dados
        var projeto = context.Projeto.FirstOrDefault(c => c.Id == id);

        if (projeto == null)
            return NotFound();

        context.Projeto.Remove(projeto);
        context.SaveChanges();

        return Redirect("/gerenciador/projetos");
    }
}