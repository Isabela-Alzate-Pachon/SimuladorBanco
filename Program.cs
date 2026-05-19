using SimuladorBanco.Logica;
using SimuladorBanco.UI;

Banco banco = new Banco("Banco Central");
ServicioBanco servicio = new ServicioBanco(banco);
Menu menu = new Menu(servicio);

menu.Mostrar();

