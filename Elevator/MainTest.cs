using System;

namespace ElevatorProject
{
    class MainTest
    {        
        static void Main(string[] args)
        {
            Console.WriteLine("Elevator Test");
            //Creating elevator and users instances
            Elevator myElevator = new Elevator(200);

            Employee Director = new Employee();
            Director.IsExecutive = true;
            Director.Weight = 100;

            Employee Secretary = new Employee();
            Secretary.Weight = 160;

            //All employers get inside the elevator
            myElevator.InUser(Director);
            Console.WriteLine(String.Format("MaxWeight 1 : {0}", myElevator.CurrentWeight));

            myElevator.InUser(Secretary);
            Console.WriteLine(String.Format("MaxWeight 2 : {0}", myElevator.CurrentWeight));

            //Check if the elevator can run
            Console.WriteLine(String.Format("Elevator reach the max weight allowed? : {0}", myElevator.CheckMaxWeightAllowedReached()));

            //Check if the elevator can run
            Console.WriteLine(String.Format("This Employee can go to Vip section? : {0}", myElevator.GoToVipSection(Director)));
            Console.WriteLine(String.Format("This Employee can go to Vip section? : {0}", myElevator.GoToVipSection(Secretary)));

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }        
    }
}

