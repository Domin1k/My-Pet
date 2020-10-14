﻿namespace MyPet.Application.Contracts
{
    using System;

    public interface ICurrentUserService
    {
        Guid UserId { get; }

        string Email { get; }
    }
}
