using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CharacterRanking
{
    class Program
    {
        static void Main(string[] args)
        {
            bool reiniciar = true;

            while (reiniciar)
            {
                Console.WriteLine("Bem-vindo! Pressione qualquer tecla para continuar ou 'q' para sair.");
                var key = Console.ReadKey().KeyChar;

                if (key == 'q' || key == 'Q')
                {
                    reiniciar = false;
                    continue;
                }

                Console.WriteLine("Digite o caminho completo do arquivo de texto:");
                string filePath = Console.ReadLine();

                Dictionary<char, int> charCount = CharacterCount(filePath);

                Console.WriteLine("Ranking de Caracteres:");
                foreach (var entry in charCount.OrderByDescending(e => e.Value))
                {
                    Console.WriteLine($"{entry.Key}: {entry.Value} ocorrências");
                }

                Console.WriteLine("Pressione qualquer tecla para reiniciar ou 'q' para sair.");
                key = Console.ReadKey().KeyChar;

                if (key == 'q' || key == 'Q')
                {
                    reiniciar = false;
                }
            }

            Console.WriteLine("Programa encerrado.");

        }

        static Dictionary<char, int> CharacterCount(string filePath)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    foreach (char character in line)
                    {
                        if (charCount.ContainsKey(character))
                        {
                            charCount[character]++;
                        }
                        else
                        {
                            charCount.Add(character, 1);
                        }
                    }
                }
            }

            return charCount;
        }
    }
}

