using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Task;

class Program{
    private Dictionary<string, TaskData> TaskList = new Dictionary<string, TaskData>();

    public void WriteJson(Dictionary<string, TaskData> Data)
    {
        string strJson = JsonConvert.SerializeObject(Data, Formatting.Indented);
        File.WriteAllText("storage.json", strJson);
    }

    public Dictionary<string, TaskData> ReadJson(Dictionary<string, TaskData> Data)
    {
        string strJson = File.ReadAllText("storage.json");
        var dict = JsonConvert.DeserializeObject<Dictionary<string, TaskData>>(strJson);
        return dict;
    }

     Program()
    {
        if (File.Exists("storage.json")){
            TaskList = ReadJson(TaskList);
        }
        else
        {
            WriteJson(TaskList);
        }
    }
    public bool Create(TaskData Data){
        try {
            Guid uuid = Guid.NewGuid();
            TaskList.Add(uuid.ToString(), Data);
            WriteJson(TaskList);
            return true;
        }
        catch (Exception ex){
            Console.WriteLine(ex);
            return false;
        }
    }


    public bool UpdateOne(Dictionary<string, string>  Data, string Id) {
        if (TaskList.TryGetValue(Id, out TaskData task)) {
            if (Data.TryGetValue("title", out string title)) { 
                task.Title = title;
            }
            if (Data.TryGetValue("description", out string description)) { 
                task.Description = description;
            }
            if (Data.TryGetValue("complete", out string complete))
            {
                if (complete.ToLower() == "yes" || complete.ToLower() == "y"){
                    task.Complete = true;
                } else{
                    task.Complete = false;
                }
            }
            WriteJson(TaskList);
            return true;
        }
        else
        {
            Console.WriteLine("User don't exist!!!");
        }
        return false;
    }

