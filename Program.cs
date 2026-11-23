
class Program
{
    static void Main()
    {
        Console.WriteLine("===== LOJA DE PRODUTOS ALIMENTARES =====");
        Console.Write("Quantos clientes quer registar? ");
        int total = Convert.ToInt32(Console.ReadLine());

        // Vetores para guardar os dados de cada cliente
        string[] nomes = new string[total];
        bool[] temPrioridade = new bool[total];
        string[] motivos = new string[total];
        double[] valoresAPagar = new double[total];

        // ----- Registo dos clientes -----
        for (int i = 0; i < total; i++)
        {
            Console.WriteLine();
            Console.WriteLine("--- Cliente " + (i + 1) + " ---");

            Console.Write("Nome: ");
            nomes[i] = Console.ReadLine();

            Console.Write("Género (M/F): ");
            string genero = Console.ReadLine().ToUpper();
            while (genero != "M" && genero != "F")
            {
                Console.Write("Escreva M ou F: ");
                genero = Console.ReadLine().ToUpper();
            }

            Console.Write("Idade: ");
            int idade = Convert.ToInt32(Console.ReadLine());

            // Só pergunta se está grávida quando é mulher
            string gravida = "N";
            if (genero == "F")
            {
                Console.Write("Está grávida? (S/N): ");
                gravida = Console.ReadLine().ToUpper();
            }

            Console.Write("Pessoa com deficiência? (S/N): ");
            string deficiencia = Console.ReadLine().ToUpper();

            Console.Write("Valor total das compras (Kz): ");
            double valor = Convert.ToDouble(Console.ReadLine());

            // ----- Bónus vai depender do valor das compras-----
            double bonus = 0;
            if (valor > 100000)
            {
                bonus = valor * 0.10;
            }
            double aPagar = valor - bonus;

            // ----- Prioridade  -----
            string motivo = "";
            if (gravida == "S")
            {
                motivo = motivo + "grávida ";
            }
            if (idade >= 60)
            {
                motivo = motivo + "idoso ";
            }
            if (deficiencia == "S")
            {
                motivo = motivo + "pessoa com deficiência ";
            }

            if (motivo != "")
            {
                temPrioridade[i] = true;
            }
            else
            {
                temPrioridade[i] = false;
            }
            motivos[i] = motivo;
            valoresAPagar[i] = aPagar;

            // ----- Fatura -----
            Console.WriteLine();
            Console.WriteLine("------------- FATURA -------------");
            Console.WriteLine("Cliente       : " + nomes[i]);
            Console.WriteLine("Total compras : " + valor + " Kz");
            if (bonus > 0)
            {
                Console.WriteLine("Bónus (10%)   : -" + bonus + " Kz");
            }
            else
            {
                Console.WriteLine("Bónus         : não elegível");
            }
            Console.WriteLine("Total a pagar : " + aPagar + " Kz");
           
        }

        // ----- Ordem de atendimento -----
        Console.WriteLine();
        Console.WriteLine("===== ORDEM DE ATENDIMENTO =====");
        int posicao = 1;

        // Primeiro: quem tem prioridade
        for (int i = 0; i < total; i++)
        {
            if (temPrioridade[i] == true)
            {
                Console.WriteLine(posicao + ". " + nomes[i] + " [PRIORIDADE: " + motivos[i] + "] - a pagar " + valoresAPagar[i] + " Kz");
                posicao = posicao + 1;
            }
        }

        // Depois: os restantes
        for (int i = 0; i < total; i++)
        {
            if (temPrioridade[i] == false)
            {
                Console.WriteLine(posicao + ". " + nomes[i] + " - a pagar " + valoresAPagar[i] + " Kz");
                posicao = posicao + 1;
            }
        }

        Console.ReadKey();
    }
}