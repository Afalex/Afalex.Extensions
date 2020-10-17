using Afalex.Examples.ModelOvverider;
using Afalex.Extensions.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace Afalex.Extensions.Tests
{
    [TestClass]
    public class ModelOvveriderTests
    {
        [TestMethod]
        public void OvverideMethodTest()
        {
            const string myBabyName = "Roman";
            //Arrange 
            ExampleModel original = new ExampleModel(1, "Alex", 27, 175);
            ExampleModel newValues = new ExampleModel(name: myBabyName);
            ExampleModel expected = (ExampleModel)original.Clone();
            expected.Name = myBabyName;

            //Act
            original.Ovveride(newValues); //  ExampleModel result = ModelOvverider.Ovveride(original, newValues);
            //Assert
            Assert.AreEqual(expected, original);
        }
    }
}
