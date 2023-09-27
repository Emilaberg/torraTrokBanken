//Välkomna användaren 
//fråga om användaren vill logga in eller skapa konto KLAR
//logga in användaren eller skapa ett konto till användaren KLAR
//Visa användarens konton, både löne och spar, berätta att sparkontot har fyllts med valfri summa mellan 0-10000kr KLAR
//Fråga användaren om hen vill överföra pengar ta ut, eller sätta in pengar. alternativt logga ut KLAR
//om användaren vill överföra pengar, berätta för användaren hur mycket dom vill överföra till vilket konto. KLAR

// om användaren vill sätta in pengar, berätta för användaren hur mycket dom vill sätta in till sparkonto. KLAR
//Om användaren vill logga ut, fråga om användaren vill logga in eller skapa konto igen. KLAR
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

    string? username = Esc(Console.ReadLine());
    Console.Write("password : ");
    string? password = Esc(Console.ReadLine());

    // skapa en for loop för att loopa igenom dictionaryn och där username och password stämmer hämta uppgifterna,
    // och kolla om det stämmer överens med det man skrivit in.
    if (string.IsNullOrWhiteSpace(username) && string.IsNullOrWhiteSpace(password))
    {
        Console.WriteLine("you need to type something...");
        Thread.Sleep(1000);
        Console.Clear();

        LoginUser();
    }
    else
    {
        //flytta denna if checken till en egen funktion
        ValidateLoginInput(username, password);
        Console.WriteLine("there is no user with these credentials, Do you want to register or return (y/n)");
        string? _ = Console.ReadLine();
        ValidateIfUserExits(_);
    }
}

string Esc(string input)
{

    //TODO if keypress was esc, console clear and show welcome. otherwise return input,
    if (input == "e")
    {
        Console.Clear();
        WelcomeUser();
    }
    return input;
}
//Validate login 
bool ValidateLoginInput(string username, string password)
{
    for (int i = 0; i < users.Count(); i++)
    {
        if (users[i].GetUsername() == username && users[i].GetPassword() == password) //Detta betyder att usern finns
        {
            StartSession(users[i].GetUserId());
        }
        else if ((users[i].GetUsername() == username) && !(users[i].GetPassword() == password)) //om namnet är korrekt men lösen fel
        {
            Console.WriteLine("password was incorrect, try again");
            Thread.Sleep(3000);
            Console.Clear();

            LoginUser();

        }
        else if (!(users[i].GetUsername() == username) && (users[i].GetPassword() == password))
        {
            Console.WriteLine("username was incorrect, try again");
            Thread.Sleep(3000);
            Console.Clear();

            LoginUser();
        }
    }

    return false;
}
int RegisterUser()
{
    Console.Write("New username : ");
    string? username = Esc(Console.ReadLine());
    Console.Write("New password : ");
    string? password = Esc(Console.ReadLine());

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
    else if (input.ToUpper() == "Y")
    {
        Console.Clear();
        int sessionId = RegisterUser();
        StartSession(sessionId);
    }
    else if (input.ToUpper() == "N")
    {
        Console.Clear();
        WelcomeUser();
    }
    else
    {
        Console.WriteLine("something went wrong, try again...");
        Thread.Sleep(1000);
        Console.Clear();
        WelcomeUser();
    }


    return true;
}

void StartSession(int userSessionId)
{
    isLoggedIn = true;
    //sätter userSession username till en variabel
    string userSessionName = users[userSessionId].GetUsername();

    while (isLoggedIn)
    {
        //welcome user!
        Console.WriteLine($"Welcome back! {userSessionName}");
        Console.WriteLine($"Your savings is {users[userSessionId].savingsAccount.GetSum()} SEK\n");
        Console.WriteLine($"Your salary account is {users[userSessionId].salaryAccount.GetSum()} SEK\n");

        Console.Write("Do you want to (D)eposit money? or (T)ransfer money or (L)ogout?: ");
        string? input = Console.ReadLine();
        if (input.ToUpper() == "L")
        {
            isLoggedIn = false;
            Console.Clear();
            WelcomeUser();
        } // TODO lägg till transfer eller fel skriv. 
        else if (input.ToUpper() == "T")
        {
            if (TransferUserMoney(userSessionId) == false) //TO-DO checka så att summan man vill överföra funkar.
            {
                Console.WriteLine("transfer failed...");
                Console.WriteLine("reverting");
                for (int i = 0; i < 3; i++)
                {
                    Thread.Sleep(400);
                    Console.WriteLine("\r.");
                }
                //OM överföringen funkar, så kommer inget att hända och loopen kommer starta om. 
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
        else if (input.ToUpper() == "D")
        {
            AddMoney(userSessionId);
        }
        else if (input.ToUpper() == "E")
        {
            Console.Clear();
        }
    }
}

bool TransferUserMoney(int userSessionId)
{
    Console.WriteLine($"Savings Account: \n {users[userSessionId].savingsAccount.GetSum()}");
    Console.WriteLine($"Salary Account: \n {users[userSessionId].salaryAccount.GetSum()}");

    Console.WriteLine("FROM which account do you want to transfer?");
    Console.Write(": ");
    string from = Console.ReadLine();

    Console.WriteLine("TO which account do you want to transfer?");
    Console.Write(": ");
    string to = Console.ReadLine();

    Console.WriteLine("How much do you want to transfer?");
    Console.Write(": ");
    int amount = Int32.Parse(Console.ReadLine());
    Thread.Sleep(2000);
    if (users[userSessionId].TransferMoney(from, amount))
    {
        Console.WriteLine($"transferred {amount} kr from {from} to {to}");
        Thread.Sleep(1000);
        Console.WriteLine("transfer successfull!");
        Console.WriteLine("reverting");
        for (int i = 0; i < 3; i++)
        {
            Thread.Sleep(400);
            Console.WriteLine("\r.");
            Console.Clear();
        }
        return true;
    }
    else
    {
        Console.WriteLine("You don't have a enough money...");
        Thread.Sleep(1000);
    }
    return false;
}

bool AddMoney(int userSessionId)
{
    Console.WriteLine("How much money do you want to add?");
    Console.Write(": ");
    int amount = Int32.Parse(Console.ReadLine());
    users[userSessionId].Deposit(amount);
    Thread.Sleep(2000);
    Console.WriteLine("transfer successfull!");
    Thread.Sleep(1000);
    Console.WriteLine("reverting");
    Thread.Sleep(1000);
    for (int i = 0; i < 3; i++)
    {
        Thread.Sleep(400);
        Console.WriteLine("\r.");
        Console.Clear();
    }
    return false;
}