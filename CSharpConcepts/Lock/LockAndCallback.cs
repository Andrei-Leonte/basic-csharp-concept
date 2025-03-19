namespace Lock
{
    internal class LockAndCallback
    {
        public static void RunSafe()
        {
            int counter = 0;

            var incrementClass1 = new IncrementClass();

            List<IncrementCallback> callbacks = [];

            for (int i = 0; i < 10000; i++)
            {
                callbacks.Add(incrementClass1.IncrementSafe);
            }
    
            Parallel.ForEach(callbacks, callback => callback(ref counter));

            Console.WriteLine($"Safe run with lock counter -- {counter}");
        }

        public static void RunUnsafe()
        {
            int counter = 0;

            var incrementClass1 = new IncrementClass();

            List<IncrementCallback> callbacks = [];

            for (int i = 0; i < 10000; i++)
            {
                callbacks.Add(incrementClass1.IncrementUnsafe);
            }

            Parallel.ForEach(callbacks, callback => callback(ref counter));

            Console.WriteLine($"Unsafe run without lock counter -- {counter}");
        }


        public delegate void IncrementCallback(ref int value);

        public void increas(ref int value)
        {
            value++;
        }

        public class IncrementClass
        {
            private readonly object _lock = new();

            public void IncrementSafe(ref int value)
            {
                lock (_lock)
                {
                    value++;
                }
            }

            public void IncrementUnsafe(ref int value)
            {
                value++;
            }
        }
    }
}
