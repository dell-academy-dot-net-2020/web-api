using System;

namespace Dell.Academy.Domain.Models
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }

        public override bool Equals(object obj) => base.Equals(obj);

        public override int GetHashCode() => throw new NotImplementedException();
    }
}