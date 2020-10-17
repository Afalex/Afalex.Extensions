using Afalex.Extensions.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Afalex.Extensions.Tests
{
    #region model
#pragma warning disable CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    public class TestModel : ICloneable
#pragma warning restore CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    {
        public override bool Equals(object obj)
        {
            if (obj is TestModel model)
            {
                return model.Age == this.Age
                     && model.Name == this.Name
                     && model.Height == this.Height;
            }
            return false;
        }

        public object Clone()
        {
            return base.MemberwiseClone();
        }

        public TestModel(int? id = null, string name = null, int? age = null, double? height = null)
        {
            if (id != null) Id = id;
            if (name != null) Name = name;
            if (Age != null) Age = age;
            if (height != null) Height = height;
        }

        public int? Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public double? Height { get; set; }
    }

    #endregion
    [TestClass]
    public class ModelOvveriderTests
    {
        [TestMethod]
        public void OvverideMethodTest()
        {
            const string myBabyName = "Roman";
            //Arrange 
            TestModel original = new TestModel(1, "Alex", 27, 175);
            TestModel newValues = new TestModel(name: myBabyName);
            TestModel expected = (TestModel)original.Clone();
            expected.Name = myBabyName;

            //Act
            TestModel result = ModelOvverider.Ovveride(original, newValues);
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
