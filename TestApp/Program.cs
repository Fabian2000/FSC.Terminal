using FSC;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Terminal.Title = "TestApp";

            Terminal.WriteLine("Hello, this is a test App");

            var username = Terminal.ReadLine("Please enter your username: ");
            var password1 = Terminal.ReadLine("Please enter your password: ", TerminalPasswordMode.Hide);
            var password2 = Terminal.ReadLine("Please enter your second password: ", TerminalPasswordMode.HideByChar);
            
            Terminal.PasswordChar = '$';
            var password3 = Terminal.ReadLine("Please enter your third password: ", TerminalPasswordMode.HideByChar);

            Terminal.WriteLine();

            Terminal.WriteLine("WOW, thank you for logging in. Nice to see you again. Your login data is:");
            Terminal.WriteLine($"Username: {username}");
            Terminal.WriteLine($"Password1: {password1}");
            Terminal.WriteLine($"Password2: {password2}");
            Terminal.WriteLine($"Password3: {password3}");

            Terminal.ReadKey();
        }
    }
}