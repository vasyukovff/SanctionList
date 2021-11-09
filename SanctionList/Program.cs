using SanctionList;

Console.WriteLine("Download the file...");

var data = new Data();
var objects = data.GetData();

if (objects == null || objects.Count == 0)
{
    Console.WriteLine("File is empty!");
    Console.WriteLine("Please press any key for the exit...");
    Console.ReadKey(true);
    return;
}

Console.WriteLine("Done!");

while (true)
{
    Console.Clear();

    Console.WriteLine("Select an action:");
    Console.WriteLine("1. Search by people.");
    Console.WriteLine("2. Search by companies.");

    if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out int actionNumber) == false)
        continue;

    var actionType = (ActionTypeEnum)actionNumber;

    if (string.IsNullOrEmpty(actionType.GetEnumMemberValue()))
        continue;

    string searchTerm = "";

    while(string.IsNullOrEmpty(searchTerm))
    {
        Console.Write("Please, write your search term: ");
        searchTerm = Console.ReadLine();
    }

    var result = Finder.Find(actionType, objects, searchTerm);

    if(result == null)
        continue;

    Console.WriteLine($"The result has {result.Count} rows.");

    if(Save.SaveObjectsToCSV(result, searchTerm, out string fileName))
    {
        Console.WriteLine("File save as: " + fileName);
    }

    Console.WriteLine("\nPlease press any key for the continue...");
    Console.ReadKey();
}