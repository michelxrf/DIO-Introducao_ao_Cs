using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            int indice_aluno = 0;
            string opcao_usuario = obter_opcao_usuario();      

            while (opcao_usuario.ToUpper() != "X")
            {
                switch (opcao_usuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno: ");

                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno: ");

                        if(decimal.TryParse(Console.ReadLine(), out decimal nota))
                            aluno.Nota = nota;
                        else
                            throw new ArgumentException("O valor da nota deve ser decimal");

                        alunos[indice_aluno] = aluno;
                        indice_aluno++;

                        break;

                    case "2":
                        for(int i = 0; i < indice_aluno; i++)
                        {
                            if(alunos[i].Nome != "")
                            Console.WriteLine($"ALUNO: {alunos[i].Nome} - NOTA: {alunos[i].Nota}");
                        }
                        break;

                    case "3":
                        decimal media = 0;
                        for(int i = 0; i < indice_aluno; i++)
                        {
                            media += alunos[i].Nota;
                        }

                        Conceito conceito;    
                        if(media < 2)
                            conceito = Conceito.E;
                        else if(media < 4)
                            conceito = Conceito.D;
                        else if(media < 6)
                            conceito = Conceito.C;
                        else if(media < 8)
                            conceito = Conceito.B;
                        else
                            conceito = Conceito.A;
                        

                        Console.WriteLine($"Média geral é: {media/indice_aluno} GRADE: {conceito}");
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }

                opcao_usuario = obter_opcao_usuario();

            }
        }

        private static string obter_opcao_usuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            String opcao_usuario = Console.ReadLine();
            Console.WriteLine();
            return opcao_usuario;
        }
    }
}
