using Microsoft.AspNetCore.Mvc;
using Shopping.ViewModels;

namespace Shopping.Controllers;

public class LojaController : Controller
{
    //lista vazia para testar o if else:
    //private static List<LojaViewModel> lojas = new List<LojaViewModel>();

   private static List<LojaViewModel> lojas = new List<LojaViewModel> {
        new LojaViewModel(32, 3, "Tênis Brasil", "Aqui você encontra os tênis", "Loja", "tenis@email.com"),
        new LojaViewModel(33, 3, "Lembranças Já", "Vem comprar sua lembrança","Kiosque", "lemb@email.com"),
        new LojaViewModel(12, 1, "Sorvetinho Gelado", "Sorvetinho Gelado", "Kiosque", "sorvet@email.com")
    };

    public IActionResult Lista()
    { 
        return View(lojas);
    }

    public IActionResult Admin()
    { 
        return View(lojas);
    }

     public IActionResult Detalhe(int id)
    {
        foreach(var loja in lojas)
        {
            if(loja.Id == id)
            {
               return View(loja);
            }
        }

        return View();
    }

    public IActionResult Cadastrar([FromForm] int id, [FromForm] int piso, [FromForm] string nome, [FromForm] string descricao , [FromForm] string categoria, [FromForm] string email)
    {
        foreach(var loja in lojas)
        {
            if(loja.Nome.Equals(nome))
            {
                ViewData ["Nome"] = loja.Nome;
                return View("MensagemErro");
            }
        }

        if(id != 0)
        { 
            lojas.Add(new LojaViewModel(id, piso, nome, descricao, categoria, email));
        }  

        return View();
    }

    public IActionResult Excluir(int id)
    {
        foreach(var loja in lojas)
        {
            if(loja.Id == id)
            {
               lojas.Remove(loja);
               ViewData ["Nome"] = loja.Nome;
               return View("MensagemSucesso");
            }
        }

        return View();
    }

}