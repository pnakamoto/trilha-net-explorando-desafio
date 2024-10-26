namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verifica se a capacidade da suíte é suficiente para a quantidade de hóspedes
            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                // Lança uma exceção se o número de hóspedes excede a capacidade da suíte
                throw new Exception("A quantidade de hóspedes excede a capacidade da suíte.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Retorna a quantidade de hóspedes na lista Hospedes
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // Calcula o valor total da diária com base nos dias reservados e valor da suíte
            decimal valorTotal = DiasReservados * Suite.ValorDiaria;

            // Aplica um desconto de 10% se a reserva for para 10 dias ou mais
            if (DiasReservados >= 10)
            {
                valorTotal *= 0.9m; // 10% de desconto
            }

            return valorTotal;
        }
    }
}
