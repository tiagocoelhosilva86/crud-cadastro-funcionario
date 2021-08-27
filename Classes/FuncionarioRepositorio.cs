using System;
using System.Collections.Generic;
using App.Cadastro.interfaces;

namespace App.Cadastro.Classes
{
    public class FuncionarioRepositorio : IRepositorio<Funcionarios>
    {
        private List<Funcionarios> ListaFuncionarios = new List<Funcionarios>();
        public void Atualiza(int id, Funcionarios entidade)
        {
            ListaFuncionarios[id] = entidade;
        }

        public void Exclui(int id)
        {
            ListaFuncionarios[id].Excluir();
        }

        public void Insere(Funcionarios entidade)
        {
            ListaFuncionarios.Add(entidade);
        }

        public List<Funcionarios> Lista()
        {
            return ListaFuncionarios;
        }

        public int proximoid()
        {
            return ListaFuncionarios.Count;
        }

        public Funcionarios RetornaPorId(int id)
        {
            return ListaFuncionarios[id];
        }
    }
}