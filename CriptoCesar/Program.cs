using System;

namespace CriptoCesar
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

                Console.Write("Digite o texto a ser criptografado: ");
                string Texto = Console.ReadLine();

                Console.Write("Digite o valor do deslocamento: ");
                int Valor = int.Parse(Console.ReadLine());

                string TextoCodificado = Encrypt(Texto, Valor);
                Console.WriteLine($"Texto criptografado: {TextoCodificado}");

                string TextoDecodificado = Decrypt(TextoCodificado, Valor);
                Console.WriteLine($"Texto descriptografado: {TextoDecodificado}");
                Console.WriteLine("Pressione qualquer tecla para reiniciar ou 'q' para sair.");
                key = Console.ReadKey().KeyChar;

                if (key == 'q' || key == 'Q')
                {
                    reiniciar = false;
                }
            }


        }

        public static string Encrypt(string text, int shift)
        {
            char[] caracteres = text.ToCharArray();

            for (int i = 0; i < caracteres.Length; i++)
            {
                char c = caracteres[i];

                if (char.IsLetter(c))
                {
                    char LetraBase = char.IsUpper(c) ? 'A' : 'a'; //Verificação da a letra é maiúsculo ou minúsculo.
                    caracteres[i] = (char)(((c - LetraBase + shift) % 26) + LetraBase);
                }
            }

            return new string(caracteres);
        }
        public static string Decrypt(string text, int shift)
        {
            return Encrypt(text, 26 - shift); // Usamos 26 - shift para desfazer o deslocamento
        }
    }
}
