using System;

namespace Entities.Contracts
{
    /// <summary>
    /// It is an interface to get shared attributes of entity
    /// </summary>
    public interface IAuditableEntity
    {
        string CreatedBy { get; set; }

        DateTime CreatedOn { get; set; }

        string LastModifiedBy { get; set; }

        DateTime? LastModifiedOn { get; set; }
    }
}
