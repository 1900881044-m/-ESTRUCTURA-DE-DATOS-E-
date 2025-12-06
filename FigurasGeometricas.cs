
using System;

namespace FigurasGeometricas
{
    // Clase para representar un Círculo
    public class Circulo
    {
        // Atributos privados para encapsular los datos
        private double radio;
        
        // Constructor que inicializa el radio del círculo
        public Circulo(double radio)
        {
            // Validamos que el radio no sea negativo
            if (radio < 0)
            {
                throw new ArgumentException("El radio no puede ser negativo");
            }
            this.radio = radio;
        }
        
        // Propiedad para acceder y modificar el radio de manera controlada
        public double Radio
        {
            get { return radio; }
            set 
            { 
                if (value < 0)
                    throw new ArgumentException("El radio no puede ser negativo");
                radio = value; 
            }
        }
        
        // Método para calcular el área del círculo
        // Fórmula: π * radio²
        public double CalcularArea()
        {
            return Math.PI * radio * radio;
        }
        
        // Método para calcular el perímetro (circunferencia) del círculo
        // Fórmula: 2 * π * radio
        public double CalcularPerimetro()
        {
            return 2 * Math.PI * radio;
        }
        
        // Método para mostrar información del círculo
        public void MostrarInformacion()
        {
            Console.WriteLine("=== Información del Círculo ===");
            Console.WriteLine($"Radio: {radio}");
            Console.WriteLine($"Área: {CalcularArea():F2}");
            Console.WriteLine($"Perímetro: {CalcularPerimetro():F2}");
        }
    }
    
    // Clase para representar un Rectángulo
    public class Rectangulo
    {
        // Atributos privados para encapsular los datos
        private double baseRectangulo;
        private double altura;
        
        // Constructor que inicializa la base y la altura del rectángulo
        public Rectangulo(double baseRectangulo, double altura)
        {
            // Validamos que las dimensiones no sean negativas
            if (baseRectangulo < 0 || altura < 0)
            {
                throw new ArgumentException("Las dimensiones no pueden ser negativas");
            }
            this.baseRectangulo = baseRectangulo;
            this.altura = altura;
        }
        
        // Propiedad para acceder y modificar la base
        public double Base
        {
            get { return baseRectangulo; }
            set 
            { 
                if (value < 0)
                    throw new ArgumentException("La base no puede ser negativa");
                baseRectangulo = value; 
            }
        }
        
        // Propiedad para acceder y modificar la altura
        public double Altura
        {
            get { return altura; }
            set 
            { 
                if (value < 0)
                    throw new ArgumentException("La altura no puede ser negativa");
                altura = value; 
            }
        }
        
        // Método para calcular el área del rectángulo
        // Fórmula: base * altura
        public double CalcularArea()
        {
            return baseRectangulo * altura;
        }
        
        // Método para calcular el perímetro del rectángulo
        // Fórmula: 2 * (base + altura)
        public double CalcularPerimetro()
        {
            return 2 * (baseRectangulo + altura);
        }
        
        // Método para mostrar información del rectángulo
        public void MostrarInformacion()
        {
            Console.WriteLine("=== Información del Rectángulo ===");
            Console.WriteLine($"Base: {baseRectangulo}");
            Console.WriteLine($"Altura: {altura}");
            Console.WriteLine($"Área: {CalcularArea():F2}");
            Console.WriteLine($"Perímetro: {CalcularPerimetro():F2}");
        }
    }
    
    // Clase principal para probar las figuras geométricas
    public class ProgramaPrincipal
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Programa de Figuras Geométricas ===\n");
            
            try
            {
                // Crear un círculo con radio 5
                Console.WriteLine("1. Probando la clase Círculo:");
                Circulo miCirculo = new Circulo(5.0);
                miCirculo.MostrarInformacion();
                
                Console.WriteLine("\n" + new string('-', 50) + "\n");
                
                // Crear un rectángulo con base 4 y altura 6
                Console.WriteLine("2. Probando la clase Rectángulo:");
                Rectangulo miRectangulo = new Rectangulo(4.0, 6.0);
                miRectangulo.MostrarInformacion();
                
                Console.WriteLine("\n" + new string('-', 50) + "\n");
                
                // Demostrar modificación de propiedades
                Console.WriteLine("3. Modificando propiedades:");
                miCirculo.Radio = 7.5;
                Console.WriteLine($"Nuevo radio del círculo: {miCirculo.Radio}");
                Console.WriteLine($"Nueva área: {miCirculo.CalcularArea():F2}");
                
                miRectangulo.Base = 8.0;
                miRectangulo.Altura = 3.0;
                Console.WriteLine($"\nNuevas dimensiones del rectángulo:");
                Console.WriteLine($"Base: {miRectangulo.Base}, Altura: {miRectangulo.Altura}");
                Console.WriteLine($"Nueva área: {miRectangulo.CalcularArea():F2}");
                
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            
            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
