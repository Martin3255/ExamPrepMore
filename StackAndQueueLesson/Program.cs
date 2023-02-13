var mgOfCaffeine = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

var energyDrinks = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

int totalCaffeine = 0;
int currCaffeine = 0;

while (mgOfCaffeine.Count > 0 && energyDrinks.Count > 0)
{
    currCaffeine = mgOfCaffeine.Peek() * energyDrinks.Peek();
    int avCaffeine = 300 - currCaffeine;
    if (currCaffeine + totalCaffeine <= 300)
    {
        totalCaffeine += currCaffeine;
        mgOfCaffeine.Pop();
        energyDrinks.Dequeue();

    }
    if (currCaffeine + totalCaffeine > avCaffeine && energyDrinks.Count > 0)
    {
        if (totalCaffeine - 30 >= 0)
        {
            totalCaffeine -= 30;
        }
        mgOfCaffeine.Pop();
        energyDrinks.Enqueue(energyDrinks.Dequeue());
    }
    currCaffeine = 0;
}
if (energyDrinks.Count > 0)
{
    Console.WriteLine($"Drinks left: {string.Join(", ", energyDrinks)}");
}
else
{
    Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
}
Console.WriteLine($"Stamat is going to sleep with {totalCaffeine} mg caffeine.");