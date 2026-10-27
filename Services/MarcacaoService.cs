using ApiGestaoProcessos.Data;
using ApiGestaoProcessos.Dtos;
using ApiGestaoProcessos.Dtos.Responses;
using ApiGestaoProcessos.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace ApiGestaoProcessos.Services
{
    public class MarcacaoService(AppDbContext context, IMapper mapper)
    {
        private readonly AppDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<ICollection<MarcacaoResponseDto>> FindAll()
        {
            return await _context.Marcacoes
                .ProjectTo<MarcacaoResponseDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<MarcacaoResponseDto?> FindById(int id)
        {
            return await _context.Marcacoes
                .ProjectTo<MarcacaoResponseDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<MarcacaoResponseDto> Create(MarcacaoDto data)
        {
            var marcacao = _mapper.Map<Marcacao>(data);

            await _context.Marcacoes.AddAsync(marcacao);
            await _context.SaveChangesAsync();

            return _mapper.Map<MarcacaoResponseDto>(marcacao);
        }

        public async Task<bool> Update(int id, MarcacaoDto data)
        {
            var marcacao = await _context.Marcacoes.FirstOrDefaultAsync(x => x.Id == id);

            if (marcacao is null)
            {
                return false;
            }

            _mapper.Map(data, marcacao);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var marcacao = await _context.Marcacoes.FirstOrDefaultAsync(x => x.Id == id);

            if (marcacao is null)
            {
                return false;
            }

            _context.Marcacoes.Remove(marcacao);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<ICollection<ProcessoResponseDto>?> FindProcessos(int marcacaoId)
        {
            var marcacaoExists = await _context.Marcacoes
                .AnyAsync(m => m.Id == marcacaoId);

            if (!marcacaoExists)
            {
                return null;
            }

            return await _context.Processos
                .Where(p => p.Marcacoes!.Any(m => m.Id == marcacaoId))
                .ProjectTo<ProcessoResponseDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
