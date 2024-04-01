namespace JogoAdvinhacao {
    internal class Program {
        static void Main(string[] args) {
            int dificuldade;
            while (true) {
                Console.WriteLine("Bem vindo(a) ao Jogo de Adivinhação");
                Console.WriteLine("Escolha o nivel de dificuldade:");
                Console.WriteLine("1 - Fácil\n2 - Médio\n3 - Dificil\nEscolha: ");
                dificuldade = int.Parse(Console.ReadLine());

                ConfigurarJogo(dificuldade);
                Console.WriteLine("Pressione qualquer tecla para jogar novamente");
                Console.ReadLine();
                Console.Clear();
            }
        }
        static void ConfigurarJogo(int dificuldade) {
            int numeroAlvo = new Random().Next(1, 20);
            switch (dificuldade) {
                case 1:
                    ComecarJogo(15, numeroAlvo);
                    break;
                case 2:
                    ComecarJogo(10, numeroAlvo);
                    break;
                case 3:
                    ComecarJogo(5, numeroAlvo);
                    break;
                default:
                    Console.WriteLine("Opção inexistente");
                    break;
            }
        }
        static void ComecarJogo(int tentativas, int numeroAlvo) {
            int chute, pontuacao = 1000, valor;
            for (int i = 1; i <= tentativas; i++) {
                Console.WriteLine($"\nTentativa {i} de {tentativas}\n-------------------------");
                Console.WriteLine($"Pontuação atual: {pontuacao}");
                Console.WriteLine("Qual o seu chute?");
                chute = int.Parse(Console.ReadLine());

                if (chute == numeroAlvo) {
                    Console.WriteLine($"\nParabens, você acertou, sua pontuação final é: {pontuacao}");
                    return;
                }
                else if (chute < numeroAlvo) {
                    Console.WriteLine("\nSeu chute foi menor que o numero secreto!");
                    pontuacao -= ValorPositivo((chute - numeroAlvo) / 2);
                    Console.WriteLine($"Pontuação atual: {pontuacao}");
                }
                else if (chute > numeroAlvo) {
                    Console.WriteLine("\nSeu chute foi maior que o numero secreto!");
                    pontuacao -= (chute - numeroAlvo) / 2;
                    Console.WriteLine($"Pontuação atual: {pontuacao}");
                }

            }
            Console.WriteLine("infelizmente você nao conseguiu adivinhar o numero");
        }
        static int ValorPositivo(int valor) {
            if (valor < 0) {
                valor *= -1;
            }
            return valor;
        }
    }
}
