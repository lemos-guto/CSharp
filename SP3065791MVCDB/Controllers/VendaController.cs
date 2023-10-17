using Microsoft.AspNetCore.Mvc;
using SP3065791MVCDB.Models;
namespace SP3065791MVCDB.Controllers;
public class VendaController : Controller
{
    private readonly MvcDBContext _context;

    public VendaController(MvcDBContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Vendas);
    }

    public IActionResult Show(int vendaId)
    {
        Venda? venda = _context.Vendas.Find(vendaId);

        if (venda == null)
        {
            return NotFound();
        }
        return View(venda);
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult CreateResult(int vendaId, int pedidoId, int clienteId, string dataVenda, int descontoVenda, int valorBrutoVenda)
    {
        if (_context.Vendas.Find(vendaId) == null)
        {
            _context.Vendas.Add(new Venda(vendaId, pedidoId, clienteId, dataVenda, descontoVenda, valorBrutoVenda));
            _context.SaveChanges();
            return RedirectToAction("Create");
        }
        else
        {
            return Content("Já existe uma Venda com esse id.");
        }

    }

    public IActionResult Delete(int vendaId)
    {
        _context.Vendas.Remove(_context.Vendas.Find(vendaId));
        _context.SaveChanges();
        return View();
    }

    public IActionResult Update(int vendaId)
    {
        Venda venda = _context.Vendas.Find(vendaId);
        if (venda == null)
        {
            return Content("Esse venda não existe.");
        }
        else
        {
            return View(venda);
        }
    }

    public IActionResult UpdateResult(int vendaId, int pedidoId, int clienteId, string dataVenda, int descontoVenda, int valorBrutoVenda)
    {
        Venda venda = _context.Vendas.Find(vendaId);

        venda.VendaId = vendaId;
        venda.PedidoId = pedidoId;
        venda.ClienteId = clienteId;
        venda.DataVenda = dataVenda;
        venda.DescontoVenda = descontoVenda;
        venda.ValorBrutoVenda = valorBrutoVenda;

        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}