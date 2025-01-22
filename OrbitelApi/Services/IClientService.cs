﻿using Microsoft.AspNetCore.Mvc;
using OrbitelApi.Models.Entities.Clients;

namespace OrbitelApi.Services;

public interface IClientService
{
   Task<List<Client>> GetAllClients();
   
   //TODO: Task<ActionResult> GetContract();
}