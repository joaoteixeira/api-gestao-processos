using ApiGestaoProcessos.Data;
using ApiGestaoProcessos.Dtos;
using ApiGestaoProcessos.Dtos.Responses;
using ApiGestaoProcessos.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace ApiGestaoProcessos.Services
{
    public class ProcessoService(AppDbContext context, IMapper mapper)
    {
        private readonly AppDbContext _context = context;

        private readonly IMapper _mapper = mapper;


        public async Task<ICollection<ProcessoResponseDto>> FindAll()
        {
            return await _context.Processos
                .ProjectTo<ProcessoResponseDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<ProcessoResponseDto?> FindById(int id)
        {
            return await _context.Processos
                .ProjectTo<ProcessoResponseDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Processo> Create(ProcessoDto data)
        {
            var processo = _mapper.Map<Processo>(data);

            await _context.Processos.AddAsync(processo);
            await _context.SaveChangesAsync();

            return processo;
        }

        public async Task<Processo> Update(int id, ProcessoUpdateDto data)
        {

            var processo = await _context.Processos.FirstOrDefaultAsync(x => x.Id == id);

            if (processo is null)
            {
                throw new Exception("Processo não encontrado");
            }

             _mapper.Map(data, processo);

            _context.Processos.Update(processo);
            await _context.SaveChangesAsync();

            return processo;
        }
    }
}
