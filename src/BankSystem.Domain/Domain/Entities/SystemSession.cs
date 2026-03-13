using Lab5.Domain.Entities.Type;

namespace Lab5.Domain.Entities;

public class SystemSession
{
    public SystemSession(Guid? accountId, SessionType type)
    {
        SessionId = Guid.NewGuid();
        StartSession = DateTime.UtcNow;
        AccountId = accountId;
        Type = type;
    }

    public Guid SessionId { get; private set; }

    public SessionType Type { get; private set; }

    public Guid? AccountId { get; private set; }

    public DateTime StartSession { get; private set; }
}