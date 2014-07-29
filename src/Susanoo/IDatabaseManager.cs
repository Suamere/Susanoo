﻿using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Susanoo
{
    /// <summary>
    /// The interface a Data later abstraction must support for use with Susanoo
    /// </summary>
    public interface IDatabaseManager
    {
        /// <summary>
        /// Executes the data reader.
        /// </summary>
        /// <param name="commandText">Name of the procedure.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>IDataReader.</returns>
        IDataReader ExecuteDataReader(string commandText, CommandType commandType, DbTransaction transaction, params DbParameter[] parameters);

        /// <summary>
        /// Executes the data reader.
        /// </summary>
        /// <param name="commandText">Name of the procedure.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>IDataReader.</returns>
        IDataReader ExecuteDataReader(string commandText, CommandType commandType, params DbParameter[] parameters);

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandText">Name of the procedure.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>T.</returns>
        T ExecuteScalar<T>(string commandText, CommandType commandType, DbTransaction transaction, params DbParameter[] parameters);

        /// <summary>
        /// Executes the scalar action asynchronously.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandText">The command text.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> ExecuteScalarAsync<T>(string commandText, CommandType commandType, DbTransaction transaction, CancellationToken cancellationToken, params DbParameter[] parameters);

        /// <summary>
        /// Executes the scalar action asynchronously.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandText">The command text.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> ExecuteScalarAsync<T>(string commandText, CommandType commandType, CancellationToken cancellationToken, params DbParameter[] parameters);

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandText">Name of the procedure.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>T.</returns>
        T ExecuteScalar<T>(string commandText, CommandType commandType, params DbParameter[] parameters);

        /// <summary>
        /// Executes the stored procedure non query.
        /// </summary>
        /// <param name="commandText">Name of the procedure.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="transaction">The transaction.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>System.Int32.</returns>
        int ExecuteStoredProcedureNonQuery(string commandText, CommandType commandType, DbTransaction transaction, params DbParameter[] parameters);

        /// <summary>
        /// Executes the stored procedure non query.
        /// </summary>
        /// <param name="commandText">Name of the procedure.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>System.Int32.</returns>
        int ExecuteStoredProcedureNonQuery(string commandText, CommandType commandType, params DbParameter[] parameters);

        /// <summary>
        /// Creates a parameter.
        /// </summary>
        /// <returns>DbParameter.</returns>
        DbParameter CreateParameter();

        /// <summary>
        /// Begins a transaction.
        /// </summary>
        /// <returns>DbTransaction.</returns>
        DbTransaction BeginTransaction();

        /// <summary>
        /// Creates the parameter.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="parameterDirection">The parameter direction.</param>
        /// <param name="parameterType">Type of the parameter.</param>
        /// <param name="value">The value.</param>
        /// <returns>DbParameter.</returns>
        DbParameter CreateParameter(string parameterName, ParameterDirection parameterDirection, DbType parameterType, object value);

        /// <summary>
        /// Creates the input parameter.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="parameterType">Type of the parameter.</param>
        /// <param name="value">The value.</param>
        /// <returns>DbParameter.</returns>
        DbParameter CreateInputParameter(string parameterName, DbType parameterType, object value);
    }
}