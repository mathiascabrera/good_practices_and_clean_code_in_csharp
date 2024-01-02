List<string> TaskList = new List<string>();

TaskList = new List<string>();
int menuSelected = 0;

do
{
    menuSelected = ShowMainMenu();

    if ((Menu)menuSelected == Menu.Add)
    {
        ShowMenuAdd();
    }
    else if ((Menu)menuSelected == Menu.Remove)
    {
        ShowMenuRemove();
    }
    else if ((Menu)menuSelected == Menu.List)
    {
        ShowMenuTaskList();
    }
} while ((Menu)menuSelected != Menu.Exit);

int ShowMainMenu()
{
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Ingrese la opción a realizar: ");
    Console.WriteLine("1. Nueva tarea");
    Console.WriteLine("2. Remover tarea");
    Console.WriteLine("3. Tareas pendientes");
    Console.WriteLine("4. Salir");

    string menuSelected = Console.ReadLine();
    return Convert.ToInt32(menuSelected);
}

void ShowMenuRemove()
{
    try
    {
        Console.WriteLine("Ingrese el número de la tarea a remover: ");
        ShowMenuTaskList();

        // Remove one position because the array starts in 0
        int indexToRemove = Convert.ToInt32(Console.ReadLine()) - 1;

        if (indexToRemove > (TaskList.Count - 1) || indexToRemove < 0)
        {
            Console.WriteLine("El número de tarea ingresado no es válido.");
        }
        else
        {
            if (indexToRemove > -1 && TaskList.Count > 0)
            {
                string taskToRemove = TaskList[indexToRemove];
                TaskList.RemoveAt(indexToRemove);
                Console.WriteLine($"Tarea {taskToRemove} eliminada");
            }
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Ha ocurrido un error al intentar eliminar la tarea.");
    }
}

void ShowMenuAdd()
{
    try
    {
        Console.WriteLine("Ingrese el nombre de la tarea: ");
        string newTask = Console.ReadLine();

        if (string.IsNullOrEmpty(newTask))
        {
            Console.WriteLine("No se ha ingresado ningún nombre.");
        }
        else
        {
            TaskList.Add(newTask);
            Console.WriteLine("Tarea registrada");
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Ha ocurrido un error al intentar ingresar la tarea.");
    }
}

void ShowMenuTaskList()
{
    if (TaskList?.Count > 0)
    {
        Console.WriteLine("----------------------------------------");
        var indexTask = 0;
        TaskList.ForEach(p => Console.WriteLine($"{++indexTask} .  {p}"));

        Console.WriteLine("----------------------------------------");
    }
    else
    {
        Console.WriteLine("No hay tareas por realizar");
    }
}
enum Menu
{
    Add = 1,
    Remove = 2,
    List = 3,
    Exit = 4

}
