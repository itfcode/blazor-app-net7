using System.Linq.Expressions;

namespace ITFCode.Core.Service.Extensions
{
    internal static class ExpressionsCombinerExtensions
    {
        #region Public Methods 

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> exp, Expression<Func<T, bool>> newExp)
        {
            return Combine(exp, newExp, Expression.Or);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> exp, Expression<Func<T, bool>> newExp)
        {
            return Combine(exp, newExp, Expression.And);
        }

        #endregion

        #region Private Methods 

        private static Expression<Func<T, bool>> Combine<T>(Expression<Func<T, bool>> exp, Expression<Func<T, bool>> newExp,
            Func<Expression, Expression, BinaryExpression> combiner)
        {
            var visitor = new ParameterUpdateVisitor(newExp.Parameters.First(), exp.Parameters.First());
            newExp = visitor.Visit(newExp) as Expression<Func<T, bool>>;

            var binExp = combiner(exp.Body, newExp.Body);
            return Expression.Lambda<Func<T, bool>>(binExp, newExp.Parameters);
        }

        #endregion

        #region Internal Helping Class

        private class ParameterUpdateVisitor : ExpressionVisitor
        {
            #region Private Fields 

            private ParameterExpression _oldParameter;
            private ParameterExpression _newParameter;

            #endregion

            #region Constructors 

            public ParameterUpdateVisitor(ParameterExpression oldParameter, ParameterExpression newParameter)
            {
                _oldParameter = oldParameter;
                _newParameter = newParameter;
            }

            #endregion

            #region Protected Override Methods 

            protected override Expression VisitParameter(ParameterExpression node)
            {
                return ReferenceEquals(node, _oldParameter) ? _newParameter : base.VisitParameter(node);
            }

            #endregion
        }

        #endregion
    }

}
