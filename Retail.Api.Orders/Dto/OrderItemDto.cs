﻿// <copyright file="Customer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Retail.Api.Orders.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines Order item entity.
    /// </summary>
    public class LineItemDto
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the Order Id.
        /// </summary>
        public long OrderId { get; set; }

        /// <summary>
        /// Gets or sets the Sku Id.
        /// </summary>
        public long SkuId { get; set; }

        /// <summary>
        /// Gets or sets the Qty.
        /// </summary>
        public int Qty { get; set; }
    }
}