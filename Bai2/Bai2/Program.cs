using System;


namespace LAB4;

public delegate void BalanceChangedEventHandler(decimal newBalance);

public class Account
{
    private decimal balance;

    public event BalanceChangedEventHandler BalanceChanged;

    public decimal Balance
    {
        get { return balance; }
        private set
        {
            if (balance != value)
            {
                balance = value;
                OnBalanceChanged(balance);
            }
        }
    }

    public Account(decimal initialBalance)
    {
        balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
        }
    }

    public void Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
        }
    }

    protected virtual void OnBalanceChanged(decimal newBalance)
    {
        BalanceChanged?.Invoke(newBalance);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Account account = new Account(1000);

        // Register an event handler for the BalanceChanged event
        account.BalanceChanged += (newBalance) =>
        {
            Console.WriteLine($"Balance changed. New balance: {newBalance:C}");
        };

        // Perform transactions to trigger the event
        account.Deposit(500);
        account.Withdraw(200);

        // Unregister the event handler if no longer needed
        account.BalanceChanged -= (newBalance) =>
        {
            Console.WriteLine($"Balance changed. New balance: {newBalance:C}");
        };

        Console.ReadLine();
    }
}
