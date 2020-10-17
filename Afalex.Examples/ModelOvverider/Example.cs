namespace Afalex.Examples.ModelOvverider
{
    public class Example
    {
        public Example()
        {
            ExampleModel exampleModel = new ExampleModel(name: "Roman").TestObject();
            /*
             exampleModel = originalModel + newVales
            {
             name: "Roman"
             age: 27
             height: 175
            }
            */
        }
    }
}
