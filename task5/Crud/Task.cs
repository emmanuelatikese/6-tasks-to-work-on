namespace Task
{
    public class TaskData{
        public bool Complete {set; get;}
        public string Title{set; get;}
        public  string Description {set; get;}

        public TaskData(string title, string description){
            Title = title;
            Description = description;
            Complete = false;
        }

        public void PrintValues()
        {

            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Complete: {Complete}");
            Console.WriteLine("\n");
        }
    }
}