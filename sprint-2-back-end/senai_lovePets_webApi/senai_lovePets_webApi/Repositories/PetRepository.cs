using senai_lovePets_webApi.Context;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class PetRepository : IPetRepository
    {
        lovePetsContext ctx = new lovePetsContext();

        public void Atualizar(int idPet, Pet PetAtualizado)
        {
            Pet PetBuscado = BuscarPorId(idPet);

            if (PetAtualizado.NomePet != null)
            {
                PetBuscado.NomePet = PetAtualizado.NomePet;
            }
            if (PetAtualizado.IdRaca > 0)
            {
                PetBuscado.IdRaca = PetAtualizado.IdRaca;
            }
            if (PetAtualizado.IdDono > 0)
            {
                PetBuscado.IdDono = PetAtualizado.IdDono;
            }
            if (PetAtualizado.DataNascimento <= DateTime.Today)
            {
                PetBuscado.DataNascimento = PetAtualizado.DataNascimento;
            }
            if (PetAtualizado.IdUsuario > 0)
            {
                PetBuscado.IdUsuario = PetAtualizado.IdUsuario;
            }

            ctx.Pets.Update(BuscarPorId(idPet));
            ctx.SaveChanges();

        }

        public Pet BuscarPorId(int idPet)
        {
            return ctx.Pets.Find(idPet);
        }

        public void Cadastrar(Pet novoPet)
        {
            ctx.Pets.Add(novoPet);
            ctx.SaveChanges();
        }

        public void Deletar(int idPet)
        {
            ctx.Pets.Remove(BuscarPorId(idPet));

            ctx.SaveChanges();
        }

        public List<Pet> ListarTodos()
        {
            return ctx.Pets.ToList();
        }
    }
}
