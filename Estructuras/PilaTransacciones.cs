using SimuladorBanco.Entidades;

namespace SimuladorBanco.Estructuras
{
    public class PilaTransacciones
    {
        private NodoPila tope;

        public PilaTransacciones()
        {
            tope = null;
        }

        public void Apilar(Transaccion transaccion)
        {
            NodoPila nuevo = new NodoPila(transaccion);
            nuevo.Siguiente = tope;
            tope = nuevo;
        }

        public Transaccion Desapilar()
        {
            if (tope == null)
                return null;

            Transaccion dato = tope.Dato;
            tope = tope.Siguiente;
            return dato;
        }

        public Transaccion VerTope()
        {
            if (tope == null)
                return null;
            return tope.Dato;
        }

        public bool EstaVacia()
        {
            return tope == null;
        }
    }
}