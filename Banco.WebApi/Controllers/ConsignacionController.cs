using Banco.Application;
using Banco.Domain.Contracts;
using Banco.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsignacionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConsignacionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }

        [HttpPost]
        public ConsignarResponse Post(ConsignarCommand command)
        {
            var service = new ConsignarCommandHandle(_unitOfWork);
            var response = service.Handle(command);
            return response;
        }
    }
}
