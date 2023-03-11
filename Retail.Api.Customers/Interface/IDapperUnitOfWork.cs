﻿using Retail.Api.Customers.Repositories;

namespace Retail.Api.Customers.Interface
{
    /// <summary>
    /// Interface definition for unit of work.
    /// </summary>
    public interface IDapperUnitOfWork
    {
        /// <summary>
        /// Gets or sets customer repository.
        /// </summary>
        ICustomerDapperRepository CustomerDapperRepository { get; }
    }
}