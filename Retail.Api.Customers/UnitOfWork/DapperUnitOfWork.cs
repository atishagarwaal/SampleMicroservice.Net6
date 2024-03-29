﻿using Dapper;
using Microsoft.EntityFrameworkCore.Storage;
using Retail.Api.Customers.Data;
using Retail.Api.Customers.DefaultInterface;
using Retail.Api.Customers.DefaultRepositories;
using Retail.Api.Customers.Interface;
using Retail.Api.Customers.Model;
using Retail.Api.Customers.Repositories;
using System.Data;

namespace Retail.Api.Customers.UnitOfWork
{
    /// <summary>
    /// Unit of work class.
    /// </summary>
    public class DapperUnitOfWork : IUnitOfWork
    {
        private readonly DapperContext _dapperContext;
        private IDbConnection? _connection;
        private IDbTransaction? _transaction;
        private IRepository<Customer>? _customerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="dapperContext">Dapper Db context.</param>
        public DapperUnitOfWork(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        /// <summary>
        /// Gets or sets connection.
        /// </summary>
        private IDbConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = _dapperContext.CreateConnection();
                }

                return _connection;
            }
        }

        /// <summary>
        /// Gets or sets customer repository.
        /// </summary>
        public IRepository<Customer> CustomerRepository
        {
            get
            {
                if (_customerRepository == null)
                {
                    _customerRepository = new CustomerDapperRepository(_dapperContext);
                }

                return _customerRepository;
            }
        }

        /// <summary>
        /// Method to begin transaction.
        /// </summary>
        public void BeginTransaction()
        {
            _transaction = _connection?.BeginTransaction();
        }

        /// <summary>
        /// Method to commit changes.
        /// </summary>
        public void Commit()
        {
            _transaction?.Commit();
        }

        /// <summary>
        /// Method to rollback changes.
        /// </summary>
        public void Rollback()
        {
            _transaction?.Rollback();
            _transaction?.Dispose();
            _connection?.Dispose();
        }
    }
}