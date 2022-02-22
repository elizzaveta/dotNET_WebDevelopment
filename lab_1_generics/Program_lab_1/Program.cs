using System;
using SortedList_Library;

namespace Program_lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new MySortedList<int>();
            list.Add(1);
            list.Add(5);
            list.Add(23);
            list.Add(-41);
            list.Add(100);
            list.Add(12);
            list.Add(11);
            list.Add(2);
            list.Add(7);
            list.Add(2);
            list.Add(-1);
            list.Add(10);

            list.SortedListEvent += OutputMessage;


            Console.WriteLine("\n--------------------Sorted List initial values-------------------------");
            Console.WriteLine("-----------------------------------------------------------------------");
            ShowSortedList(list);

            Console.WriteLine("\n\n----------------------------Adding elements----------------------------");
            Console.WriteLine("-----------------------------------------------------------------------");

            Console.WriteLine(" Added '9' to SortedList:");
            list.Add(9);
            ShowSortedList(list);

            Console.WriteLine("\n\n Added '-223' to SortedList:");
            list.Add(-223);
            ShowSortedList(list);

            Console.WriteLine("\n\n Added '999' to SortedList:");
            list.Add(999);
            ShowSortedList(list);


            Console.WriteLine("\n\n--------------------------Get element by index-------------------------");
            Console.WriteLine("-----------------------------------------------------------------------");

            Console.WriteLine(" Element with index = 2:");
            Console.WriteLine(list[2]);

            Console.WriteLine("\n Element with last index:");
            Console.WriteLine(list[^1]);


            Console.WriteLine("\n\n-------------------Check if SortedList contains------------------------");
            Console.WriteLine("-----------------------------------------------------------------------");


            Console.WriteLine(" If SortedList contains '9':");
            Console.WriteLine(list.Contains(9));

            Console.WriteLine("\n If SortedList contains '-9':");
            Console.WriteLine(list.Contains(-9));

            Console.WriteLine("\n\n----------------------Get index of element-----------------------------");
            Console.WriteLine("-----------------------------------------------------------------------");

            Console.WriteLine(" Index of 9:");
            Console.WriteLine(list.IndexOf(9));


            Console.WriteLine("\n Index of -9:");
            Console.WriteLine(list.IndexOf(-9));



            Console.WriteLine("\n\n----------------------------Remove element-----------------------------");
            Console.WriteLine("-----------------------------------------------------------------------");

            Console.WriteLine("\n Remove '9' from SortedList:");
            Console.WriteLine(list.Remove(9));
            foreach (var num in list)
            {
                Console.Write(num + "  ");
            }

            Console.WriteLine("\n Remove '-9' from SortedList:");
            Console.WriteLine(list.Remove(-9));
            ShowSortedList(list);


            
            Console.WriteLine("\n\n--------------------------------Copy To--------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------");

            Console.WriteLine("\n Copy To array: 45, 1, 89, 13");
            list.CopyTo(new [] {45, 1, 89, 13});
            ShowSortedList(list);

            
            
            Console.WriteLine("\n\n-----Count of element in SortedList after calling Clear() method:------");
            Console.WriteLine("-----------------------------------------------------------------------");
            list.Clear();
            Console.WriteLine("\nSortedList Count: " + list.Count);

            

        }
        private static void OutputMessage(object e, EventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string message = $"Action: {((MySortedListEventArgs)args).Action}";
            if (((MySortedListEventArgs) args).Item != null)
                message += $"; Element: {((MySortedListEventArgs) args).Item}\n";
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void ShowSortedList<T>(MySortedList<T> list)
        {
            Console.Write("SortedList items: ");
            foreach (var num in list)
            {
                Console.Write(num + "  ");
            }
        }
    }
}