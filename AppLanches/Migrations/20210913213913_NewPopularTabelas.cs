using Microsoft.EntityFrameworkCore.Migrations;

namespace AppLanches.Migrations
{
    public partial class NewPopularTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome,Descricao) VALUES('Normal','Lanche feito com ingredientes normais')");
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome,Descricao) VALUES('Natural','Lanche feito com ingredientes integrais e naturais')");

            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsLanchePreferido,Nome,Preco) VALUES((SELECT CategoriaId FROM Categorias Where CategoriaNome='Normal'),'Pão, hambúrguer artesanal, mussarela, alface, cebola e batata frita artesanal','Delicioso pão de hambúrger artesanal; hambúrger e demais ingredientes de primeira qualidade acompanhado com batata frita',1, 'https://images.unsplash.com/photo-1594212699903-ec8a3eca50f5?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=751&q=80','https://images.unsplash.com/photo-1594212699903-ec8a3eca50f5?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=751&q=80', 0 ,'Lanche Tradicional', 25.00)");
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsLanchePreferido,Nome,Preco) VALUES((SELECT CategoriaId FROM Categorias Where CategoriaNome='Normal'),'Pão, hambúrguer artesanal, Bacon, mussarela, alface e tomate','Delicioso pão de hambúrguer quentinho com bancon, hambúrguer e mussarela bem servidos com tomate e alface preparado com carinho.',1,'https://images.unsplash.com/photo-1586190848861-99aa4a171e90?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=500&q=80','https://images.unsplash.com/photo-1586190848861-99aa4a171e90?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=500&q=80',0,'Big Bacon', 20.00)");
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsLanchePreferido,Nome,Preco) VALUES((SELECT CategoriaId FROM Categorias Where CategoriaNome='Normal'),'Pão, hambúrguer, queijo, ketchup, picles tomate, cabola e alface','Pão de hambúrger especial com hambúrger de nossa preparação e com alface, cebola, picles e tomates frescos.',1,'https://images.unsplash.com/photo-1571091718767-18b5b1457add?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=752&q=80','https://images.unsplash.com/photo-1571091718767-18b5b1457add?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=752&q=80',0,'Hambúrguer Simples', 20.00)");
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsLanchePreferido,Nome,Preco) VALUES((SELECT CategoriaId FROM Categorias Where CategoriaNome='Normal'),'Pão, hambúrguer artesanal, pão especial, mussarela, molho especial cebola roxa','Delicioso molho especial com hambúrger artesanal; hambúrger e demais ingredientes de primeira qualidade acompanhado com uma mussarela maravilhosa',1,'https://images.unsplash.com/photo-1549611016-3a70d82b5040?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=716&q=80','https://images.unsplash.com/photo-1549611016-3a70d82b5040?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=716&q=80',0,'Lanche Natural Peito Peru', 15.00)");
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsLanchePreferido,Nome,Preco) VALUES((SELECT CategoriaId FROM Categorias Where CategoriaNome='Natural'),'Pão Integral, queijo branco, tomate, alface, melhor vegano','Pão integral natural com queijo branco, rodelas de tomate com alface picado e molho vegano.',1,'https://images.unsplash.com/photo-1520072959219-c595dc870360?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=853&q=80','https://images.unsplash.com/photo-1520072959219-c595dc870360?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=853&q=80',0,'Lanche Natural Vegan', 15.00)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
            migrationBuilder.Sql("DELETE FROM Lanches");
        }
    }
}
