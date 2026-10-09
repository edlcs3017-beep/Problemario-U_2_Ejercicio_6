
Console.WriteLine("SISTEMA DE INSPECCIÓN DE PIEZAS");
Console.WriteLine("Ejercicio 6");
Console.WriteLine();

// Crear un objeto de la clase LoteInspeccion
LoteInspeccion lote1 = new LoteInspeccion();

// Inspeccionar las diez piezas
for (int i = 1; i <= 10; i++)
{
    int estado;

    do
    {
        Console.Write($"Pieza {i}: ingrese 1 si es correcta o 0 si es defectuosa: ");

        string entrada = Console.ReadLine() ?? "";

        if (!int.TryParse(entrada, out estado) ||
            (estado != 0 && estado != 1))
        {
            Console.WriteLine("Valor inválido. Ingrese únicamente 1 o 0.");
            estado = -1;
        }

    } while (estado != 0 && estado != 1);

    // Registrar el estado de la pieza
    lote1.RegistrarPieza(estado);
}

// Mostrar los resultados del lote
Console.WriteLine();
Console.WriteLine("RESULTADOS DE LA INSPECCIÓN");
Console.WriteLine($"Total de piezas inspeccionadas: {lote1.TotalPiezas}");
Console.WriteLine($"Piezas correctas: {lote1.Correctas} piezas");
Console.WriteLine($"Piezas defectuosas: {lote1.Defectuosas} piezas");
Console.WriteLine($"Porcentaje de piezas correctas: {lote1.CalcularPorcentaje():F2}%");
Console.WriteLine($"Estado del lote: {lote1.DeterminarEstadoLote()}");

// Definición de la clase
class LoteInspeccion
{
    // Propiedades
    public int TotalPiezas { get; private set; } = 10;

    public int Correctas { get; private set; } = 0;

    public int Defectuosas { get; private set; } = 0;

    // Método para registrar el estado de una pieza
    public void RegistrarPieza(int estado)
    {
        if (estado == 1)
        {
            Correctas++;
        }
        else if (estado == 0)
        {
            Defectuosas++;
        }
    }

    // Método para calcular el porcentaje de piezas correctas
    public double CalcularPorcentaje()
    {
        return (double)Correctas / TotalPiezas * 100;
    }

    // Método para determinar el estado final del lote
    public string DeterminarEstadoLote()
    {
        if (CalcularPorcentaje() >= 90)
        {
            return "ACEPTADO";
        }
        else
        {
            return "RECHAZADO";
        }
    }
}
