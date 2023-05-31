﻿using SugarShark.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Application.CatalogModule.Repositories
{
    public interface ICartRepository
    {
        Cart GetCart(int userId);
    }
}