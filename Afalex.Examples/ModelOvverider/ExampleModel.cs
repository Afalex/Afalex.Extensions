using System;
using System.Collections.Generic;
using System.Text;

namespace Afalex.Examples.ModelOvverider
{
#pragma warning disable CS0659 // Object.GetHashCode()
    public class ExampleModel : ICloneable
#pragma warning restore CS0659 //  Object.GetHashCode()
    {
        public override bool Equals(object obj)
        {
            if (obj is ExampleModel model)
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

        public ExampleModel(int? id = null, string name = null, int? age = null, double? height = null)
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
}
