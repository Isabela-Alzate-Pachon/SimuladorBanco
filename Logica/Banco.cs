using SimuladorBanco.Estructuras;

namespace SimuladorBanco.Logica
{
    public class Banco
    {
        public string Nombre { get; set; }
        public ListaEnlazadaClientes Clientes { get; set; }
        public ColaAtencion Cola { get; set; }
        public PilaTransacciones Pila { get; set; }

        public Banco(string nombre)
        {
            Nombre = nombre;
            Clientes = new ListaEnlazadaClientes();
            Cola = new ColaAtencion();
            Pila = new PilaTransacciones();
        }
    }
}