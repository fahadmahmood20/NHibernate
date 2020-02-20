using NHibernateConsole.Infrastructure.Versionable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateConsole.Infrastructure
{
    [Serializable]
    [DataContract(Name = "VersionableEntity")]
    public abstract class VersionableEntity<TId, TEntity> : BaseEntity<TId, TEntity>, IVersionable where TEntity : IIdentifiable<TId>
    {
        [DataMember]
        private int version = 0;

        [IgnoreDataMember]
        public virtual int Version
        {
            get
            {
                return this.version;
            }
        }
    }
}
