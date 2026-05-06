namespace SimuladorBanco.Estructuras
{
    public class NodoCola
    {
        public string DatoCliente { get; set; }
        public NodoCola Siguiente { get; set; }

        public NodoCola(string datoCliente)
        {
            DatoCliente = datoCliente;
            Siguiente = null;
        }
    }
}