﻿using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyMvcApp.Data.Interfaces
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        T? GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

