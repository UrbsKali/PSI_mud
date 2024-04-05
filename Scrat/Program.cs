using Scrat;

internal class Program
{
    private static void Main(string[] args)
    {
        // ask user a string filename 
        Console.Write("Entrez le nom du fichier image : ");     
        string filename = Console.ReadLine();
        // create a new image from the file
        MyImage tmp = new MyImage(filename);
        // Save the image with a new name
        Console.Write("Entrez le nom du fichier image : ");
        filename = Console.ReadLine();
        tmp.Save(filename);
    }
}