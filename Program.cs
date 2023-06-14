// See https://aka.ms/new-console-template for more information
namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            showMenu();




           
        }







        static List<Task> tasks = new List<Task>();

        static void showMenu()
        {
            Console.Clear();
            int UserAuswahl = 0; 
            
            Console.WriteLine("Hallo, was möchten Sie tun?");
            Console.WriteLine("1. Neuen Task erstellen. \n2. Taskliste anzeigen. \n3. Taskstatus ändern. \n0. Exit.");
            try
            {
                UserAuswahl = Int32.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Ungültige Eingabe");
                Console.WriteLine(e.Message);
                Console.ReadKey();
                showMenu();
            }

            switch (UserAuswahl)
            {
                case 1:
                    addTask();
                    break;

                 case 2:
                    showTaskList();
                    break;

                case 3:
                    changeTaskState();
                    break;

                case 0:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Wählen Sie eine andere Eingabe.");
                    showMenu();
                    break;
            }

        }

        static void addTask()
        {
            string newTaskName;
            string newTaskDescription;
            
            Console.Clear();
            Console.WriteLine("Wie soll der neue Task heißen?");
            newTaskName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newTaskName))
            {
                Console.WriteLine("\nGeben Sie in Stichpunkten eine kurze Beschreibung ein:");
                newTaskDescription = Console.ReadLine();
                if (!string.IsNullOrEmpty(newTaskDescription))
                {
                    Task task = new Task(newTaskName, newTaskDescription);
                    try
                    {
                        tasks.Add(task);
                        Console.WriteLine("Ihr neuer Task " + newTaskName + " wurde erfolgreich erstellt.");
                        Thread.Sleep(3000);
                        showMenu();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Ihr Task konnte nicht erstellt werden.");
                        Console.WriteLine(e.Message);
                        Console.Clear();
                        showMenu();
                    }
                }
                else
                {
                    Console.WriteLine("Geben Sie eine gültige Beschreibung ein. \nOK?");
                    Console.ReadKey();
                    addTask();
                }
            }
            else
            {
                Console.WriteLine("Geben Sie einen gültigen Namen ein. \nOK?");
                Console.ReadKey();
                addTask();
            }
        }

        static void showTaskList()
        {
            Console.Clear();
            Console.WriteLine("Ihre aktuellen Tasks: \n");
            if (tasks.Count > 0)
            {
                for (int i = 0; i < tasks.Count - 1; i++)
                {
                    if (tasks[i].IsCompleted)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine((i + 1) + ". " + tasks[i].Name + " | " + tasks[i].Description + " | " + tasks[i].IsCompleted);
                    }
                    else
                    {
                        Console.WriteLine((i + 1) + ". " + tasks[i].Name + " | " + tasks[i].Description + " | " + tasks[i].IsCompleted);
                    }
                }
            }
            else
            {
                Console.WriteLine("Sie haben keine Tasks.");
                Thread.Sleep(3000);
                showMenu();
            }

            Console.WriteLine("Drücken Sie eine Tasten um zum Hauptmenü zu gelangen.");
            Console.ReadLine();
            showMenu();       
        }

        static void changeTaskState()
        {
            // Mit der Listennummer kann ein Task auf "Checked" oder "To-do" stehen (Farbliche ausgabe)
            Console.WriteLine("Test");
        }
    }

    class Task
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public Task(string newName, string newDescription) 
        {
            Name = newName;
            Description = newDescription;
            IsCompleted = false;
        }
    }
}



