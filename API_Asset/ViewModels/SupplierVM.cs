﻿using API_Asset.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Asset.ViewModels
{
    [Table("TB_M_Supplier")]
    public class SupplierVM : BaseModel
    {
        public string Name { get; set; }
        public string Phone_Number { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
