﻿using DatabaseBootstrap.Repositories;
using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBootstrap.IRepositories
{
    public interface IVrstaPostupkaRepository : IBasicRepository<VrstaPostupka>
    {
        List<VrstaPostupka> DohvatiPostupkeVeterinara(int idVeterinar);
    }
}
