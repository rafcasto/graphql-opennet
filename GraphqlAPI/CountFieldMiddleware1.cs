using GraphQL.Instrumentation;
using GraphQL;
using System.Diagnostics;

namespace GraphqlAPI
{
    public class CountFieldMiddleware : IFieldMiddleware, IDisposable
    {
        private int _count;

        public CountFieldMiddleware(IHttpContextAccessor accessor)
        {
            // these dependencies are not needed here and are used only for demonstration purposes
            Debug.Assert(accessor != null);
           
        }

        public ValueTask<object?> ResolveAsync(IResolveFieldContext context, FieldMiddlewareDelegate next)
        {
            Interlocked.Increment(ref _count);

            return next(context);
        }

        public void Dispose()
        {
            Console.WriteLine($"{_count} fields were executed");
        }
    }
}