using Microsoft.EntityFrameworkCore;
using PartnerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartnerAPI.Repositories
{
    public class PartnerRepository : IPartnerService
    {
        private readonly ApplicationContext _context;

        public PartnerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Partner> Get(string name)
        {
            var partners = await _context.Partner.AsNoTracking().AsQueryable().Include(m => m.TimeSlots).ToListAsync();
            var searchedPartner = partners.Where(p => p.Name == name).FirstOrDefault();

            return searchedPartner;
        }  
    }
}
