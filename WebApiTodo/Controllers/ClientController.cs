﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTodo.Commons;
using WebApiTodo.Dto;
using WebApiTodo.Model;
using WebApiTodo.Service;

namespace WebApiTodo.Controllers
{
    [ApiController]
    [Route("clients")]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;

        public ClientController(ClientService ClientService)
        {
            _clientService = ClientService;
        }

        [HttpGet]
        public ActionResult<DataCollection<ClientDto>> GetAll(int page, int take=20)
        {
            return _clientService.GetAll(page, take);
        }
        /*
          [HttpGet]
          public ActionResult<List<ClientDto>> GetAll()
          {
              return _clientService.GetAll();
          }
          */
        [HttpGet("{id}")]
        public ActionResult<ClientDto> GetById(int id)
        {
            return _clientService.GetById(id);
        }

        [HttpPost]
        public ActionResult Create(ClientCreateDto model)
        {
            var result = _clientService.Create(model);

            return CreatedAtAction(
                "GetById",
                new { id = result.ClientId },
                result
            );
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, ClientUpdateDto model)
        {
            _clientService.Update(id, model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            _clientService.Remove(id);
            return NoContent();
        }

    }
}
