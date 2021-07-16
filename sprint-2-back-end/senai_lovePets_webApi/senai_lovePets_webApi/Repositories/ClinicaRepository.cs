using senai_lovePets_webApi.Context;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        lovePetsContext ctx = new lovePetsContext();


        public void Atualizar(int idClinica, Clinica ClinicaAtualizada)
        {
            Clinica ClinicaBuscada = BuscarPorId(idClinica);

            if (ClinicaAtualizada.Endereco != null)
            {
                ClinicaBuscada.Endereco = ClinicaAtualizada.Endereco;
            }

            if (ClinicaAtualizada.RazaoSocial != null)
            {
                ClinicaBuscada.RazaoSocial = ClinicaAtualizada.RazaoSocial;
            }

            if (ClinicaAtualizada.Cnpj != null)
            {
                ClinicaBuscada.Cnpj = ClinicaAtualizada.Cnpj;
            }

            ctx.Clinicas.Update(ClinicaBuscada);
            ctx.SaveChanges();
        }

        public Clinica BuscarPorId(int idClinica)
        {
            return ctx.Clinicas.Find(idClinica);
        }

        public void Cadastrar(Clinica novaClinica)
        {
            ctx.Clinicas.Add(novaClinica);

            ctx.SaveChanges();
        }

        public void Deletar(int idClinica)
        {
            ctx.Clinicas.Remove(BuscarPorId(idClinica));

        }

        public List<Clinica> ListarTodos()
        {
            return ctx.Clinicas.ToList();
        }
    }
}
