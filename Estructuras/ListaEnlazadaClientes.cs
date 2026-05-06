using SimuladorBanco.Entidades;

namespace SimuladorBanco.Estructuras
{
    public class ListaEnlazadaClientes
    {
        private NodoCliente cabeza;

        public ListaEnlazadaClientes()
        {
            cabeza = null;
        }

        public bool Insertar(Cliente cliente)
        {
            if (BuscarPorCedula(cliente.Cedula) != null || BuscarPorCuenta(cliente.NumeroCuenta) != null)
                return false;

            NodoCliente nuevo = new NodoCliente(cliente);

            if (cabeza == null)
            {
                cabeza = nuevo;
            }
            else
            {
                NodoCliente actual = cabeza;
                while (actual.Siguiente != null)
                    actual = actual.Siguiente;
                actual.Siguiente = nuevo;
            }
            return true;
        }

        public Cliente BuscarPorCedula(string cedula)
        {
            NodoCliente actual = cabeza;
            while (actual != null)
            {
                if (actual.Dato.Cedula == cedula)
                    return actual.Dato;
                actual = actual.Siguiente;
            }
            return null;
        }

        public Cliente BuscarPorCuenta(string numeroCuenta)
        {
            NodoCliente actual = cabeza;
            while (actual != null)
            {
                if (actual.Dato.NumeroCuenta == numeroCuenta)
                    return actual.Dato;
                actual = actual.Siguiente;
            }
            return null;
        }

        public void Listar()
        {
            if (cabeza == null)
            {
                Console.WriteLine("No hay clientes registrados.");
                return;
            }
            NodoCliente actual = cabeza;
            int i = 1;
            while (actual != null)
            {
                Console.WriteLine($"{i}. {actual.Dato.NombreCompleto} | Cédula: {actual.Dato.Cedula} | Cuenta: {actual.Dato.NumeroCuenta} | Saldo: ${actual.Dato.Saldo}");
                actual = actual.Siguiente;
                i++;
            }
        }

        public int Contar()
        {
            int contador = 0;
            NodoCliente actual = cabeza;
            while (actual != null)
            {
                contador++;
                actual = actual.Siguiente;
            }
            return contador;
        }

        public double TotalDinero()
        {
            double total = 0;
            NodoCliente actual = cabeza;
            while (actual != null)
            {
                total += actual.Dato.Saldo;
                actual = actual.Siguiente;
            }
            return total;
        }
    }
}