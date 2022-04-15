using System.Diagnostics;

    Stopwatch sw = new Stopwatch();
    sw.Start();
    Task<int> result = DoSomeCalculationAsync().Result;
    sw.Stop();

    Console.WriteLine($"{result} took {sw.Elapsed.TotalSeconds}");

    async Task<int> DoSomeCalculationAsync()
    {
        Task<int> a = SomeLongRunningTaskAAsync();
        Task<int> b = SomeLongRunningTaskBAsync();
        return await a + await b;
    }

    Task<int> SomeLongRunningTaskAAsync()
    {
        //Thread.Sleep(3000);
        return new Task<int>(() => { return 3000; });
    }

    Task<int> SomeLongRunningTaskBAsync()
    {
        //Thread.Sleep(5000);
        return new Task<int>(() => { return 5000; });
    }