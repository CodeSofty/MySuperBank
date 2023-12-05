using MySuperBank;

var account = new BankAccount("Kendra", 1000);

Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance}");