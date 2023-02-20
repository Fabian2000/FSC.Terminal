# FSC.Terminal
 A better version of the console class in C#

---

# What is FSC.Terminal?
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

_If you choose a password mode, the password will not be visible_