    public void DeleteOne(string Id)
    {
        try
        {
            if (TaskList.Count() != 0)
            {
                var remove = TaskList.Remove(Id);

                if (remove != null)
                {
                    Console.WriteLine("Task don't exist");
                }
                WriteJson(TaskList);
            }
            else{
                Console.WriteLine("No Task available");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }



    public void FindAllTask()
    {
        if (TaskList.Count == 0)
        {
            Console.WriteLine("No Task available");
        } else
        {
            foreach(var x in TaskList)
            {
                Console.WriteLine($"Id: {x.Key}");
                x.Value.PrintValues();
            }
        }
    }

    public void FindOne(string Id) {
        if (TaskList.Count() == 0)
        {
            Console.WriteLine("No Task available");
        }
        else if (TaskList.TryGetValue(Id, out TaskData task))
        {
            task.PrintValues();
        } else
        {
            Console.WriteLine("Task don't exist");
        }
    }
    static void Main(){
        Program prog = new Program();
        
        Console.WriteLine("Welcome to Simple Task App");
        string userResponse = "";
        while (userResponse == "")
        {
            Console.Write("List of options\n1.View All Task \n2.View a Task \n3.Create Task \n4.Update a Task \n5.Delete a Task \n6.Exit\n");
            Console.Write("Enter an option(1-6):");
            userResponse = Console.ReadLine();
            Console.WriteLine("-------------------------------------------------");

            try
                 {
                int parseResponse = int.Parse(userResponse);
                switch (parseResponse)
                {
                    case 1:
                        Console.WriteLine("\n");
                        Console.WriteLine("FindAll Tasks");
                        prog.FindAllTask();
                        userResponse = "";
                        Console.WriteLine("-------------------------------------------------");
                        Console.WriteLine("\n");
                        Console.WriteLine("Welcome back !!!");
                        break;

                    case 2:
                        Console.WriteLine("\n");
                        Console.WriteLine("Find Task");
                        string resId = "";
                        while (resId == "")
                        {
                            Console.Write("Enter Id of choice:");
                            resId = Console.ReadLine();
                            if (resId == "")
                            {
                                Console.Write("Id can't be empty !!!");
                            }
                        }
                        prog.FindOne(resId);
                        Console.WriteLine("-------------------------------------------------");
                        Console.WriteLine("\n");
                        Console.WriteLine("Welcome back !!!");
                        userResponse = "";
                        break;
                    case 3:
                        Console.WriteLine("\n");
                        Console.WriteLine("Create Task");
                        string resTitle = "";
                        while (resTitle == "")
                        {
                            Console.Write("Title: ");
                            resTitle = Console.ReadLine();
                            if (resTitle == "")
                            {
                                Console.WriteLine("Title can't be empty !!!");
                            }
                        }
                        Console.Write("Description: ");
                        string resDescription = Console.ReadLine();
                        TaskData resTask = new TaskData(resTitle, resDescription);
                        // resTask.Title = resTitle;
                        // resTask.Description = resDescription;
                        bool ans = prog.Create(resTask);
                        if (ans)
                        {
                            resTask.PrintValues();
                            Console.WriteLine("Task Created successfully ... ");
                            Console.WriteLine("-------------------------------------------------");
                            userResponse = "";
                            Console.WriteLine("\n");
                            Console.WriteLine("Welcome back !!!");
                        }
                        break;
                    case 4:
                        Dictionary<string, string> updateList = new Dictionary<string, string>();
                        Console.WriteLine("\n");
                        Console.WriteLine("Update a Task");
                        Console.Write("TaskId: ");
                        string updateId = Console.ReadLine();
                        Console.WriteLine("\n");
                        string titleUpdate = "", desUpdate = "", completeUpdate = "";

                        while (titleUpdate == "")
                        {
                            Console.Write("Title: ");
                            titleUpdate = Console.ReadLine();
                            if (titleUpdate == "")
                            {
                                Console.WriteLine("Title can't be empty !!!");
                            }
                            else
                            {
                                updateList.Add("title", titleUpdate);
                            }
                        }
                        Console.Write("Description: ");
                        desUpdate = Console.ReadLine();
                        Console.WriteLine("\n");


                        if (desUpdate != "")
                        {
                            updateList.Add("description", desUpdate);
                        }

                        Console.Write("Complete (yes/y) / (no/ n)/ '': ");
                        completeUpdate = Console.ReadLine();
                        if (completeUpdate != "")
                        {
                            string[] validStr = { "yes", "y", "n", "no", ""};
                            while (!(validStr.Contains(completeUpdate)))
                            {


                                if (!(validStr.Contains(completeUpdate)))
                                {
                                    Console.WriteLine("you have to select within these options:(yes/y) / (no/ n)/ ''");
                                    Console.Write("Complete (yes/y) / (no/ n)/ '': ");
                                    completeUpdate = Console.ReadLine();
                                }
                            }
                            updateList.Add("complete", completeUpdate);
                        }

                        bool resUpdate = prog.UpdateOne(updateList, updateId);
                        if (resUpdate)
                        {
                            Console.WriteLine("Update done successfully ...");
                            Console.WriteLine("-------------------------------------------------");
                            Console.WriteLine("\n");
                            Console.WriteLine("Welcome back !!!");
                            userResponse = "";
                        }
                        Console.WriteLine("\n");
                        break;

                    case 5:
                        Console.WriteLine("\n");
                        Console.WriteLine("Delete a Task");
                        Console.Write("TaskId: ");
                        string delId = Console.ReadLine();
                        Console.WriteLine("\n");
                        prog.DeleteOne(delId);
                        Console.WriteLine("\n");
                        Console.WriteLine("Task deleted successfully");
                        Console.WriteLine("-------------------------------------------------");
                        userResponse = "";
                        Console.WriteLine("\n");
                        Console.WriteLine("Welcome back !!!");
                        break;
                    case 6:
                        Console.WriteLine("\n");
                        Console.WriteLine("Bye !!!");
                        break;
                }
            }
            catch (FormatException ex)
            {
                userResponse = "";
                Console.WriteLine("\n");
                Console.WriteLine($"You have to type from (1 - 10) to choose from these options !!!");
                Console.WriteLine("\n");
            }

        }
    }
}