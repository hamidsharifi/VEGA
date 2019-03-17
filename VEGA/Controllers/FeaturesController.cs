using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VEGA.Controllers.Resources;
using VEGA.Models;
using VEGA.Persistance;

namespace VEGA.Controllers
{
    public class FeaturesController : Controller
    {
        private readonly VegaDbContext _context;
        private readonly IMapper _mapper;

        public FeaturesController(VegaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("/api/Features")]
        public async Task<IEnumerable<KeyValuePairResource>> GetFeatures()
        {
            var resources = await _context.Features.ToListAsync();
            return _mapper.Map<List<Feature>, List<KeyValuePairResource>>(resources);
        }
    }
}