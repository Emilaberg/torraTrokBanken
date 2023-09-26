//Välkomna användaren 
//fråga om användaren vill logga in eller skapa konto KLAR
//logga in användaren eller skapa ett konto till användaren KLAR
//Visa användarens konton, både löne och spar, berätta att sparkontot har fyllts med valfri summa mellan 0-10000kr KLAR
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

   // skapa en for loop för att loopa igenom dictionaryn och där username och password stämmer hämta uppgifterna, och kolla om det stämmer överens med det man skrivit in.
}

int RegisterUser()
{
    Console.Write("New username : ");
    string? username = Console.ReadLine();
    Console.Write("New password : ");
    string? password = Console.ReadLine();
    
    //Adding new user
    User _ = new(username, password, userId);
    // TO-DO Create users savings account
    _.CreateSavingsAccount();
    _.CreateSalaryAccount();
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
        Console.WriteLine($"Your savings is {users[userSessionId].savingsAccount.GetSum()}\n");
        Console.WriteLine($"Your salary account is {users[userSessionId].salaryAccount.GetSum()}\n");

        Console.Write("Do you want to (T)ransfer money or (L)ogout? : ");
        string? input = Console.ReadLine();
        if (input.ToUpper() == "L")
        {
            isLoggedIn = false;
            Console.Clear();
            WelcomeUser();
        } // TODO lägg till transfer eller fel skriv. 
        
        Console.ReadKey(true);


    }
}