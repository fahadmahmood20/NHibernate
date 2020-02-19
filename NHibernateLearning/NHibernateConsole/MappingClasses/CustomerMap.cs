using FluentNHibernate.Mapping;
using NHibernateConsole.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateConsole.MappingClasses
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(c => c.Id);
            Map(c => c.FirstName).Not.Nullable();
            Map(c => c.MiddleName);
            Map(c => c.LastName).Not.Nullable();
        }
    }
}
