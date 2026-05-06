namespace SimuladorBanco.Estructuras
{
    public class ColaAtencion
    {
        private NodoCola frente;
        private NodoCola final;

        public ColaAtencion()
        {
            frente = null;
            final = null;
        }

        public void Encolar(string nombreCliente)
        {
            NodoCola nuevo = new NodoCola(nombreCliente);
            if (final == null)
            {
                frente = nuevo;
                final = nuevo;
            }
            else
            {
                final.Siguiente = nuevo;
                final = nuevo;
            }
        }

        public string Desencolar()
        {
            if (frente == null)
                return null;

            string dato = frente.DatoCliente;
            frente = frente.Siguiente;

            if (frente == null)
                final = null;

            return dato;
        }

        public bool EstaVacia()
        {
            return frente == null;
        }

        public void MostrarCola()
        {
            if (frente == null)
            {
                Console.WriteLine("No hay clientes en la cola de atención.");
                return;
            }
            NodoCola actual = frente;
            int turno = 1;
            while (actual != null)
            {
                Console.WriteLine($"Turno {turno}: {actual.DatoCliente}");
                actual = actual.Siguiente;
                turno++;
            }
        }

        public string VerSiguiente()
        {
            if (frente == null)
                return null;
            return frente.DatoCliente;
        }
    }
}