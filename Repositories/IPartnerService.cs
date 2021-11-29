using PartnerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartnerAPI.Repositories
{
    public interface IPartnerService
    {
        Task<Partner> Get(string name);
    }
}
