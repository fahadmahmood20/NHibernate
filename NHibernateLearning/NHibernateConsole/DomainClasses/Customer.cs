using NHibernateConsole.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateConsole.DomainClasses
{
    [Serializable]
    [DataContract(Name = "Customer")]
    public class Customer : VersionableEntity<string, Customer>
    {
        ////public virtual int Id { get; set; }
        [DataMember]
        public virtual string FirstName { get; set; }
        [DataMember]
        public virtual string MiddleName { get; set; }
        [DataMember]
        public virtual string LastName { get; set; }
    }
}
