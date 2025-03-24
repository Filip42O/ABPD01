
namespace ConsoleApp1;

public class OverfillException : Exception
{
    public OverfillException() : base("Masa ładunku przekracza dopuszczalną ładowność kontenera") { }
    
    public OverfillException(string message) : base(message) { }


}