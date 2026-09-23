using ApiGestaoProcessos.Data;
using ApiGestaoProcessos.Dtos;
using ApiGestaoProcessos.Entities;
using AutoMapper;
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

    }
}
