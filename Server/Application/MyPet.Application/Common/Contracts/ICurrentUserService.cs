namespace MyPet.Application.Common.Contracts
{
    using System;

    public interface ICurrentUserService
    {
        string UserId { get; }
    }
}
