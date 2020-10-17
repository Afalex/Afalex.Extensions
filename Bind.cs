using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Afalex.Extensions.Bind
{
    public static class BindExtenstions
    {
        public static IEnumerable<TEntity> ConvertToEntity<TRelation, TEntity>(IEnumerable<TRelation> relations) where TEntity : new()
        {
            string entityName = typeof(TEntity).Name.ToUpper();
            PropertyInfo[] properties = typeof(TRelation).GetProperties();
            PropertyInfo entityProp = properties.Where(t => t.PropertyType == typeof(TEntity)).FirstOrDefault();

            if (entityProp == null)
                throw new Exception("Prop not found");

            List<TEntity> entities = new List<TEntity>();

            if (relations == null) return null;

            foreach (TRelation relation in relations)
            {
                entities.Add((TEntity)entityProp.GetValue(relation));
            }
            return entities;
        }
        public static IEnumerable<TRelation>
            BindToRelationshipTable<TRelation, TInputEntity, TThisEntity>
            (TThisEntity relationObj, List<TInputEntity> inputEntities) where TRelation : new()
        {
            int? GetId<T>(T obj)
            {
                Type type = typeof(T);
                PropertyInfo propertyInfo = type.GetProperties().Where(c => c.Name.ToUpper() == "ID").FirstOrDefault();
                return (int?)propertyInfo.GetValue(obj);
            }

            PropertyInfo[] relationProperties = typeof(TRelation).GetProperties();
            PropertyInfo[] inputEnProperties = inputEntities.GetType().GetProperties();

            string inputEntityName = typeof(TInputEntity).Name.ToUpper();
            string secondEntityName = typeof(TThisEntity).Name.ToUpper();
            //find input in relation
            PropertyInfo inputEntityProp =
                relationProperties.FirstOrDefault(t => t.PropertyType == typeof(TInputEntity));

            PropertyInfo inputEntityPropId = relationProperties.FirstOrDefault(r => r.Name.ToUpper() == inputEntityName + "ID");
            inputEntityPropId = inputEntityPropId ?? relationProperties.FirstOrDefault(r => r.Name.ToUpper() == inputEntityProp.Name.ToUpper() + "ID");

            PropertyInfo secondEntityProp = relationProperties.FirstOrDefault(t => t.PropertyType == typeof(TThisEntity));
            PropertyInfo secondEntityPropID = null;
            if (secondEntityProp != null)
                secondEntityPropID = relationProperties.FirstOrDefault(r => r.Name.ToUpper() == secondEntityName.ToUpper() + "ID"
               || r.Name.ToUpper() == secondEntityProp.Name.ToUpper() + "ID");

            List<TRelation> relations = new List<TRelation>();
            foreach (TInputEntity entity in inputEntities)
            {
                TRelation relation = new TRelation();
                inputEntityProp.SetValue(relation, entity);
                inputEntityPropId?.SetValue(relation, GetId(entity));
                //set second relationship
                secondEntityProp?.SetValue(relation, relationObj);
                secondEntityPropID?.SetValue(relation, GetId(relationObj));
                relations.Add(relation);
            }
            return relations;
        }
    }
}
