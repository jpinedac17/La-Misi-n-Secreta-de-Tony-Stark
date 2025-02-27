using System.IO;
using System.Net.Mime;

// Crear el archivo
void CrearArchivo() {
    string ruta = @"C:\Users\Jeiner\Desktop\LaboratorioAvengers";
    string archivo = Path.Combine(ruta, "inventos.txt");

    // Evaluar si la ruta existe
    if (!Directory.Exists(ruta)) {
        Console.WriteLine($"Error: la ruta {ruta} no existe");
        return;
    }

    // Evaluar si el archivo existe
    if (!File.Exists(archivo)) {
        File.WriteAllText(archivo, "LISTA DE INVENTOS:");
        Console.WriteLine($"Archivo creado: {archivo}");
    }
}

// Agregar inventos al archivo
string AgregarInvento(string invento) {
    string ruta = @"C:\Users\Jeiner\Desktop\LaboratorioAvengers\inventos.txt";
    string contenido = File.ReadAllText(ruta);
    string inventoNuevo = invento;

    if (!File.Exists(ruta)) {
        Console.WriteLine("El archivo 'inventos.txt no existe. ¡Ultron debe haberlo borrado!'");
    } else {
        // Verificar si existe un salto de línea al final, sino agregarlo
        if (!contenido.EndsWith("\n")) {
            File.AppendAllText(ruta, Environment.NewLine);
        }

        // Agregar nuevo invento
        using (StreamWriter writer = new StreamWriter(ruta, true)) {
            writer.WriteLine(inventoNuevo);
        }
    }
    return invento;  
}

// Leer el archivo
void LeerArchivo() {
    string ruta = @"C:\Users\Jeiner\Desktop\LaboratorioAvengers\inventos.txt";

    if (!File.Exists(ruta)) {
        Console.WriteLine("El archivo 'inventos.txt no existe. ¡Ultron debe haberlo borrado!'");
    } else {
        using (StreamReader reader = new StreamReader(ruta)) {
        string contenido = reader.ReadToEnd();
        Console.WriteLine(contenido);
    }
    }
}

// Leer todo el archivo (con otro metodo)
void LeerArchivoCompleto() {
    string ruta = @"C:\Users\Jeiner\Desktop\LaboratorioAvengers\inventos.txt";
    string contenido = File.ReadAllText(ruta);

    if (!File.Exists(ruta)) {
        Console.WriteLine("El archivo 'inventos.txt' no existe. ¡Ultron debe haberlo borrado!'");
    } else {
        Console.WriteLine(contenido);
    }
}
/* LeerArchivoCompleto(); */


// OPERACIONES CON LA CLASE FILE
// Copiar inventos.txt a Backup
void CopiarArchivo() {
    string archivo = @"C:\Users\Jeiner\Desktop\LaboratorioAvengers\inventos.txt";
    string carpetaBackup = @"C:\Users\Jeiner\Desktop\LaboratorioAvengers\Backup";
    string destinoArchivo = Path.Combine(carpetaBackup, Path.GetFileName(archivo));

    if (!Directory.Exists(carpetaBackup)) {
        Directory.CreateDirectory(carpetaBackup);
    } 

    if (!File.Exists(archivo)) {
        Console.WriteLine("El archivo 'inventos.txt' no existe. ¡Ultron debe haberlo borrado!'");
    } else {
        File.Copy(archivo, destinoArchivo, true);
        Console.WriteLine("Archivo 'inventos.txt' copiado correctamente a 'Backup'");
    }
}

// Mover inventos.txt a ArchivosClasificados
void MoverArchivo() {
    string archivo = @"C:\Users\Jeiner\Desktop\LaboratorioAvengers\inventos.txt";
    string carpetaArchivosClasificados = @"C:\Users\Jeiner\Desktop\LaboratorioAvengers\ArchivosClasificados";
    string destinoArchivo = Path.Combine(carpetaArchivosClasificados, Path.GetFileName(archivo));

    if (!Directory.Exists(carpetaArchivosClasificados)) {
        Directory.CreateDirectory(carpetaArchivosClasificados);
    } 

    if (!File.Exists(archivo)) {
        Console.WriteLine("El archivo 'inventos.txt' no existe. ¡Ultron debe haberlo borrado!'");
    } else {
        File.Move(archivo, destinoArchivo);
        Console.WriteLine("Archivo 'inventos.txt' movido correctamente a 'ArchivosClasificados'");
    }
}

