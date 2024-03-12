namespace CircularBufferEvents;

public delegate void LogEntryAddedHandler(LogEntry logEntry);

class Program
{
    public static void Main(string[] args)
    {
        CircularBuffer logger = new CircularBuffer(5);

        // Subscribe to the LogEntryAdded event
        logger.LogEntryAdded += OnLogEntryAdded;

        logger.LogEvent(new LogEntry(1, "man was eaten by a cat"));
        logger.LogEvent(new LogEntry(0, "End of the world in 2 days"));
        logger.LogEvent(new LogEntry(4 ,"KFC 10% off on every item"));
        Thread.Sleep(100); // test timestamp
        logger.LogEvent(new LogEntry(4, "KFC 10% off on every item"));
        logger.LogEvent(new LogEntry(4, "KFC 10% off on every item"));
        logger.LogEvent(new LogEntry(4, "KFC 10% off on every item"));

        foreach (var log in logger.GetHistory()) // get all logs (from newest to oldest)
        {
            Console.WriteLine(log.Content);
        }

        Console.ReadKey();
    }

    private static void OnLogEntryAdded(LogEntry logEntry)
    {
        Console.WriteLine($"{logEntry.Timestamp} - [{logEntry.Priority}] {logEntry.Content}");
    }
}

public class LogEntry
{
    private int priority; // 0 most important, 5 - least important
    public int Priority
    {
        get
        {
            return priority;
        }
        set
        {
            if (priority >= 0)
            {
                priority = value;
            }
            else
            {
                throw new ArgumentException("Priority must be greater or equal to 0");
            }

        }
    }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow; // universal time
    public string Content { get; set; } // actuall content of log

    public LogEntry(int priority, string message)
    {
        this.Priority = priority;
        this.Content = message;
    }

}

public class CircularBuffer // accepts all data types -> T -> generic data type
{
    public event LogEntryAddedHandler LogEntryAdded;

    int bufferSize;
    private Queue<LogEntry> buffer;

    public CircularBuffer(int size)
    {
        bufferSize = size;
        buffer = new Queue<LogEntry>(bufferSize);
    }

    public void LogEvent(LogEntry log) // log event
    {
        if (buffer.Count == bufferSize)
        {
            buffer.Dequeue(); // remove the oldest item if queue if full
        }
        buffer.Enqueue(log);

        LogEntryAdded?.Invoke((LogEntry) log); // run event
    }

    public void Resize(int size) // resize the buffer
    {
        if (size <= 0)
        {
            throw new ArgumentException("Buffer size must be greater than 0");
        }

        Queue<LogEntry> newBuffer = new Queue<LogEntry>(size);

        while (buffer.Count > size) // get rid of old logs if the new buffer wouldn't fit them
        {
            buffer.Dequeue();
        }

        while (buffer.Count > 0)
        {
            newBuffer.Enqueue(buffer.Dequeue());
        }


        bufferSize = size;
        buffer = newBuffer;
    }

    public void ClearBuffer() 
    {
        buffer.Clear();
    }

    public IEnumerable<LogEntry> GetHistory()
    {
        // return buffer.ToArray();
        return buffer.OrderByDescending(x => (x as LogEntry).Timestamp);
    }
}