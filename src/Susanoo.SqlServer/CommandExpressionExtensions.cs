﻿using System;
using System.Data.Common;
using System.Linq.Expressions;
using Susanoo.Pipeline.Command;
using Susanoo.SqlServer;

namespace Susanoo
{
    /// <summary>
    /// Extension methods for SQL Server
    /// </summary>
    public static class CommandExpressionExtensions
    {
        /// <summary>
        /// Includes the property as structured data type (Table Valued Parameter).
        /// </summary>
        /// <typeparam name="TFilter">The type of the t filter.</typeparam>
        /// <param name="commandExpression">The command expression.</param>
        /// <param name="property">The property.</param>
        /// <param name="typeName">Name of the type.</param>
        /// <returns>ICommandExpression&lt;TFilter&gt;.</returns>
        public static ICommandExpression<TFilter> IncludePropertyAsStructured<TFilter>(
            this ICommandExpression<TFilter> commandExpression, Expression<Func<TFilter, object>> property, string typeName)
        {
            return IncludePropertyAsStructured(commandExpression, property.Name, typeName);
        }

        /// <summary>
        /// Includes the property as structured data type (Table Valued Parameter).
        /// </summary>
        /// <typeparam name="TFilter">The type of the t filter.</typeparam>
        /// <param name="commandExpression">The command expression.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="typeName">Name of the type.</param>
        /// <returns>ICommandExpression&lt;TFilter&gt;.</returns>
        public static ICommandExpression<TFilter> IncludePropertyAsStructured<TFilter>(
            this ICommandExpression<TFilter> commandExpression, string propertyName, string typeName)
        {
            commandExpression.IncludeProperty(propertyName,
                parameter => parameter.MakeTableValuedParameter(propertyName, typeName));

            return commandExpression;
        }

        /// <summary>
        /// Includes the property as structured data type (Table Valued Parameter).
        /// </summary>
        /// <typeparam name="TFilter">The type of the t filter.</typeparam>
        /// <param name="commandExpression">The command expression.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="typeName">Name of the type.</param>
        /// <param name="parameterOptions">The parameter options.</param>
        /// <returns>ICommandExpression&lt;TFilter&gt;.</returns>
        public static ICommandExpression<TFilter> IncludePropertyAsStructured<TFilter>(
            this ICommandExpression<TFilter> commandExpression, string propertyName, string typeName, Action<DbParameter> parameterOptions)
        {

            if (parameterOptions != null)
            {
                commandExpression.IncludeProperty(propertyName,
                    CombineActions(parameter => parameter.MakeTableValuedParameter(propertyName, typeName), parameterOptions));
            }
            else
            {
                commandExpression.IncludeProperty(propertyName,
                parameter => parameter.MakeTableValuedParameter(propertyName, typeName));
            }

            return commandExpression;
        }


        /// <summary>
        /// Includes the property as structured data type (Table Valued Parameter).
        /// </summary>
        /// <typeparam name="TFilter">The type of the t filter.</typeparam>
        /// <param name="commandExpression">The command expression.</param>
        /// <param name="property">The property.</param>
        /// <param name="typeName">Name of the type.</param>
        /// <param name="parameterOptions">The parameter options.</param>
        /// <returns>ICommandExpression&lt;TFilter&gt;.</returns>
        public static ICommandExpression<TFilter> IncludePropertyAsStructured<TFilter>(
            this ICommandExpression<TFilter> commandExpression, Expression<Func<TFilter, object>> property, string typeName, Action<DbParameter> parameterOptions)
        {
            return IncludePropertyAsStructured(commandExpression, property.Name, typeName, parameterOptions);
        }


        /// <summary>
        /// Combines two actions.
        /// </summary>
        /// <param name="arg0">The arg0.</param>
        /// <param name="arg1">The arg1.</param>
        /// <returns>Action&lt;DbParameter&gt;.</returns>
        internal static Action<DbParameter> CombineActions(Action<DbParameter> arg0, Action<DbParameter> arg1)
        {
            return arg0 + arg1;
        }


    }
}
