# FSC.Terminal
 A better version of the console class in C#

## What is FSC.Terminal?
Terminal is the same like the console class. It uses generics in some methods and offers the possibility to write a hidden password.
You can choose a password char or just use nothing like in the most linux software. Try it out and you will notice how similar it is to the default console class, but still so much advanced

## Example Script
```cs
using FSC;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Terminal.Title = "Example";

            Terminal.WriteLine("Welcome!");
            Terminal.WriteLine();

            string? name = Terminal.ReadLine("Please enter your username: ");
            string? password = Terminal.ReadLine("Please enter your password: ", TerminalPasswordMode.Hide);
            
            Terminal.WriteLine("Thank you. You are logged in. If you want to see your inputted data, write yes");
            
            if (Terminal.ReadLine() == "yes")
            {
                Terminal.WriteLine($"Username: {name}{Environment.NewLine}Password: {password}");
            }

            Terminal.ReadKey();
        }
    }
}
```

## Output
```cmd
Welcome!

Please enter your username: JohnDoe
Please enter your password:
Thank you. You are logged in. If you want to see your inputted data, write yes
yes
Username: JohnDoe
Password: 12345678
```

_If you choose the right password mode, the password will not be visible_

## Example Script 2
```cs
Terminal.WriteLine("Hello User,");
string[] starSelection = { "*", "**", "***", "****", "*****" };

int index = ReadSelection("if you like, what we do, rate us with 5 stars, please", starSelection);

if (index >= 0 && index <= 2)
{
    Terminal.WriteLine("Oh, we are sorry to hear about this sad feedback");
}
else
{
    Terminal.WriteLine("Wow, thank you for your feedback");
}

Terminal.ReadKey();
```
_The index is the index of the array or list that is given_

## Output 2
```cmd
Hello User,
if you like, what we do, rate us with 5 stars, please
> *
**
***
****
*****
```
_After pressing enter_
```cmd
Hello User,
if you like, what we do, rate us with 5 stars, please
*****
Wow, thank you for your feedback
```

## Example Script 3
```cs
bool userAgreed = Terminal.ReadYesNo("Do you agree our ToS and privacy policy?", 'y', 'N')
```
_The user can only input y or N. This can not be canceled with the escape key._

## Example 4
```cs
static void Main(string[] args)
{
    Terminal.Title = "License Input";
    while (true)
    {
        Terminal.WriteLine("Hello");
        if (Terminal.ReadLicense("Please enter a license: ", out string value, 4, 4))
        {
            Terminal.WriteLine("You entered " + value);
            break;
        }
        else
        {
            Terminal.WriteLine("Invalid license ...");
        }
    }
    Terminal.ReadKey(true);
}
```

## Output 4
```cmd
Hello
Please enter a license: ____-____-____-____
```

## How a program could look like:
```cs
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
```
