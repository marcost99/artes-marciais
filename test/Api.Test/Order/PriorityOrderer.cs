using Xunit.Abstractions;
using Xunit.Sdk;

namespace Api.Test.Order
{
    public class PriorityOrderer : ITestCaseOrderer
    {
        public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases)
            where TTestCase : ITestCase
        {
            return testCases.OrderBy(tc =>
                tc.TestMethod.Method.GetCustomAttributes(typeof(TestPriorityAttribute))
                .FirstOrDefault()?.GetNamedArgument<int>("Priority") ?? 0);
        }
    }
}
