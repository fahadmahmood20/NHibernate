namespace NHibernateConsole.Infrastructure
{
    public interface IIdentifiable<TId> : IDatabaseEntity
    {
        TId Id { get; set; }
    }
}
