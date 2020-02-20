using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateConsole.Infrastructure
{
    public abstract class BaseEntity<TId, TEntity> : IIdentifiable<TId> where TEntity : IIdentifiable<TId>
    {
        [IgnoreDataMember]
        private int? oldHashCode;

        [Key]
        [DataMember]
        public virtual TId Id { get; set; }

        public override int GetHashCode()
        {
            // Once we have a hash code we'll never change it
            if (this.oldHashCode.HasValue)
            {
                return this.oldHashCode.Value;
            }

            var thisIsTransient = object.Equals(this.Id, Guid.Empty);
            //// When this instance is transient, we use the base GetHashCode()
            //// and remember it, so an instance can NEVER change its hash code.
            if (thisIsTransient)
            {
                this.oldHashCode = base.GetHashCode();
                return this.oldHashCode.Value;
            }

            if (this.Id != null)
            {
                return this.Id.GetHashCode();
            }
            else
            {
                return int.MinValue;
            }
        }
        public virtual bool Equals(TEntity other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return object.Equals(other.Id, this.Id);
        }
        public override bool Equals(object obj)
        {
            var other = obj as BaseEntity<TId, TEntity>;
            if (other == null)
            {
                return false;
            }

            //// handle the case of comparing two NEW objects
            var otherIsTransient = object.Equals(other.Id, Guid.Empty);
            var thisIsTransient = object.Equals(this.Id, Guid.Empty);
            if (otherIsTransient && thisIsTransient)
            {
                return object.ReferenceEquals(other, this);
            }

            return other.Id.Equals(this.Id);
        }
    }
}
