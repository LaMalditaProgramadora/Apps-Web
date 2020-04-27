﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTodo.Model;

namespace WebApiTodo.Persistence.Config
{
    public class CountryConfig
    {
        public CountryConfig(EntityTypeBuilder<Country> entityBuilder)
        {
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);

        }
    }
}
