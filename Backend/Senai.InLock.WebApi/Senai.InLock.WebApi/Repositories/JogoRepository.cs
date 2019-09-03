using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogoRepository
    {
        public List<Jogos> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.ToList();
            }
        }

        public List<Jogos> ListarEstudiosEJogos()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.Include(x => x.Estudio).ToList();
            }
        }

        public List<Jogos> ListarPeloPreco()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.Take(5).OrderByDescending(x => x.Valor).ToList();
            }
        }

        public List<Jogos> ListarLancamentos()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.OrderByDescending(x => x.DataLancamento).ToList();
            }
        }

        public Jogos BuscarPorNome(string nome)
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.FirstOrDefault(x => x.NomeJogo == nome);
            }
        }

        public Jogos BuscarPorId(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.FirstOrDefault(x => x.JogosId == id);
            }
        }

        public void Cadastrar(Jogos jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Jogos.Add(jogo);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Jogos jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Jogos JogoBuscado = ctx.Jogos.FirstOrDefault(x => x.JogosId == jogo.JogosId);
                JogoBuscado.NomeJogo = jogo.NomeJogo;
                ctx.Jogos.Update(JogoBuscado);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Jogos JogoBuscado = ctx.Jogos.Find(id);
                ctx.Jogos.Remove(JogoBuscado);
                ctx.SaveChanges();
            }
        }
    }
}
