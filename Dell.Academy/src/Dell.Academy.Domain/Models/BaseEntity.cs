using System;

namespace Dell.Academy.Domain.Models
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }

        public override bool Equals(object obj) => obj is BaseEntity entity && entity.Id == Id;

        public override int GetHashCode() => HashCode.Combine(Id);
    }
}