﻿using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; }= new List<string>();//Property Initializer

        static void Main(string[] args)
        {
            TaskList = new List<string>();
            int menuSelected = 0;

            /* Numbers are usually used to condition, as is our case, numbers are also usually used to perform calculations, for these scenarios the ideal is to use constants with descriptive names.
            For our code, the ideal is that we have an enumeration.  */

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
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string menuSelected = Console.ReadLine();
            return Convert.ToInt32(menuSelected);
        }

        public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                ShowMenuTaskList();

                //string taskNumberToDelete = Console.ReadLine();
                // Remove one position
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
                        Console.WriteLine($"Tarea {taskToRemove} eliminada");//String Interpolation
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ha ocurrido un error al intentar eliminar la tarea.");
            }
        }

        public static void ShowMenuAdd()
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

        public static void ShowMenuTaskList()
        {
            if (TaskList?.Count>0)//Null Conditional Operator
            {
                Console.WriteLine("----------------------------------------");
                var indexTask = 0;
                TaskList.ForEach(p => Console.WriteLine($"{++indexTask} .  {p}"));//String Interpolation

                Console.WriteLine("----------------------------------------");
            }
            else
            {
                Console.WriteLine("No hay tareas por realizar");
            }
        }
    }
    public enum Menu
    {
        Add = 1,
        Remove = 2,
        List = 3,
        Exit = 4

    }
}
