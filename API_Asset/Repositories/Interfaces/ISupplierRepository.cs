﻿using API_Asset.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asset.Repositories.Interfaces
{
    public interface ISupplierRepository
    {
        IQueryable<Supplier> Get();

        Supplier Get(int Id);

        int Post(Supplier supplier);

        int Put(int Id, Supplier supplier);

        bool Delete(int Id);
    }
}