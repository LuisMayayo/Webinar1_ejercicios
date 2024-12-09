using Models;

ProgramaEducativo programa = new ProgramaEducativo();

// Crear asignaturas
Asignatura servidor = new Asignatura("Servidor", 6);
var cliente = new Asignatura("Cliente", 4);
Asignatura diseño = new("Diseño", 8);

// Crear estudiantes
var estudiante1 = new Estudiante("Vanessa Llorente");
Estudiante estudiante2 = new Estudiante("Alejandro Giménez");

// Añadir estudiantes al programa educativo
programa.AñadirEstudiante(estudiante1);
programa.AñadirEstudiante(estudiante2);

// Asignar calificaciones
estudiante1.AñadirCalificacion(servidor, 9.5);
estudiante1.AñadirCalificacion(cliente, 8.0);
estudiante1.AñadirCalificacion(diseño, 9.0);

estudiante2.AñadirCalificacion(servidor, 7.5);
estudiante2.AñadirCalificacion(cliente, 8.5);

// Mostrar estudiantes
programa.MostrarEstudiantes();

// Mostrar calificaciones de un estudiante específico
Estudiante estudianteSeleccionado = programa.ObtenerEstudiante("Vanessa Llorente");
if (estudianteSeleccionado != null)
{
    estudianteSeleccionado.MostrarCalificaciones();
    double promedio = estudianteSeleccionado.CalcularPromedio();
    Console.WriteLine($"Promedio de {estudianteSeleccionado.Nombre}: {promedio:F2}");
}

// Mostrar calificaciones del segundo estudiante
estudianteSeleccionado = programa.ObtenerEstudiante("Alejandro Giménez");
if (estudianteSeleccionado != null)
{
    estudianteSeleccionado.MostrarCalificaciones();
    double promedio = estudianteSeleccionado.CalcularPromedio();
    Console.WriteLine($"Promedio de {estudianteSeleccionado.Nombre}: {promedio:F2}");
}

// Modificar calificación de una asignatura
Console.WriteLine("\n--- Modificar Calificación ---");
Console.Write("Introduce el nombre del estudiante: ");
string nombreEstudiante = Console.ReadLine();

Estudiante estudianteParaModificar = programa.ObtenerEstudiante(nombreEstudiante);

if (estudianteParaModificar != null)
{
    Console.Write("Introduce el nombre de la asignatura: ");
    string nombreAsignatura = Console.ReadLine();

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

// Eliminar estudiante por nombre
Console.WriteLine("\n--- Eliminar Estudiante ---");
Console.Write("Introduce el nombre del estudiante que deseas eliminar: ");
string nombreEstudianteEliminar = Console.ReadLine();

programa.EliminarEstudiante(nombreEstudianteEliminar);

// Buscar estudiantes por parte del nombre
Console.WriteLine("\n--- Buscar Estudiantes ---");
Console.Write("Introduce una parte del nombre del estudiante: ");
string parteDelNombre = Console.ReadLine();

List<Estudiante> estudiantesEncontrados = programa.BuscarEstudiantesPorNombre(parteDelNombre);

if (estudiantesEncontrados.Count > 0)
{
    Console.WriteLine("\nEstudiantes encontrados:");
    foreach (var estudiante in estudiantesEncontrados)
    {
        Console.WriteLine(estudiante.Nombre);
    }
}
else
{
    Console.WriteLine("No se encontraron estudiantes con ese criterio.");
}

// Calcular promedio global de los estudiantes
Console.WriteLine("\n--- Promedio Global ---");
double promedioGlobal = programa.CalcularPromedioGlobal();
Console.WriteLine($"El promedio global del programa educativo es: {promedioGlobal:F2}");

// Generar reporte detallado de un estudiante
Console.WriteLine("\n--- Generar Reporte Detallado ---");
Console.Write("Introduce el nombre del estudiante para generar el reporte: ");
string nombreReporte = Console.ReadLine();

Estudiante estudianteReporte = programa.ObtenerEstudiante(nombreReporte);

if (estudianteReporte != null)
{
    programa.GenerarReporteEstudiante(estudianteReporte);
}
else
{
    Console.WriteLine("Estudiante no encontrado.");
}
