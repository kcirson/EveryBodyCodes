// See https://aka.ms/new-console-template for more information


using Search;

if (args == null || args.Length < 2)
{
    Console.WriteLine("No arguments giving please specify an argument with --name");
    return;
}

List<Camera> cameras = File.ReadAllLines("cameras.csv").Where(s => s.Contains(';')).Skip(1).Select(s => new Camera(s)).ToList();

switch (args.First())
{
    case "--name":
        Search(args.Last());
        break;
    default:
        Console.WriteLine($"I don't support argument {args.First()}");
        break;
}

void Search(string name)
{
    if (string.IsNullOrEmpty(name))
        return;

    name = name.ToLower();

    var found = cameras.Where(c => c.Name.ToLower().Contains(name));

    foreach (var camera in found)
    {
        Console.WriteLine(camera);
    }
}