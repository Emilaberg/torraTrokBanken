//Välkomna användaren 
//fråga om användaren vill logga in eller skapa konto
//logga in användaren eller skapa ett konto till användaren
//Visa användarens konton, både löne och spar, berätta att sparkontot har fyllts med valfri summa mellan 0-10000kr
//Fråga användaren om hen vill överföra pengar ta ut, eller sätta in pengar. alternativt logga ut
//om användaren vill överföra pengar, berätta för användaren hur mycket dom vill överföra till vilket konto. 

// om användaren vill sätta in pengar, berätta för användaren hur mycket dom vill sätta in till sparkonto.
//Om användaren vill logga ut, fråga om användaren vill logga in eller skapa konto igen.
using torratråkbanken;

//List<User> users = new();
Dictionary<int, User> users = new();

int userId = 0;
bool isLoggedIn = false;

WelcomeUser();

void WelcomeUser()
{
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
    string password = Console.ReadLine();

    for (int i = 0; i < users.Count(); i++)
    {

    }

    
}

int RegisterUser()
{
    Console.Write("New username : ");
    string? username = Console.ReadLine();
    Console.Write("New password : ");
    string? password = Console.ReadLine();
    
    //Adding new user
    User _ = new(username, password, userId);
    users.Add(userId, _); // setting new user in dictonary with a key value with userId
    userId++;

    return userId - 1;
}

bool ValidateIfUserExits(string input)
{
    if (input.ToUpper() == "L")
    {
        LoginUser();
    }
    else if (input.ToUpper() == "C")
    {
        int sessionId = RegisterUser();
        StartSession(sessionId);
    }
    else
    {
        Console.WriteLine("something went wrong, try again...");
    }

    return true;
}

void StartSession(int userSessionId)
{
    isLoggedIn = true;

    string userSessionName = users[userSessionId].GetUsername();

    while (isLoggedIn)
    {
        //welcome user!
        Console.WriteLine($"Welcome back! {userSessionName}");
        Console.ReadKey(true);

    }
}