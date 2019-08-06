using System;
using System.Collections.Generic;

namespace hungryNinja
{
    class Program
    {
        static void Main(string[] args)
        {
           var cody = new Ninja();
           var newBuffet = new Buffet();
           while (!cody.IsFull)
           {
               cody.Eat(newBuffet.Serve());
           }
           Console.WriteLine(cody);
           Console.Write("The Ninja ate the following: ");
           foreach(var food in cody.FoodHistory)
           {
               Console.Write($"{food.Name}: {food.Calories} cal; ");
           }
           Console.WriteLine();
        }
        class Food
        {
            public string Name {get; set;}
            public int Calories {get; set;}=100;
            public bool IsSpicy {get; set;}=false;
            public bool IsSweet {get; set;}=false;

            public string GetInfo()
                {
                    return $"Your {Name} has {Calories} calories. Is it sweet? {IsSweet}. Is it spicy? {IsSpicy}";
                }
            

            public Food(string name, int calories, bool spicy, bool sweet)
            {
                Name = name;
                Calories = calories;
                IsSpicy = spicy;
                IsSweet = sweet;
            }
        }

        class Buffet
        {
            public List<Food> Menu;

            public Buffet()
            {
                Menu = new List<Food>()
                {
                    new Food("Pizza", 350, false, false),
                    new Food("Wings", 400, true, false),
                    new Food("BBQ Chicken", 320, false, true),
                    new Food("Almonds", 250, false, false),
                    new Food("Pasta", 600, false, false),
                    new Food("Sliders", 300, false, false),
                    new Food("Tacos", 150, true, false),
                };
            }


            public Food Serve()
            {
                Random randFood = new Random();
                int randInt = randFood.Next(Menu.Count);
                return Menu[randInt];
            }
        }

        class Ninja
        {
            public Ninja()
            {
                calorieIntake = 0;
                FoodHistory = new List<Food>();
            }
            private int calorieIntake;
            public List<Food> FoodHistory;

            public bool IsFull {get;set;}
            public void Eat(Food item)
            {
                if (calorieIntake <=2000)
                {
                    calorieIntake += item.Calories;
                    FoodHistory.Add(item);
                    item.GetInfo();
                    IsFull = false;
                }
                else{
                    Console.WriteLine("The Ninja is full and can't eat anymore");
                    IsFull = true;
                }
            }
        }
    }
}
