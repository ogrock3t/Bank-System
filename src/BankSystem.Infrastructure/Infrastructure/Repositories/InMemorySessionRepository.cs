using Lab5.Application.Abstractions.Repositories;
using Lab5.Domain.Entities;

namespace Lab5.Infrastructure.Persistence.Repositories;

public class InMemorySessionRepository : ISessionRepository
{
    private readonly Dictionary<Guid, SystemSession> _sessions = new Dictionary<Guid, SystemSession>();

    public SystemSession? FindById(Guid id)
    {
        _sessions.TryGetValue(id, out SystemSession? session);

        return session;
    }

    public void Add(SystemSession systemSession)
    {
        _sessions.Add(systemSession.SessionId, systemSession);
    }
}