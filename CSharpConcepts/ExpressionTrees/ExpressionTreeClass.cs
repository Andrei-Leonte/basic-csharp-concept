using System.Linq.Expressions;

namespace ExpressionTrees
{
    public class ExpressionTreeClass
    {
        public static void RunBasicExpression()
        {
            // Step 1: Create the expression tree
            Expression<Func<int, int>> addFive = (num) => num + 5;

            // Step 2: Compile the expression tree into a delegate
            Func<int, int> compiledExpression = addFive.Compile();

            // Step 3: Invoke the delegate to execute the expression
            int result = compiledExpression(10); // Pass the argument 10

            // Output the result
            Console.WriteLine(result); // Output will be 15            
        }

        public static void RunFromLeaf()
        {
            // Step 1: Create the expression tree
            var one = Expression.Constant(1, typeof(int));
            var two = Expression.Constant(2, typeof(int));
            var addition = Expression.Add(one, two);

            // Step 2: Compile the expression tree into a delegate
            var lambda = Expression.Lambda<Func<int>>(addition);
            var compiledExpression = lambda.Compile();

            // Step 3: Invoke the delegate to execute the expression
            int result = compiledExpression();

            // Output the result
            Console.WriteLine(result); // Output will be 3
        }
    }
}
