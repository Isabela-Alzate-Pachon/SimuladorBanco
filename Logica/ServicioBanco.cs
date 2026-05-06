using SimuladorBanco.Entidades;

namespace SimuladorBanco.Logica
{
    public class ServicioBanco
    {
        private Banco banco;

        public ServicioBanco(Banco banco)
        {
            this.banco = banco;
        }

        // ── Clientes ──────────────────────────────────────────

        public bool RegistrarCliente(string cedula, string nombre, string numeroCuenta, double saldo)
        {
            Cliente nuevo = new Cliente(cedula, nombre, numeroCuenta, saldo);
            return banco.Clientes.Insertar(nuevo);
        }

        public void ListarClientes()
        {
            banco.Clientes.Listar();
        }

        public void BuscarCliente(string cedula)
        {
            Cliente c = banco.Clientes.BuscarPorCedula(cedula);
            if (c == null)
                Console.WriteLine("Cliente no encontrado.");
            else
                Console.WriteLine($"Nombre: {c.NombreCompleto} | Cuenta: {c.NumeroCuenta} | Saldo: ${c.Saldo}");
        }

        public int TotalClientes()
        {
            return banco.Clientes.Contar();
        }

        public double TotalDineroBanco()
        {
            return banco.Clientes.TotalDinero();
        }

        // ── Cola ──────────────────────────────────────────────

        public void AgregarACola(string cedula)
        {
            Cliente c = banco.Clientes.BuscarPorCedula(cedula);
            if (c == null)
            {
                Console.WriteLine("Cliente no encontrado.");
                return;
            }
            banco.Cola.Encolar(c.NombreCompleto);
            Console.WriteLine($"{c.NombreCompleto} agregado a la cola de atención.");
        }

        public void AtenderSiguiente()
        {
            if (banco.Cola.EstaVacia())
            {
                Console.WriteLine("No hay clientes en la cola de atención.");
                return;
            }
            string atendido = banco.Cola.Desencolar();
            Console.WriteLine($"Atendiendo a: {atendido}");
        }

        public void MostrarCola()
        {
            banco.Cola.MostrarCola();
        }

        // ── Operaciones bancarias ─────────────────────────────

        public void Depositar(string cedula, double monto)
        {
            Cliente c = banco.Clientes.BuscarPorCedula(cedula);
            if (c == null)
            {
                Console.WriteLine("Cliente no encontrado.");
                return;
            }
            c.Saldo += monto;
            Transaccion t = new Transaccion("Deposito", monto, cedula);
            banco.Pila.Apilar(t);
            Console.WriteLine($"Depósito exitoso. Nuevo saldo: ${c.Saldo}");
        }

        public void Retirar(string cedula, double monto)
        {
            Cliente c = banco.Clientes.BuscarPorCedula(cedula);
            if (c == null)
            {
                Console.WriteLine("Cliente no encontrado.");
                return;
            }
            if (monto > c.Saldo)
            {
                Console.WriteLine("Saldo insuficiente.");
                return;
            }
            c.Saldo -= monto;
            Transaccion t = new Transaccion("Retiro", monto, cedula);
            banco.Pila.Apilar(t);
            Console.WriteLine($"Retiro exitoso. Nuevo saldo: ${c.Saldo}");
        }

        public void ConsultarSaldo(string cedula)
        {
            Cliente c = banco.Clientes.BuscarPorCedula(cedula);
            if (c == null)
            {
                Console.WriteLine("Cliente no encontrado.");
                return;
            }
            Console.WriteLine($"Saldo actual de {c.NombreCompleto}: ${c.Saldo}");
        }

        // ── Pila ──────────────────────────────────────────────

        public void DeshacerUltimaTransaccion()
        {
            if (banco.Pila.EstaVacia())
            {
                Console.WriteLine("No hay transacciones para deshacer.");
                return;
            }
            Transaccion t = banco.Pila.Desapilar();
            Cliente c = banco.Clientes.BuscarPorCedula(t.CedulaCliente);
            if (c == null)
            {
                Console.WriteLine("No se pudo encontrar el cliente de la transacción.");
                return;
            }
            if (t.TipoOperacion == "Deposito")
            {
                c.Saldo -= t.Monto;
                Console.WriteLine($"Se deshizo un depósito de ${t.Monto}. Saldo actual: ${c.Saldo}");
            }
            else if (t.TipoOperacion == "Retiro")
            {
                c.Saldo += t.Monto;
                Console.WriteLine($"Se deshizo un retiro de ${t.Monto}. Saldo actual: ${c.Saldo}");
            }
        }
    }
}