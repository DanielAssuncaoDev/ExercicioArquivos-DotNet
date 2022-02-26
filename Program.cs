using System;
using System.Collections.Generic;
using System.IO;

namespace Exerc_Arquivos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insira o Path do arquivo .CSV: ");
            string path = Console.ReadLine();
            while (Path.GetExtension(path) != ".csv")
            {
                Console.WriteLine("Insira o Path do arquivo .CSV: ");
                path = Console.ReadLine();
            }
            try
            {
                string newDirectory = Path.GetDirectoryName(path) + @"\out";
                Directory.CreateDirectory(newDirectory);
                

                using (FileStream file = new FileStream(path, FileMode.Open))
                {
                    using (StreamReader readerFile = new StreamReader(file) )
                    {
                        using (
                            StreamWriter writerFile = 
                                new StreamWriter(
                                    new FileStream(newDirectory + @"\summary.csv", FileMode.Create)
                                )
                            )
                        {
                            // Lê as linhas do arquivo .CSV, os transforma em uma instância de Produto
                            while (!readerFile.EndOfStream)
                            {
                                string line = readerFile.ReadLine();
                                Produto produto = new Produto(line);
                                Console.WriteLine(produto.TransformProdutoInCSV());
                                writerFile.WriteLine(produto.TransformProdutoInCSV());
                            }
                        }  
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
