/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>

/// <summary>
/// Maintain a Customer Service Queue. Allows new customers to be
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService
{
    public static void Run()
    {
        // TEST 1: Verify customers are served in FIFO order.
        Console.WriteLine("TEST 1: FIFO ORDER");
        Console.WriteLine("=================");

        var service = new CustomerService(3);

        Console.WriteLine("Enter first customer:");
        service.AddNewCustomer();

        Console.WriteLine("Enter second customer:");
        service.AddNewCustomer();

        Console.WriteLine("\nQueue before serving:");
        Console.WriteLine(service);

        Console.WriteLine("\nServing first customer:");
        service.ServeCustomer();

        Console.WriteLine("\nQueue after serving:");
        Console.WriteLine(service);

        Console.WriteLine("=================");

        // TEST 2: Verify that an empty queue is handled safely.
        Console.WriteLine("TEST 2: EMPTY QUEUE");
        Console.WriteLine("=================");

        var emptyService = new CustomerService(3);
        emptyService.ServeCustomer();

        Console.WriteLine("=================");

        // TEST 3: Verify maximum queue capacity.
        Console.WriteLine("TEST 3: MAXIMUM CAPACITY");
        Console.WriteLine("=================");

        var fullService = new CustomerService(2);

        Console.WriteLine("Enter first customer:");
        fullService.AddNewCustomer();

        Console.WriteLine("Enter second customer:");
        fullService.AddNewCustomer();

        Console.WriteLine("Attempting to add a third customer:");
        fullService.AddNewCustomer();

        Console.WriteLine("\nFinal queue:");
        Console.WriteLine(fullService);
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// </summary>
    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId}) : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for customer and problem information.
    /// Add the new customer to the queue.
    /// </summary>
    private void AddNewCustomer()
    {
        // CORRECTION 1:
        // Use >= to prevent exceeding the maximum queue size.
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();

        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();

        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer()
    {
        // CORRECTION 3:
        // Check whether the queue is empty before accessing an item.
        if (_queue.Count == 0)
        {
            Console.WriteLine("No customers in the queue.");
            return;
        }

        // CORRECTION 2:
        // Retrieve the first customer before removing them.
        var customer = _queue[0];

        // Remove the customer from the front of the queue.
        _queue.RemoveAt(0);

        // Display the customer who has been served.
        Console.WriteLine("Serving: " + customer);
    }

    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => "
            + string.Join(", ", _queue) + "]";
    }
}
