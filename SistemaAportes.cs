using System;
using System.Collections.Generic;
using System.Linq;

class Integrante {
    public int Id; public string Nombre, Apellido, Cedula, Departamento;
    public DateTime FechaIncorporacion; public bool EstadoActivo = true;
    public Integrante(int id, string n, string a, string c, string d, DateTime f) {
        Id = id; Nombre = n; Apellido = a; Cedula = c; Departamento = d; FechaIncorporacion = f;
    }
    public string Info() => $"ID: {Id} | {Apellido}, {Nombre} | Cédula: {Cedula}";
}

class Aporte {
    public int Id, IdIntegrante; public decimal Monto;
    public DateTime FechaAporte; public string TipoAporte;
    public Aporte(int id, int idInt, decimal m, DateTime f, string t) {
        Id = id; IdIntegrante = idInt; Monto = m; FechaAporte = f; TipoAporte = t;
    }
    public string Info() => $"Aporte #{Id}: ${Monto} - {FechaAporte:dd/MM} - {TipoAporte}";
}

class SistemaAportes {
    private List<Integrante> integrantes = new List<Integrante>();
    private List<Aporte> aportes = new List<Aporte>();
    private Dictionary<int, Integrante> dictIntegrantes = new Dictionary<int, Integrante>();
    private int contId = 1, contAporte = 1;
    
    public SistemaAportes() {
        // Datos de ejemplo
        AgregarIntegrante("Juan", "Pérez", "12345678", "Ventas", new DateTime(2023,1,15));
        AgregarIntegrante("María", "Gómez", "87654321", "Admin", new DateTime(2022,3,10));
        for(int i=1; i<=2; i++) for(int j=0; j<3; j++)
            RegistrarAporte(i, 10000 + (i*j*1000), new DateTime(2024, j+1, 15), "Mensual");
        Console.WriteLine("✅ Sistema iniciado con datos de ejemplo");
    }
    
    public void AgregarIntegrante(string n, string a, string c, string d, DateTime f) {
        var nuevo = new Integrante(contId++, n, a, c, d, f);
        integrantes.Add(nuevo); dictIntegrantes.Add(nuevo.Id, nuevo);
        Console.WriteLine($"✓ {n} {a} agregado (ID: {nuevo.Id})");
    }
    
    public void RegistrarAporte(int idInt, decimal monto, DateTime fecha, string tipo) {
        if(!dictIntegrantes.ContainsKey(idInt)) { Console.WriteLine("❌ ID no existe"); return; }
        aportes.Add(new Aporte(contAporte++, idInt, monto, fecha, tipo));
        Console.WriteLine($"✓ Aporte ${monto} registrado para ID {idInt}");
    }
    
    public void MostrarMenu() {
        Console.WriteLine("\n=== SISTEMA DE APORTES ===");
        Console.WriteLine("1. Ver integrantes");
        Console.WriteLine("2. Ver aportes");
        Console.WriteLine("3. Agregar integrante");
        Console.WriteLine("4. Registrar aporte");
        Console.WriteLine("5. Reporte general");
        Console.WriteLine("6. Salir");
        Console.Write("Opción: ");
    }
    
    public void Ejecutar() {
        while(true) {
            MostrarMenu();
            string op = Console.ReadLine();
            switch(op) {
                case "1": Console.WriteLine("\n=== INTEGRANTES ===");
                    integrantes.ForEach(i => Console.WriteLine(i.Info())); break;
                case "2": Console.WriteLine("\n=== APORTES ===");
                    aportes.ForEach(a => Console.WriteLine(a.Info()));
                    Console.WriteLine($"Total: ${aportes.Sum(a => a.Monto)}"); break;
                case "3": Console.Write("Nombre: "); string n = Console.ReadLine();
                    Console.Write("Apellido: "); string a = Console.ReadLine();
                    Console.Write("Cédula: "); string c = Console.ReadLine();
                    Console.Write("Depto: "); string d = Console.ReadLine();
                    AgregarIntegrante(n, a, c, d, DateTime.Now); break;
                case "4": Console.Write("ID Integrante: ");
                    if(int.TryParse(Console.ReadLine(), out int id)) {
                        Console.Write("Monto: ");
                        if(decimal.TryParse(Console.ReadLine(), out decimal m)) {
                            RegistrarAporte(id, m, DateTime.Now, "Mensual");
                        }
                    } break;
                case "5": Console.WriteLine($"\n=== REPORTE ===");
                    Console.WriteLine($"Integrantes: {integrantes.Count}");
                    Console.WriteLine($"Aportes: {aportes.Count}");
                    Console.WriteLine($"Total recaudado: ${aportes.Sum(a => a.Monto)}");
                    Console.WriteLine($"Aporte promedio: ${(aportes.Count>0?aportes.Average(a=>a.Monto):0)}"); break;
                case "6": Console.WriteLine("👋 ¡Hasta pronto!"); return;
                default: Console.WriteLine("❌ Opción inválida"); break;
            }
            Console.Write("\nPresione Enter para continuar...");
            Console.ReadLine();
        }
    }
}

class Program {
    static void Main() {
        Console.Title = "Sistema de Aportes";
        Console.ForegroundColor = ConsoleColor.Cyan;
        new SistemaAportes().Ejecutar();
    }
}
