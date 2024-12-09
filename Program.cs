using Models;

ProgramaEducativo programa = new ProgramaEducativo();
List<Asignatura> asignaturasGlobales = new List<Asignatura>();

// Crear asignaturas
Asignatura servidor = new Asignatura("Servidor", 6);
var cliente = new Asignatura("Cliente", 4);
Asignatura diseño = new("Diseño", 8);

// Añadir asignaturas a la lista global
asignaturasGlobales.Add(servidor);
asignaturasGlobales.Add(cliente);
asignaturasGlobales.Add(diseño);

// Crear estudiantes
var estudiante1 = new Estudiante("Vanessa Llorente");
Estudiante estudiante2 = new Estudiante("Alejandro Giménez");
var estudiante3 = new Estudiante("Laura Martínez");

// Añadir estudiantes al programa educativo
programa.AñadirEstudiante(estudiante1);
programa.AñadirEstudiante(estudiante2);
programa.AñadirEstudiante(estudiante3);

// Asignar calificaciones
estudiante1.AñadirCalificacion(servidor, 9.5);
estudiante1.AñadirCalificacion(cliente, 8.0);
estudiante1.AñadirCalificacion(diseño, 9.0);

estudiante2.AñadirCalificacion(servidor, 4.5);
estudiante2.AñadirCalificacion(cliente, 5.0);

estudiante3.AñadirCalificacion(servidor, 3.0);
estudiante3.AñadirCalificacion(cliente, 4.5);
estudiante3.AñadirCalificacion(diseño, 4.0);

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

    foreach (var asignatura in asignaturasGlobales)
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

// Añadir nuevas asignaturas
Console.WriteLine("\n--- Añadir Nueva Asignatura ---");
Console.Write("Introduce el nombre de la nueva asignatura: ");
string nuevaAsignaturaNombre = Console.ReadLine();

if (asignaturasGlobales.Exists(a => a.Nombre.Equals(nuevaAsignaturaNombre, StringComparison.OrdinalIgnoreCase)))
{
    Console.WriteLine("La asignatura ya existe.");
}
else
{
    Console.Write("Introduce la cantidad de créditos: ");
    if (int.TryParse(Console.ReadLine(), out int creditosAsignatura))
    {
        asignaturasGlobales.Add(new Asignatura(nuevaAsignaturaNombre, creditosAsignatura));
        Console.WriteLine($"Asignatura {nuevaAsignaturaNombre} añadida con éxito.");
    }
    else
    {
        Console.WriteLine("Créditos no válidos.");
    }
}

// Mostrar ranking de estudiantes basado en sus promedios
Console.WriteLine("\n--- Ranking de Estudiantes ---");
var estudiantesRanking = programa.ObtenerRankingEstudiantes();

if (estudiantesRanking.Count > 0)
{
    Console.WriteLine("Ranking de estudiantes (de mayor a menor promedio):");
    int posicion = 1;
    foreach (var estudiante in estudiantesRanking)
    {
        double promedio = estudiante.CalcularPromedio();
        Console.WriteLine($"{posicion}. {estudiante.Nombre} - Promedio: {promedio:F2}");
        posicion++;
    }
}
else
{
    Console.WriteLine("No hay estudiantes registrados para calcular el ranking.");
}

// Listar estudiantes en riesgo de reprobar
Console.WriteLine("\n--- Estudiantes en Riesgo ---");
var estudiantesEnRiesgo = programa.ObtenerEstudiantesEnRiesgo();

if (estudiantesEnRiesgo.Count > 0)
{
    Console.WriteLine("Estudiantes con promedio menor a 5:");
    foreach (var estudiante in estudiantesEnRiesgo)
    {
        double promedio = estudiante.CalcularPromedio();
        Console.WriteLine($"{estudiante.Nombre} - Promedio: {promedio:F2}");
    }
}
else
{
    Console.WriteLine("No hay estudiantes en riesgo de reprobar.");
}
