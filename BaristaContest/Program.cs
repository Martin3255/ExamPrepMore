namespace BaristaContest
{
    public class Program
    {
        static void Main()
        {
            Queue<int> coffee = new Queue<int>(Console.ReadLine()
                             .Split(", ").Select(int.Parse).ToArray());

            Stack<int> milk = new Stack<int>(Console.ReadLine()
                .Split(", ").Select(int.Parse).ToArray());

            Dictionary<string, int> drinksMade = new Dictionary<string, int>();

            bool isDrinkMade = false;

            Dictionary<string, int> drinksList = new Dictionary<string, int>()
            {
                {"Cortado", 50 },
                {"Espresso", 75 },
                {"Capuccino", 100 },
                {"Americano", 150 },
                {"Latte", 200 },
            };

            while (true)
            {
                if (!coffee.Any() && !milk.Any())
                {
                    break;
                }
                isDrinkMade = false;

                int milkAndCoffeesSum = coffee.Peek() + milk.Peek();

                foreach (var drink in drinksList)
                {
                    if (milkAndCoffeesSum == drink.Value)
                    {
                        if (!drinksMade.ContainsKey(drink.Key))
                        {
                            drinksMade.Add(drink.Key, 1);
                        }
                        else
                        {
                            drinksMade[drink.Key]++;
                        }
                        milk.Pop();
                        coffee.Dequeue();
                        isDrinkMade = true;
                        break;
                    }
                }
            }
            if (!isDrinkMade)
            {
                if (coffee.Any())
                {
                    coffee.Dequeue();
                }
                if (milk.Any())
                {
                    milk.Push(milk.Pop() - 5);
                }
            }
            //first line
            var firstLine = coffee.Count == 0 && milk.Count == 0
                ? "Nina is going to win! She used all the milk and coffee!"
                : "Nina needs to exercise more! She didn't use all the milk and coffee!";
            Console.WriteLine(firstLine);

            //second line
            var coffeeLeft = coffee.Count == 0 ? "none" : String.Join(", ", coffee);
            Console.WriteLine($"Coffee left: {coffeeLeft}");

            //third line
            var milkLeft = milk.Count == 0 ? "none" : String.Join(", ", milk);
            Console.WriteLine($"Milk left: {milkLeft}");

            //fourth line
            foreach (var drink in drinksMade.OrderBy(x => x.Value).ThenByDescending(x => x.Key))
            {
                Console.WriteLine($"{drink.Key}: {drink.Value}");
            }
        }
    }
}