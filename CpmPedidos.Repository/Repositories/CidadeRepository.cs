using CpmPedidos.Domain.Dtos;
using CpmPedidos.Domain.Entities;
using CpmPedidos.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CpmPedidos.Repository.Repositories
{
    public class CidadeRepository : BaseRepository, ICidadeRepository
    {
        public CidadeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        
        public dynamic Get()
        {
            return _context.Cidades
                .Where(x => x.Ativo)
                .Select(x => new
                {
                    x.Id,
                    x.Nome,
                    x.Uf,
                    x.Ativo
                }).ToList();
        }

        public int Criar(CidadeDTO model)
        {
            if (model.Id > 0)
            {
                return 0;
            }

            var nomeDuplicado = _context.Cidades.Any(x => x.Ativo && x.Nome.ToUpper() 
                == model.Nome.ToUpper());

            if (nomeDuplicado)
                return 0;
            
            var entity = new Cidade()
            {
                Nome = model.Nome,
                Uf = model.Uf,
                Ativo = model.Ativo
            };

            try
            {
                //salvar tudo no dbcontext
                _context.Cidades.Add(entity);

                //salva tudo que está no cash, tudo aquilo que está pendente
                _context.SaveChanges();
                return entity.Id;
            }
            catch (Exception ex)
            {
                //Ignore
            }
            
            return 0;
        }

        public int Alterar(CidadeDTO model)
        {
            if (model.Id <= 0)
                return 0;
            
            var entity = _context.Cidades.Find(model.Id);
            if (entity == null)
            {
                return 0;
            }

            var nomeDuplicado = _context.Cidades.Any(x => x.Ativo && x.Nome.ToUpper() 
                == model.Nome.ToUpper() && x.Id != model.Id);

            if (nomeDuplicado)
                return 0;
            
            entity.Nome = model.Nome;
            entity.Uf = model.Uf;
            entity.Ativo = model.Ativo;

            try
            {
                _context.Cidades.Update(entity);
                _context.SaveChanges();

                return entity.Id;
            }
            catch (Exception)
            {
                //ignore
            }

            return 0;
        }

        public bool Excluir(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            var entity = _context.Cidades.Find(id);
            if (entity == null)
            {
                return false;
            }

            try
            {
                _context.Cidades.Remove(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                //ignore
            }

            return false;
        }
    }
}
