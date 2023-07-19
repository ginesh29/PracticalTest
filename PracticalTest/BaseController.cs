using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PracticalTest
{
    public class BaseController : Controller
    {
        protected readonly ApplicationDbContext _context;
        protected readonly IMapper _mapper;
        public BaseController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
