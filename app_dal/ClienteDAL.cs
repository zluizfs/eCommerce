﻿using System;
using eCommerce.Models.DataContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using eCommerce.Models.Table;
using X.PagedList;

namespace eCommerceDAL
{
  public class ClienteDAL
  {
    private readonly eCommerceContext _context;

    public ClienteDAL(eCommerceContext context)
    {
      _context = context;
    }
    public async Task<List<Cliente>> Listar()
    {
      var clientes = await _context.Clientes.Include("IdPessoaNavigation.PessoaFisica")
         .Include("IdPessoaNavigation.PessoaJuridica")
         .ToListAsync();

      return clientes;
    }

    public async Task<bool> Inserir(Cliente cliente)
    {
      _context.Add(cliente);
      await _context.SaveChangesAsync();
      return true;
    }

    public async Task<bool> Atualizar(Cliente cliente)
    {
      try
      {
        _context.Update(cliente);
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ClienteExists(cliente.IdPessoa))
        {
          return false;
        }
        else
        {
          throw;
        }
      }

      return true;
    }

    public async Task<IPagedList<Cliente>> ListarPaginado(string search, int numeroPagina, int qtdeRegistros)
    {
      var clientes = await _context.Clientes.Include("IdPessoaNavigation.PessoaFisica")
        .Include("IdPessoaNavigation.PessoaJuridica")
        .Where(x => x.IdPessoaNavigation.Nome.Contains(search) || string.IsNullOrEmpty(search))
        .ToPagedListAsync(numeroPagina, qtdeRegistros);

        return clientes;
    }

    public async Task<bool> Excluir(Cliente cliente)
    {
      _context.Clientes.Remove(cliente);
      await _context.SaveChangesAsync();
      return true;
    }

    public async Task<bool> ExcluirPorId(int id)
    {
      var cliente = await this.ObterPorId(id);
      await this.Excluir(cliente);

      return true;
    }

    private bool ClienteExists(int id)
    {
      return _context.Clientes.Any(e => e.IdPessoa == id);
    }

    public async Task<Cliente> ObterPorId(int id)
    {
      var cliente = await _context.Clientes.FindAsync(id);

      return cliente;
    }


    public async Task<Cliente> ObterPessoaVinculada(int id)
    {

      var cliente = await _context.Clientes
            .Include(c => c.IdPessoaNavigation)
            .FirstOrDefaultAsync(m => m.IdPessoa == id);

      return cliente;

    }

    public async Task<Cliente> ObterPessoaFisicaOuJuridicaVinculada(int id)
    {

      var cliente = await _context.Clientes
            .Include(c => c.IdPessoaNavigation.PessoaJuridica)
            .FirstOrDefaultAsync(m => m.IdPessoa == id);

      return cliente;
    }
  }
}
