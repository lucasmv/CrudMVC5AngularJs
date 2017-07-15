namespace CrudMVC5AngularJs.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CrudMVC5AngularJs.Context.EFContext context)
        {
            #region Operadoras

            var operadora1 = new Operadora
            {
                Nome = "Oi",
                Codigo = 31,
                Categoria = "Celular",
                Preco = 1
            };

            var operadora2 = new Operadora
            {
                Nome = "Tim",
                Codigo = 41,
                Categoria = "Celular",
                Preco = 3
            };

            var operadora3 = new Operadora
            {
                Nome = "Vivo",
                Codigo = 15,
                Categoria = "Celular",
                Preco = 2
            };

            var operadora4 = new Operadora
            {
                Nome = "GVT",
                Codigo = 15,
                Categoria = "Fixo",
                Preco = 1
            };

            var operadora5 = new Operadora
            {
                Nome = "Embratel",
                Codigo = 21,
                Categoria = "Fixo",
                Preco = 1
            };

            context.Operadoras.AddOrUpdate(operadora1, operadora2, operadora3, operadora4, operadora5);

            #endregion

            #region Contatos

            var contato1 = new Contato
            {
                Nome = "Lucas Magno",
                Telefone = "98782-5257",
                Data = DateTime.Now,
                Operadora = operadora1
            };

            var contato2 = new Contato
            {
                Nome = "Anna Luisa",
                Telefone = "98756-8309",
                Data = DateTime.Now,
                Operadora = operadora1
            };

            context.Contatos.AddOrUpdate(contato1, contato2);

            #endregion


        }
    }
}