// Crear carpeta ProyectosSecretos
void CrearCarpeta() {
    string proyectosSecretos = @"C:\Users\Jeiner\Desktop\LaboratorioAvengers\ProyectosSecretos";

    if (!Directory.Exists(proyectosSecretos)) {
        Directory.CreateDirectory(proyectosSecretos);
        Console.WriteLine("Carpeta 'ProyectosSecretos' creada exitosamente");
    } else {
        Console.WriteLine("La carpeta 'ProyectosSecretos' ya existe");
    }
}

// Eliminar archivo inventos.txt
void EliminarArchivo() {
    string archivo = @"C:\Users\Jeiner\Desktop\LaboratorioAvengers\inventos.txt";
    string copiaSeguridad = @"C:\Users\Jeiner\Desktop\LaboratorioAvengers\Backup\inventos.txt";
    string carpetaBackup = @"C:\Users\Jeiner\Desktop\LaboratorioAvengers\Backup";
    string destinoArchivo = Path.Combine(carpetaBackup, Path.GetFileName(archivo));

    if (!Directory.Exists(carpetaBackup)) {
        Directory.CreateDirectory(carpetaBackup);
    }

    if (!File.Exists(archivo)) {
        Console.WriteLine("El archivo 'inventos.txt no existe. ¡Ultron debe haberlo borrado!'");
    } else if (!File.Exists(copiaSeguridad)) {
        // Si la copia de seguridad no existe, se crea
        File.Copy(archivo, destinoArchivo, true);
        File.Delete(archivo);

        Console.WriteLine("Copia de seguridad de 'inventos.txt' creada con éxito en 'Backup'");
        Console.WriteLine("Archivo 'inventos.txt' eliminado con éxito");
    } else {
        File.Delete(archivo);
        Console.WriteLine("Archivo 'inventos.txt' eliminado con éxito");
    }
}

// Listar archivos de LaboratorioAvengers 
void ListarArchivos() {
    string carpeta = @"C:\Users\Jeiner\Desktop\LaboratorioAvengers";
    string[] elementos = Directory.GetFileSystemEntries(carpeta);
    int contador = 0;

    if (Directory.Exists(carpeta)) {
        Console.WriteLine("Archivos dentro de la carpeta:\n");
        foreach (string elemento in elementos) {
            string element = Path.GetFileName(elemento);
            contador++;

            Console.WriteLine($"- {element}");
        }
    } else {
        Console.WriteLine("La carpeta 'LaboratorioAvengers' no existe");
    }
}

// Menú para el usuario
void Menu() {
    Console.WriteLine("\nElige la opción que deseas realizar:\n");
    Console.WriteLine("1. Crear archivo 'inventos.txt'");
    Console.WriteLine("2. Agrega un nuevo invento al archivo");
    Console.WriteLine("3. Leer el archivo 'inventos.txt línea por línea");
    Console.WriteLine("4. Leer todo el texto del archivo 'inventos.txt'");
    Console.WriteLine("5. Copiar 'inventos.txt' a la carpeta 'Backup'");
    Console.WriteLine("6. Mover 'inventos.txt' a la carpeta 'ArchivosClasificados'");
    Console.WriteLine("7. Crear carpeta 'ProyectosSecretos'");
    Console.WriteLine("8. Eliminar el archivo 'inventos.txt'");
    Console.WriteLine("9. Listar todos los archivos dentro de 'LaboratorioAvengers'");
}

int opcion = -1;
while (opcion != 0) {
    Menu();
    opcion = int.Parse(Console.ReadLine());

    switch(opcion) {
    case 1:
        string archivo = @"C:\Users\Jeiner\Desktop\LaboratorioAvengers\inventos.txt";

        if (File.Exists(archivo)) {
            Console.WriteLine("El archivo 'inventos.txt' ya existe");
        } else {
            CrearArchivo();
        }
        break;
    case 2:
        Console.WriteLine("Agrega un nuevo invento: ");
        string nuevoInvento = Console.ReadLine();
        AgregarInvento(nuevoInvento);
        Console.WriteLine("Nuevo invento agregado correctamente");
        break;
    case 3:
        LeerArchivo();
        break;
    case 4:
        LeerArchivoCompleto();
        break;
    case 5:
        CopiarArchivo();
        break;
    case 6:
        MoverArchivo();
        break;
    case 7:
        CrearCarpeta();
        break;
    case 8:
        EliminarArchivo();
        break;
    case 9:
        ListarArchivos();
        break;
    default:
        Console.Write("\nOpcion no valida\n");
    break;
    }
}