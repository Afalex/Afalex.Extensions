using Afalex.Extensions.Tests;

namespace Afalex.Examples.ModelOvverider
{
    public static class ExampleModelTestDataExtensions
    {
        public static ExampleModel TestObject(this ExampleModel newValuesObject)
        {
            var testObject = new ExampleModel(name: "Alex", age: 27, height: 175);
            return testObject.Ovveride(newValuesObject);
        }
    }
}
