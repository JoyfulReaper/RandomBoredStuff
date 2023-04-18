using Shared;
using System.Reflection;

var assemblies = ScanAssemblies();
var demos = LoadDemos(assemblies);

bool first = true;
while (true)
{
    if(!first)
        Console.WriteLine();

    first = false;

    ShowMenu(demos);
    var selection = GetMenuSelection();
    await ExecuteDemo(demos, selection);
}

static List<Assembly> ScanAssemblies()
{
    var output = new List<Assembly>
    {
        Assembly.GetAssembly(typeof(Observer.Discovery)) ?? throw new Exception("Assembly unexpectedly null."),
        Assembly.GetAssembly(typeof(FactoryMethod.Discovery)) ?? throw new Exception("Assembly unexpectedly null."),
        Assembly.GetAssembly(typeof(AbstractFactory.Discovery)) ?? throw new Exception("Assembly unexpectedly null."),
    };

    return output;
}

static Dictionary<int, IDemoApp> LoadDemos(List<Assembly> assemblies)
{
    var count = 1;

    var demos = assemblies.SelectMany(assembly => assembly.GetTypes())
        .Where(t => typeof(IDemoApp).IsAssignableFrom(t) && !t.IsInterface);

    var dictionary = new Dictionary<int, IDemoApp>();

    foreach (var demo in demos)
    {
        var instance = Activator.CreateInstance(demo) as IDemoApp ?? throw new Exception("Unable to create instance.");
        dictionary.Add(count, instance);
        count++;
    }

    return dictionary;
}

static void ShowMenu(Dictionary<int, IDemoApp> demos)
{
    Console.WriteLine("Demo Menu (zero to quit): ");
    Console.WriteLine("0. Quit");
    foreach (var demo in demos)
    {
        Console.WriteLine($"{demo.Key}. {demo.Value.GetMenuEntry()}");
    }
}

static int GetMenuSelection()
{
    Console.WriteLine();
    Console.Write("Select a demo: ");

    var input = Console.ReadLine() ?? 
        throw new Exception("Input was unexpectedly null.");

    var selection = int.Parse(input);
    if(selection == 0)
    {
        Environment.Exit(0);
    }

    return selection;
}

static async Task ExecuteDemo(Dictionary<int, IDemoApp> demos, int selection)
{
    if (demos.TryGetValue(selection, out var demo))
    {
        await demo.ExecuteAsync();
    }
    else
    {
        throw new Exception($"Failed to locate demo #{selection}");
    }
}