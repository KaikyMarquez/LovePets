using senai_lovePets_webApi.Context;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class RacaRepository : IRacaRepository
    {
        lovePetsContext ctx = new lovePetsContext();

        public void Atualizar(int idRaca, Raca RacaAtualizada)
        {
            Raca RacaBuscada = BuscarPorId(idRaca);

            if (RacaAtualizada.IdTipoPet > 0)
            {
                RacaBuscada.IdTipoPet = RacaAtualizada.IdTipoPet;
            }
            if (RacaAtualizada.NomeRaca != null)
            {
                RacaBuscada.NomeRaca = RacaAtualizada.NomeRaca;
            }

            ctx.Racas.Update(BuscarPorId(idRaca));
            ctx.SaveChanges();

        }

        public Raca BuscarPorId(int idRaca)
        {
            return ctx.Racas.Find(idRaca);
        }

        public void Cadastrar(Raca novaRaca)
        {
            ctx.Racas.Add(novaRaca);

            ctx.SaveChanges();
        }

        public void Deletar(int idRaca)
        {
            ctx.Racas.Remove(BuscarPorId(idRaca));

            ctx.SaveChanges();
        }

        public List<Raca> ListarTodos()
        {
            return ctx.Racas.ToList();
        }
    }
}
