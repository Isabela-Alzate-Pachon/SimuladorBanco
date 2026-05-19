using SimuladorBanco.Logica;

namespace SimuladorBanco.UI
{
    public class Menu
    {
        private ServicioBanco servicio;

        public Menu(ServicioBanco servicio)
        {
            this.servicio = servicio;
        }

        public void Mostrar()
        {
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════╗");
                Console.WriteLine("║        SIMULADOR DE BANCO            ║");
                Console.WriteLine("╠══════════════════════════════════════╣");
                Console.WriteLine("║  1.  Registrar cliente               ║");
                Console.WriteLine("║  2.  Listar clientes                 ║");
                Console.WriteLine("║  3.  Buscar cliente                  ║");
                Console.WriteLine("║  4.  Agregar cliente a cola          ║");
                Console.WriteLine("║  5.  Atender siguiente cliente       ║");
                Console.WriteLine("║  6.  Realizar depósito               ║");
                Console.WriteLine("║  7.  Realizar retiro                 ║");
                Console.WriteLine("║  8.  Consultar saldo                 ║");
                Console.WriteLine("║  9.  Deshacer última transacción     ║");
                Console.WriteLine("║  10. Mostrar cola de atención        ║");
                Console.WriteLine("║  11. Total de clientes               ║");
                Console.WriteLine("║  12. Total de dinero del banco       ║");
                Console.WriteLine("║  13. Salir                           ║");
                Console.WriteLine("╚══════════════════════════════════════╝");
                Console.Write("\nElige una opción: ");

                string opcion = Console.ReadLine();

                Console.Clear();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("── Registrar cliente ──");
                        Console.Write("Cédula: ");
                        string cedula = Console.ReadLine();
                        Console.Write("Nombre completo: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Número de cuenta: ");
                        string cuenta = Console.ReadLine();
                        Console.Write("Saldo inicial: ");
                        double saldo;
                        while (!double.TryParse(Console.ReadLine(), out saldo) || saldo < 0)
                            Console.Write("Ingresa un saldo válido: ");
                        bool registrado = servicio.RegistrarCliente(cedula, nombre, cuenta, saldo);
                        Console.WriteLine(registrado ? "Cliente registrado exitosamente." : "Error: cédula o número de cuenta ya existe.");
                        break;

                    case "2":
                        Console.WriteLine("── Lista de clientes ──");
                        servicio.ListarClientes();
                        break;

                    case "3":
                        Console.WriteLine("── Buscar cliente ──");
                        Console.Write("Ingresa la cédula: ");
                        servicio.BuscarCliente(Console.ReadLine());
                        break;

                    case "4":
                        Console.WriteLine("── Agregar a cola de atención ──");
                        Console.Write("Ingresa la cédula del cliente: ");
                        servicio.AgregarACola(Console.ReadLine());
                        break;

                    case "5":
                        Console.WriteLine("── Atender siguiente cliente ──");
                        servicio.AtenderSiguiente();
                        break;

                    case "6":
                        Console.WriteLine("── Realizar depósito ──");
                        Console.Write("Cédula del cliente: ");
                        string cedulaDep = Console.ReadLine();
                        Console.Write("Monto a depositar: ");
                        double montoDep;
                        while (!double.TryParse(Console.ReadLine(), out montoDep) || montoDep <= 0)
                            Console.Write("Ingresa un monto válido: ");
                        servicio.Depositar(cedulaDep, montoDep);
                        break;

                    case "7":
                        Console.WriteLine("── Realizar retiro ──");
                        Console.Write("Cédula del cliente: ");
                        string cedulaRet = Console.ReadLine();
                        Console.Write("Monto a retirar: ");
                        double montoRet;
                        while (!double.TryParse(Console.ReadLine(), out montoRet) || montoRet <= 0)
                            Console.Write("Ingresa un monto válido: ");
                        servicio.Retirar(cedulaRet, montoRet);
                        break;

                    case "8":
                        Console.WriteLine("── Consultar saldo ──");
                        Console.Write("Cédula del cliente: ");
                        servicio.ConsultarSaldo(Console.ReadLine());
                        break;

                    case "9":
                        Console.WriteLine("── Deshacer última transacción ──");
                        servicio.DeshacerUltimaTransaccion();
                        break;

                    case "10":
                        Console.WriteLine("── Cola de atención ──");
                        servicio.MostrarCola();
                        break;

                    case "11":
                        Console.WriteLine("── Total de clientes ──");
                        Console.WriteLine($"Clientes registrados: {servicio.TotalClientes()}");
                        break;

                    case "12":
                        Console.WriteLine("── Total de dinero del banco ──");
                        Console.WriteLine($"Total en cuentas: ${servicio.TotalDineroBanco()}");
                        break;

                    case "13":
                        salir = true;
                        Console.WriteLine("Hasta luego!");
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intenta de nuevo.");
                        break;
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}