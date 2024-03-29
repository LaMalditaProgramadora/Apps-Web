﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTodo.Model;

namespace WebApiTodo.Persistence.Config
{
    public class ClientConfig
    {
        public ClientConfig(EntityTypeBuilder<Client> entityBuilder)
        {
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.ClientNumber).IsRequired().HasMaxLength(30);

            entityBuilder.HasOne(x => x.Country)
                .WithMany(x => x.Clients)
                .HasForeignKey(x => x.CountryId);

        }
    }
}


