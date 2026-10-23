using Exo.WebApi.Contexts;
using Exo.WebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace Exo.WebApi.Repositories
{
    public class ProjetoRepository
    {
        private readonly ExoContext context;

        public ProjetoRepository(ExoContext context)
        {
            this.context = context;
        }

        public List<Projeto> Listar()
        {
            return context.Projetos.ToList();
        }

        public void Cadastrar(Projeto projeto)
        {
            context.Projetos.Add(projeto);
            context.SaveChanges();
        }

        public Projeto BuscarPorId(int id)
        {
            return context.Projetos.Find(id);
        }

        public void Atualizar(int id, Projeto projeto)
        {
            Projeto projetoBuscado = context.Projetos.Find(id);

            if (projetoBuscado != null)
            {
                projetoBuscado.NomeDoProjeto = projeto.NomeDoProjeto;
                projetoBuscado.Area = projeto.Area;
                projetoBuscado.Status = projeto.Status;

                context.Projetos.Update(projetoBuscado);
                context.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            Projeto projetoBuscado = context.Projetos.Find(id);

            if (projetoBuscado != null)
            {
                context.Projetos.Remove(projetoBuscado);
                context.SaveChanges();
            }
        }
    }
}