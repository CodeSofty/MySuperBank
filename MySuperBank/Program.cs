using MySuperBank;

var account = new BankAccount("Kendra", 1000);

Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance}");
account.MakeWithdrawal(400, DateTime.Now, "Car Repairs");

// Test that the initial balances must be positive.
BankAccount invalidAccount;

account.MakeWithdrawal(50, DateTime.Now, "Xbox Game");
Console.WriteLine(account.GetAccountHistory());

// Test for a negative balance.
// try
// {
//     account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
// }
// catch (InvalidOperationException e)
// {
//     Console.WriteLine("Exception caught trying to overdraw");
//     Console.WriteLine(e.ToString());
// }
//
// // Test that the initial balances must be positive.
// try
// {
//     invalidAccount = new BankAccount("invalid", -55);
// }
// catch (ArgumentOutOfRangeException e)
// {
//     Console.WriteLine("Exception caught creating account with negative balance");
//     Console.WriteLine(e.ToString());
//     return;
// }