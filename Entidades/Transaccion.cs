namespace SimuladorBanco.Entidades
{
    public class Transaccion
    {
        public string TipoOperacion { get; set; }
        public double Monto { get; set; }
        public string CedulaCliente { get; set; }

        public Transaccion(string tipoOperacion, double monto, string cedulaCliente)
        {
            TipoOperacion = tipoOperacion;
            Monto = monto;
            CedulaCliente = cedulaCliente;
        }
    }
}