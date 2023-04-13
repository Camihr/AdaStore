﻿using AdaStore.Shared.Models;
using AdaStore.UI.Repositories;

namespace AdaStore.UI.Interfaces
{
    public interface IUsersRepository
    {
        Task<RegisterResponse> RegisterUser(User userRequest);
    }
}
