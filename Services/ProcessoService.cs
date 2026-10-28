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

        public async Task<bool> AssociarMarcacao(int processoId, int marcacaoId)
        {
            var processo = await _context.Processos
                .Include(p => p.Marcacoes)
                .FirstOrDefaultAsync(p => p.Id == processoId);
            var marcacao = await _context.Marcacoes
                .FirstOrDefaultAsync(m => m.Id == marcacaoId);

            if (processo is null || marcacao is null)
            {
                return false;
            }

            processo.Marcacoes ??= new List<Marcacao>();

            if (!processo.Marcacoes.Any(m => m.Id == marcacaoId))
            {
                processo.Marcacoes.Add(marcacao);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public async Task<(bool ProcessoExiste, bool EtapaExiste, bool JaAssociada, ProcessoEtapaResponseDto? Resultado)> 
            AddEtapa(int processoId, ProcessoEtapaDto data)
            {

                var processoExiste = await _context.Processos.AnyAsync(x => x.Id == processoId);
                var etapaExiste = await _context.Etapas.AnyAsync(x => x.Id == data.EtapaId);

                if (!processoExiste || !etapaExiste)
                {
                    return (processoExiste, etapaExiste, false, null);
                }

                var jaAssociada = await _context.ProcessosEtapas.AnyAsync(x => x.ProcessoId == processoId && x.EtapaId == data.EtapaId);

                if (jaAssociada) 
                {
                    return (true, true, true, null);
                }

                var processoEtapa = _mapper.Map<ProcessoEtapa>(data);
                processoEtapa.ProcessoId = processoId;

                _context.ProcessosEtapas.Add(processoEtapa);
                await _context.SaveChangesAsync();

                var resultado = await _context.ProcessosEtapas
                                        .Where(x => x.ProcessoId == processoId && x.EtapaId == data.EtapaId)
                                        .ProjectTo<ProcessoEtapaResponseDto>(_mapper.ConfigurationProvider)
                                        .FirstAsync();

                return (true, true, false, resultado);
            }
    }
}
