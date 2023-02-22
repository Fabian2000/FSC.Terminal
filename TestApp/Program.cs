using FSC;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Terminal.Title = "Delivery Service - Login";

            Terminal.WriteLine("Hello and welcome. What is your name?");

            string? username = Terminal.ReadLine("Username: ");

            bool showPassword = Terminal.ReadYesNo("Do you want to show your Password as * or keep it totally invisible? Choose between ", '*', 'i');

            Terminal.WriteLine("Awesome.");
            string? password = Terminal.ReadLine("Please enter your password: ", showPassword ? TerminalPasswordMode.HideByChar : TerminalPasswordMode.Hide);

            if (username != "john" || password != "doe")
            {
                Terminal.WriteLine("We are sorry, this account is not part of our organisation.");
                Terminal.ReadKey(true);
                return;
            }

            Terminal.WriteLine("Great, you are logged in!");

            Thread.Sleep(2_000);

            Terminal.Clear();

            Terminal.Title = "Delivery Service";

            string[] foodOfTheDay = { "Greek food", "Chinese food", "Italian food", "German food", "French food", "American food" };

            int index = Terminal.ReadSelection("Today is random food day, but you may still select, what kind of food you want (Press Escape to cancel the order):", true, foodOfTheDay);

            if (index == -1)
            {
                Terminal.WriteLine("Oh, we are sorry to hear that. We hope you change your mind and come back soon.");
                Terminal.ReadKey(true);
                return;
            }

            Thread.Sleep(2_000);

            DateTime time = DateTime.Now;

            while (true)
            {
                Terminal.Clear();
                Terminal.WriteLine($"Thank you for ordering at <Delivery Service>. Your order #{index}#{foodOfTheDay[index]}# got submitted and will arrive in {(time - DateTime.Now).Minutes + 25} minutes.");
                Thread.Sleep(60_000);
            }
        }
    }
}