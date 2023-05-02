﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.EntityLayer.Concrete
{
    public class CustomerAccount
    {
        public int Id { get; set; }

        public string CustomerAccountNumber { get; set; }

        public string CustomerAccountCurrency { get; set; }

        public decimal CustomerAccountAccountBalance { get; set; }

        public string CustomerAccountBankBranch { get; set; }


    }
}