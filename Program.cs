// Modificar calificación de una asignatura
Console.WriteLine("\n--- Modificar Calificación ---");

// Selecciona el estudiante
Console.Write("Introduce el nombre del estudiante: ");
string nombreEstudiante = Console.ReadLine();

Estudiante estudianteParaModificar = programa.ObtenerEstudiante(nombreEstudiante);

if (estudianteParaModificar != null)
{
    // Selecciona la asignatura
    Console.Write("Introduce el nombre de la asignatura: ");
    string nombreAsignatura = Console.ReadLine();

    // Busca la asignatura por nombre
    Asignatura asignaturaParaModificar = null;
    List<Asignatura> asignaturas = new List<Asignatura> { servidor, cliente, diseño };

    foreach (var asignatura in asignaturas)
    {
        if (asignatura.Nombre.Equals(nombreAsignatura, StringComparison.OrdinalIgnoreCase))
        {
            asignaturaParaModificar = asignatura;
            break;
        }
    }

    if (asignaturaParaModificar != null)
    {
        // Pide la nueva calificación
        Console.Write("Introduce la nueva calificación: ");
        if (double.TryParse(Console.ReadLine(), out double nuevaCalificacion))
        {
            estudianteParaModificar.ModificarCalificacion(asignaturaParaModificar, nuevaCalificacion);
        }
        else
        {
            Console.WriteLine("Calificación no válida.");
        }
    }
    else
    {
        Console.WriteLine("Asignatura no encontrada.");
    }
}
else
{
    Console.WriteLine("Estudiante no encontrado.");
}
