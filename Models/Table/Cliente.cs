﻿using System;
using System.Collections.Generic;

#nullable disable

namespace eCommerce.Models.Table
{
    public partial class Cliente
    {
        public int IdPessoa { get; set; }
        public bool IsPreferencial { get; set; }

        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
