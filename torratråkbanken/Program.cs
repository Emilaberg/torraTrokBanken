//Välkomna användaren 
//fråga om användaren vill logga in eller skapa konto
//logga in användaren eller skapa ett konto till användaren
//Visa användarens konton, både löne och spar, berätta att sparkontot har fyllts med valfri summa mellan 0-10000kr
//Fråga användaren om hen vill överföra pengar ta ut, eller sätta in pengar. alternativt logga ut
//om användaren vill överföra pengar, berätta för användaren hur mycket dom vill överföra till vilket konto. 

// om användaren vill sätta in pengar, berätta för användaren hur mycket dom vill sätta in till sparkonto.
//Om användaren vill logga ut, fråga om användaren vill logga in eller skapa konto igen.
using torratråkbanken;

List<User> users = new();


bool isLoggedIn = true;

while (isLoggedIn)
{
    WelcomeUser();
}


void WelcomeUser()
{
    Console.Clear();
    Console.WriteLine("************************************");
    Console.WriteLine("*****HELLO Welcome to Our bank!*****");
    Console.WriteLine("***(L)ogin or (C)reate an account***");
    Console.WriteLine("************************************");
    string input = Console.ReadLine();
    ValidateIfUserExits(input);

}

void LoginUser()
{
    Console.Write("username : ");
    string? username = Console.ReadLine();
    Console.Write("password : ");
    int password = int.Parse(Console.ReadLine());

    for (int i = 0; i < users.Count(); i++)
    {

    }

    foreach (User user in users)
    {

        Console.WriteLine(user);
    }
}

void RegisterUser(string username, int password)
{
    User newUser = new(username, password);
}

bool ValidateIfUserExits(string input)
{
    if (input.ToUpper() == "L")
    {
        LoginUser();
    }
    else if (input.ToUpper() == "C")
    {
        RegisterUser();
    }
    else
    {
        Console.WriteLine("something went wrong, try again...");
    }




    return true;
}