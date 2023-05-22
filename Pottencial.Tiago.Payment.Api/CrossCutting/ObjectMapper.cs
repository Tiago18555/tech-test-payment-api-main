﻿using System.ComponentModel;
using System.Dynamic;
using System.Reflection;

namespace Pottencial.Tiago.Payment.Api.CrossCutting
{
    public static class ObjectMapper
    {
        public static TResult MapObjectTo<TSource, TResult>(this TSource objFrom, TResult objTo)
        {

            PropertyInfo[] ToProperties = objTo.GetType().GetProperties();
            PropertyInfo[] FromProperties = objFrom.GetType().GetProperties();

            ToProperties.ToList().ForEach(objToProp =>
            {
                PropertyInfo FromProp = FromProperties.FirstOrDefault(objFromProp =>
                    objFromProp.Name == objToProp.Name && objFromProp.PropertyType == objToProp.PropertyType
                );

                if (FromProp != null) objToProp.SetValue(objTo, FromProp.GetValue(objFrom));

            });
            return objTo;
        }

        public static dynamic MapObjectToDynamic(this object value)
        {
            IDictionary<string, object> expando = new ExpandoObject();

            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(value.GetType()))
                expando.Add(property.Name, property.GetValue(value));

            return expando as ExpandoObject;
        }
    }
}
