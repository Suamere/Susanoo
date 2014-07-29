﻿namespace Susanoo
{
    /// <summary>
    /// A fully built and ready to be executed command expression with a filter parameter.
    /// </summary>
    /// <typeparam name="TFilter">The type of the filter.</typeparam>
    public class NoResultSetCommandProcessor<TFilter> : ICommandProcessor<TFilter>, IFluentPipelineFragment
    {
        private readonly ICommandExpression<TFilter> _CommandExpression;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoResultSetCommandProcessor{TFilter}"/> class.
        /// </summary>
        /// <param name="command">The command.</param>
        public NoResultSetCommandProcessor(ICommandExpression<TFilter> command)
        {
            this._CommandExpression = command;
        }

        /// <summary>
        /// Gets the command expression.
        /// </summary>
        /// <value>The command expression.</value>
        public ICommandExpression<TFilter> CommandExpression
        {
            get { return _CommandExpression; }
        }

        /// <summary>
        /// Gets the hash code used for caching result mapping compilations.
        /// </summary>
        /// <value>The cache hash.</value>
        public System.Numerics.BigInteger CacheHash
        {
            get { return _CommandExpression.CacheHash; }
        }

        public TReturn ExecuteScalar<TReturn>(IDatabaseManager databaseManager, TFilter filter, params System.Data.IDbDataParameter[] explicitParameters)
        {
            return databaseManager.ExecuteScalar<TReturn>(
                CommandExpression.CommandText,
                CommandExpression.DBCommandType,
                CommandExpression.BuildParameters(databaseManager, filter, explicitParameters));
        }

        public TReturn ExecuteScalar<TReturn>(IDatabaseManager databaseManager, params System.Data.IDbDataParameter[] explicitParameters)
        {
            return ExecuteScalar<TReturn>(databaseManager, default(TFilter), explicitParameters);
        }

        public int ExecuteNonQuery(IDatabaseManager databaseManager, TFilter filter, params System.Data.IDbDataParameter[] explicitParameters)
        {
            return databaseManager.ExecuteStoredProcedureNonQuery(
                CommandExpression.CommandText,
                CommandExpression.DBCommandType,
                CommandExpression.BuildParameters(databaseManager, filter, explicitParameters));
        }

        public int ExecuteNonQuery(IDatabaseManager databaseManager, params System.Data.IDbDataParameter[] explicitParameters)
        {
            return ExecuteNonQuery(databaseManager, default(TFilter), explicitParameters);
        }
    }
}