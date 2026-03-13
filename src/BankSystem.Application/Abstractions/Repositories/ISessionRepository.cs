using Lab5.Domain.Entities;

namespace Lab5.Application.Abstractions.Repositories;

public interface ISessionRepository
{
    SystemSession? FindById(Guid id);

    void Add(SystemSession systemSession);
}