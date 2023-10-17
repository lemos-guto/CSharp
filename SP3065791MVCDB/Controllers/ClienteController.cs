using Microsoft.AspNetCore.Mvc;
using SP3065791MVCDB.Models;
namespace SP3065791MVCDB.Controllers;
public class ClienteController : Controller
{
    private readonly MvcDBContext _context;

    public ClienteController(MvcDBContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Clientes);
    }

    public IActionResult Show(int clienteId)
    {
        Cliente? cliente = _context.Clientes.Find(clienteId);

        if (cliente == null)
        {
            return NotFound();
        }
        return View(cliente);
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult CreateResult(int clienteId, string nome, string rg, string cpf, string endereco)
    {
        if (_context.Clientes.Find(clienteId) == null)
        {
            _context.Clientes.Add(new Cliente(clienteId, nome, rg, cpf, endereco));
            _context.SaveChanges();
            return RedirectToAction("Create");
        }
        else
        {
            return Content("Já existe um Cliente com esse id.");
        }

    }

    public IActionResult Delete(int clienteId)
    {
        _context.Clientes.Remove(_context.Clientes.Find(clienteId));
        _context.SaveChanges();
        return View();
    }

    public IActionResult Update(int clienteId)
    {
        Cliente clientes = _context.Clientes.Find(clienteId);
        if (clientes == null)
        {
            return Content("Esse cliente não existe.");
        }
        else
        {
            return View(clientes);
        }
    }

    public IActionResult UpdateResult(int clienteId, string nome, string rg, string cpf, string endereco)
    {
        Cliente cliente = _context.Clientes.Find(clienteId);

        cliente.ClienteId = clienteId;
        cliente.Nome = nome;
        cliente.RG = rg;
        cliente.CPF = cpf;
        cliente.Endereco = endereco;
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}