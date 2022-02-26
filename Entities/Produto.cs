namespace Exerc_Arquivos
{
    class Produto
    {
        public string Descricao { get; private set; }
        public double Preco { get; private set; }
        public int Quantidade { get; private set; }

        public Produto() { }
        public Produto(string descricao, double preco, int quantidade)
        {
            Descricao = descricao;
            Preco = preco;
            Quantidade = quantidade;
        }
        public Produto(string produtoInCSV)
        {
            TransformCSVInProduto(produtoInCSV);
        }


        public double CalcularTotal()
        {
            return Preco * Quantidade;
        }

        public void TransformCSVInProduto(string produto)
        {
            string[] atributos = produto.Split(',');
            Descricao = atributos[0];
            Preco = double.Parse(atributos[1]);
            Quantidade = int.Parse(atributos[2]);
        }

        public string TransformProdutoInCSV()
        {
            return $"{Descricao},{CalcularTotal()}";
        }


    }
}
