using jz241111;

List<Fish> lake = new();

string[] fishspecies = ["blobfish", "trout", "eel", "sardine", "cod", "shark", "clownfish", "piranha", "pufferfish", "kardhal", "goldfish", "barracuda", "karp", "magikarp"];

for (int i = 0; i < 100; i++)
{
    lake.Add(new(
        species: fishspecies[Random.Shared.Next(fishspecies.Length)],
        predator: Random.Shared.Next(0, 100) < 10,
        weight: Random.Shared.Next(2, 80) / 2F,
        top: Random.Shared.Next(0, 401),
        depth: Random.Shared.Next(10, 401)
        ));
}

for (int i = 0; i < 100; i++)
{
    Console.WriteLine($"round {i + 1:00}.:");

    int xindex = Random.Shared.Next(lake.Count);
    int yindex;
    do
    {
        yindex = Random.Shared.Next(lake.Count);
    }
    while (yindex == xindex);

    var x = lake[xindex];
    var y = lake[yindex];

    Console.WriteLine("selected:");

    Console.ForegroundColor = x.Predator
        ? ConsoleColor.Red
        : ConsoleColor.Green;
    Console.WriteLine($"X: {x}");

    Console.ForegroundColor = y.Predator
    ? ConsoleColor.Red
    : ConsoleColor.Green;
    Console.WriteLine($"Y: {y}");

    Console.ResetColor();

    if(x.Predator != y.Predator)
    {
        if (x.Top > y.Top) (x, y) = (y, x);

        if (y.Top < x.Top + x.Depth)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("They can meet!");
            Console.ResetColor();

            if (Random.Shared.Next(100) < 30)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("The predator attacks!");
                Console.ResetColor();
                if (x.Predator)
                {
                    lake.Remove(y);
                    if (x.Weight < 40)
                    {
                        x.Weight += 0.1F;
                    }
                }
                else
                {
                    lake.Remove(x);
                    if (y.Weight < 40)
                    {
                        y.Weight += 0.1F;
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("The predator is not hungry!");
                Console.ResetColor();
            }
        }
        else Console.WriteLine("They can't meet");
    }
    else Console.WriteLine("Can't match");

    Console.WriteLine("\n--------------------------------\n");
}

Console.WriteLine($"Remaining fish population: {lake.Count}");