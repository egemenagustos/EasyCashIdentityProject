﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos
{
    public class AppUserRegisterDto
    {
        public string Name { get; set; }

        public string SurName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Passoword { get; set; }

        public string ConfirmPassoword { get; set; }
    }
}
