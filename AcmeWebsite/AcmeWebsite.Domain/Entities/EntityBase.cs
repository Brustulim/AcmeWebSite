using System;

namespace AcmeWebsite.Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
