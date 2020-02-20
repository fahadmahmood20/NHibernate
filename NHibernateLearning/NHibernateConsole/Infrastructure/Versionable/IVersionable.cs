using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateConsole.Infrastructure.Versionable
{
    public interface IVersionable
    {
        int Version { get; }
    }
}
