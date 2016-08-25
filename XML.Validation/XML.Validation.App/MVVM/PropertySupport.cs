using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace XML.Validation.App.MVVM
{
    [ExcludeFromCodeCoverage]
    public static class PropertySupport
    {
        public static string GetPropertyName<TProperty>(Expression<Func<TProperty>> property)
        {
            var lambda = (LambdaExpression)property;
            MemberExpression memberExpression;

            if (lambda.Body is UnaryExpression)
            {
                var unaryExpression = (UnaryExpression)lambda.Body;
                memberExpression = (MemberExpression)unaryExpression.Operand;
            }
            else
                memberExpression = (MemberExpression)lambda.Body;

            return memberExpression.Member.Name;
        }

        public static string GetPropertyName<T>(Expression<Func<T, object>> propertyExpression)
        {
            MemberExpression member;
            var body = propertyExpression.Body as MemberExpression;
            if (body != null)
            {
                // This version copes with properties that are reference types
                member = body;
            }
            else
            {
                // This version copes with properties that are value types
                member = (MemberExpression)((UnaryExpression)propertyExpression.Body).Operand;
            }
            return member.Member.Name;
        }
    }
}
