﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkOutAppApi.Client.Contracts
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> Get(string url, int id);
        Task<List<T>> Get(string url);
        Task<bool> Create(string url, T obj);
        Task<bool> Update(string url, T obj);
        Task<bool> Delete(string url, int id);
        Task<T> PostAndGet(string url, T obj);
    }
}
