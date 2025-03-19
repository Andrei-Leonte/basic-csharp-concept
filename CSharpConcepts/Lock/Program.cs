using Lock;


Console.WriteLine("Running basic lock, result should be 2");
LockAndCallback.RunSafe();
LockAndCallback.RunUnsafe();


Console.ReadKey();