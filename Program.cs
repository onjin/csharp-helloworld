using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {

            // Date/Time handling
            PrintHeader("Date / Time handling");
            DateTime myValue = DateTime.Now;
            Console.WriteLine(myValue.ToShortDateString());
            Console.WriteLine(myValue.ToShortTimeString());
            Console.WriteLine(myValue.ToLongDateString());
            Console.WriteLine(myValue.ToLongTimeString());
            Console.WriteLine(myValue.ToString());

            Console.WriteLine(myValue.AddDays(3));
            Console.WriteLine(myValue.AddDays(-3));
            Console.WriteLine(myValue.Month);

            DateTime myBirthday = new DateTime(1976, 8, 3);
            Console.WriteLine(myBirthday);

            DateTime someDate = DateTime.Parse("1976/7/3");
            Console.WriteLine(someDate);

            TimeSpan myAge = DateTime.Now.Subtract(myBirthday);
            Console.WriteLine(myAge.TotalDays);
            Console.WriteLine(@" goto c:\ drive");

            // StringBuilder - example usage
            PrintHeader("StringBuilder example usage");
            StringBuilder myString = new StringBuilder();
            myString.Append("appendend string");
            myString.Append("appendend second string");
            Console.WriteLine("StringBuilder myString = {0}", myString);

            // Simple object initialize
            PrintHeader("Simple objects creation");
            Car c1 = new Car();
            c1.VIN = "vin1";
            c1.Model = "some model";
            Console.WriteLine(c1);

            // Simple object initialize
            Car c2 = new Car();
            c2.VIN = "vin2";
            c2.Model = "some model";
            Console.WriteLine(c2);

            // Simple object initialize
            Book b1 = new Book();
            b1.Author = "Author";
            b1.Title = "some title";

            // ArrayList - any type list
            PrintHeader("ArrayList example");
            ArrayList myArrayList = new ArrayList();
            myArrayList.Add(c1);
            myArrayList.Add(c2);
            myArrayList.Add(b1);

            // List<T> - list restricted to given type
            PrintHeader("List<T> example");
            List<Car> carList = new List<Car>();
            carList.Add(c1);
            carList.Add(c2);
            // carList.Add(b1);

            // Dictionary<TKey, TValue> - given type key and value
            PrintHeader("Dictionary<TKey, TValue> example");
            Dictionary<string, Car> myDictionary = new Dictionary<string, Car>();
            myDictionary.Add(c1.VIN, c1);
            myDictionary.Add(c2.VIN, c2);

            Console.WriteLine(myDictionary[c2.VIN]);

            // list initializer
            string[] names = {"bob", "steve"};


            // object initializer
            Car c3 = new Car() { VIN = "vin3", Model = "other model"};
            Console.WriteLine(c3);

            Car c4 = new Car() { VIN = "vin4", Model = "other model"};
            Console.WriteLine(c4);

            // collection initializer
            List<Car> carsList = new List<Car>() {
                new Car() { VIN = "vin1", Model = "BMW", Year=2010},
                new Car() { VIN = "vin2", Model = "model 2", Year=2013},
                new Car() { VIN = "vin3", Model = "Skoda", Year=2012},
                new Car() { VIN = "vin4", Model = "model 4", Year=2015},
                new Car() { VIN = "vin5", Model = "BMW", Year=2012},
                new Car() { VIN = "vin6", Model = "model 6", Year=2011},
            };
            Console.WriteLine(carsList.ToString());
            Console.WriteLine(carsList[0]);
            Console.WriteLine(carsList[1]);


            // LINQ query
            Console.WriteLine("running LINQ");
            var bmws  = from car in carsList
                where car.Model== "BMW"
                && car.Year == 2010
                select car;
            
            Console.WriteLine("running LINQ query {0}", bmws);
            foreach (var car in bmws)
            {
                Console.WriteLine("{0} {1} from {2}", car.Model, car.VIN, car.Year);
            }

            // LINQ method
            var bmws2 = carsList.Where(p => p.Make == "BMW" && p.Year == 2010);
            
            Console.WriteLine("running LINQ method {0}", bmws2);
            foreach (var car in bmws2)
            {
                Console.WriteLine("{0} {1} from {2}", car.Model, car.VIN, car.Year);
            }

            var orderedCars = from car in carsList
                orderby car.Year descending
                select car;

            Console.WriteLine("running LINQ query {0}", orderedCars);
            foreach (var car in orderedCars)
            {
                Console.WriteLine("{0} {1} from {2}", car.Model, car.VIN, car.Year);
            }

            var orderedCarsMethod = carsList.OrderByDescending(p => p.Year);
            Console.WriteLine("running LINQ method {0}", orderedCarsMethod);
            foreach (var car in orderedCarsMethod)
            {
                Console.WriteLine("{0} {1} from {2}", car.Model, car.VIN, car.Year);
            }

            // enums usage
            List<Todo> todos = new List<Todo>()
            {
                new Todo { Description = "task 1", EstimatedHours = 5, Status = Status.InProgress},
                new Todo { Description = "task 2", EstimatedHours = 1, Status = Status.InProgress},
                new Todo { Description = "task 3", EstimatedHours = 2, Status = Status.OnHold},
                new Todo { Description = "task 4", EstimatedHours = 5, Status = Status.NotStarted},
                new Todo { Description = "task 5", EstimatedHours = 6, Status = Status.InProgress},
                new Todo { Description = "task 6", EstimatedHours = 3, Status = Status.Deleted},
            };

            // switch example usage
            foreach (Todo item in todos)
            {
                switch (item.Status)
                {
                    case Status.Deleted :
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;

                    case Status.InProgress:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;

                    case Status.OnHold:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                
                    default:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                Console.WriteLine(item);
            }
            Console.ForegroundColor = ConsoleColor.White;


            // handling exceptions
            try {
                string content = File.ReadAllText(@"./example.txt");
                Console.WriteLine(content);
            }
            catch (FileNotFoundException exc)
            {
                Console.WriteLine("File not found {0}", exc.Message);
            }
            catch (UnauthorizedAccessException exc)
            {
                Console.WriteLine("Cannot access file {0}", exc.Message);
            }

            // Timer example
            TimerExample();
        }

        private static void PrintHeader(string header)
        {
            ConsoleColor currentBackground = Console.BackgroundColor;
            ConsoleColor currentForeground = Console.ForegroundColor;

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine("=== {0} ===", header);

            Console.BackgroundColor =  currentBackground;
            Console.ForegroundColor = currentForeground;
        }

        private static void TimerExample()
        {
            Timer myTimer = new Timer(2000);
            myTimer.Elapsed += MyTimer_Elapsed0;
            myTimer.Elapsed += MyTimer_Elapsed1;
            myTimer.Start();

            Console.WriteLine("Press <enter> to remove Elapsed1 handler");
            Console.ReadLine();

            myTimer.Elapsed -= MyTimer_Elapsed1;

            Console.WriteLine("Press <enter> to remove go on with examples");
            Console.ReadLine();

        }

        private static void MyTimer_Elapsed0(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Elapsed0: {0:HH:mm:ss.fff}", e.SignalTime);
        }

        private static void MyTimer_Elapsed1(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Elapsed1: {0:HH:mm:ss.fff}", e.SignalTime);
        }

    }


    class Todo
    {
        public string Description { get; set; }
        public int EstimatedHours { get; set; }
        public Status Status { get; set; }
        public override string ToString()
        {
            return String.Format("[{0}] {1} ({2})", Status, Description, EstimatedHours);
        }
    }

    enum Status
    {
        NotStarted,
        InProgress,
        OnHold,
        Completed,
        Deleted
    }

    class Car
    {
        public string VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            return String.Format("Car VIN {0}", VIN);
        }
    }

    public class Book
    {
        public string Author { get; set; }
        public string Title { get; set; }
    }

}
