using System;
using App.Cadastro;
namespace App.Cadastro.Classes
{
    public class Funcionarios : EntidadeBase
    {
        // atributos
        private string nome { get; set; }
        private int idade { get; set; }
        private EGenero sexo { get; set; }

        private bool Excluido { get; set; }

        //Métodos
        public Funcionarios(int id, string nome, int idade, EGenero sexo)
        {
            this.id = id;
            this.nome = nome;
            this.idade = idade;
            this.sexo = sexo;
            this.Excluido = false;
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += "nome:" + this.nome + Environment.NewLine;
            retorno += "idade:" + this.idade + Environment.NewLine;
            retorno += "sexo:" + this.sexo + Environment.NewLine;
            return retorno;
        }
        public string retornaNome()
        {
            return this.nome;
        }
        public int retornaId()
        {
            return this.id;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }
    }

}