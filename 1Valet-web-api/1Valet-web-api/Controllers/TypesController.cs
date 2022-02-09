using _1Valet_web_api.DomainModels;
using _1Valet_web_api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace _1Valet_web_api.Controllers
{
    //We need to inject the Type repository 

    [ApiController]
    public class TypesController : Controller
    {

        private readonly ITypeRepository typeRepository;
        public TypesController(ITypeRepository typeRepository)
        {
            this.typeRepository = typeRepository;
        }

        [HttpGet]
        [Route("[controller]")]
        public IActionResult GetAllTypes()
        {
            var types = typeRepository.GetTypes();
            var domainModelsTypes = new List<Type>();

            foreach (var type in types)
            {
                domainModelsTypes.Add(new Type()
                {
                    Id = type.Id,
                    Name = type.Name,
                    Description = type.Description
                }) ;
            }

            return Ok(domainModelsTypes);

        }
    }
}
