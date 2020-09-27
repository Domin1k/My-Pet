namespace MyPet.Application.Common.Contracts
{
    using System;

    public interface ICurrentUserService
    {
        Guid UserId { get; }
    }
}
