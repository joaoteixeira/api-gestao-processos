using ApiGestaoProcessos.Data;
using ApiGestaoProcessos.Dtos;
using ApiGestaoProcessos.Dtos.Responses;
using ApiGestaoProcessos.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace ApiGestaoProcessos.Services
{
    public class ClienteService(AppDbContext _context, IMapper _mapper)
    {

        public async Task<ICollection<Cliente>> FindAll()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> Create(ClienteDto data)
        {
            var cliente = _mapper.Map<Cliente>(data);

            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }

        public async Task<ICollection<Processo>?> GetAllProcessosByClienteId(int id)
        {

            var cliente = await _context.Clientes.Include(c => c.Processos).FirstOrDefaultAsync(x => x.Id == id);

            if (cliente is null) return [];

            return cliente.Processos;
        }

    }
}
