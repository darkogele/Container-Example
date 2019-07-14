﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer
{
    public class User
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public IList<UserProduct> UserProduct { get; set; }
    }
}
