﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Asset.Bases;
using API_Asset.Models;
using API_Asset.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Asset.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LendsController : BasesController<Lend, LendRepository>
    {
        public LendsController(LendRepository lendRepository) : base(lendRepository)
        {

        }
    }
}