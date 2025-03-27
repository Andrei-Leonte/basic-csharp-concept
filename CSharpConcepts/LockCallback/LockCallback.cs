namespace LockCallback
{
    internal class LockCallback
    {
        public static int RunSafe()
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

            return counter;
        }

        public static int RunUnsafe()
        {
            int counter = 0;

            var incrementClass = new IncrementClass();

            List<IncrementCallback> callbacks = [];

            for (int i = 0; i < 10000; i++)
            {
                callbacks.Add(IncrementClass.IncrementUnsafe);
            }

            Parallel.ForEach(callbacks, callback => callback(ref counter));

            Console.WriteLine($"Unsafe run without lock counter -- {counter}");

            return counter;
        }


        public delegate void IncrementCallback(ref int value);

        public static void Increas(ref int value)
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

            public static void IncrementUnsafe(ref int value)
            {
                value++;
            }
        }
    }
}