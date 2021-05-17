using System;

namespace Foodify.Domain.Models
{
    /// <summary>
    /// Base data model
    /// </summary>
    public class BaseNameModel
    {
        /// <summary>
        /// Id of an item
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Name of an item
        /// </summary>
        public string Name { get; set; }
    }
}
