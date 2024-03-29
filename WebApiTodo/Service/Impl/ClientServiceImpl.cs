﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTodo.Commons;
using WebApiTodo.Dto;
using WebApiTodo.Model;
using WebApiTodo.Persistence;

namespace WebApiTodo.Service.Impl
{
    public class ClientServiceImpl : ClientService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ClientServiceImpl(ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /*public List<ClientDto> GetAll()
        {
            return _mapper.Map<List<ClientDto>>(
                 _context.Clients
                 .Include(x => x.Country)
                 .OrderByDescending(x => x.ClientId)
                              .AsQueryable()
                              .ToList()
            );
        }
        */
        public DataCollection<ClientDto> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<ClientDto>>(
            _context.Clients.Include(x => x.Country)
                .OrderByDescending(x => x.ClientId)
                .AsQueryable()
                .Paged(page, take)
            );
        }
        

        public ClientDto GetById(int id)
        {
            return _mapper.Map<ClientDto>(
                 _context.Clients.Single(x => x.ClientId == id)
            );
        }

        //Agregado
        public ClientDto Create(ClientCreateDto model)
        {
            var entry = new Client
            {
                Name = model.Name,
                ClientNumber = model.ClientNumber,
                CountryId = model.CountryId
            };

            _context.Add(entry);
            _context.SaveChanges();

            return _mapper.Map<ClientDto>(entry);
        }

        public void Update(int id, ClientUpdateDto model)
        {
            var entry = _context.Clients.Single(x => x.ClientId == id);
            entry.Name = model.Name;

            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            _context.Remove(new Client
            {
                ClientId = id
            });

            _context.SaveChanges();
        }
    }
}
