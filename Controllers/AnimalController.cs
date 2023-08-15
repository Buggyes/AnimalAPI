using Microsoft.AspNetCore.Mvc;

namespace AnimalAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AnimalController : ControllerBase
	{

		private static List<AnimalModel> animals = new List<AnimalModel>
		{
			new AnimalModel
			{
				Id = 1,
				Name = "Steve",
				Species = "Blue Parrot",
				Age = 2,
				Color = "Blue",
				IsDomestic = false
			},
			new AnimalModel
			{
				Id = 2,
				Name = "Muffin",
				Species = "Guinea Pig",
				Age = 1,
				Color = "Brown",
				IsDomestic = true
			},
			new AnimalModel
			{
				Id = 3,
				Name = "Mr. Stitches",
				Species = "Tarantula",
				Age = 1,
				Color = "Dark Brown",
				IsDomestic = false
			}
		};

		private static int i = animals.Count;

		[HttpGet]
		public async Task<IActionResult> GetAllAnimals()
		{
			return Ok(animals);
		}

		[HttpGet("{idRequest}")]
		public async Task<ActionResult<AnimalModel>> GetAnimalById(int idRequest)
		{
			AnimalModel animal = animals.FirstOrDefault(a => a.Id == idRequest);
			if(animal == null)
			{
				return BadRequest("Animal With Said ID Not Found");
			}
			return Ok(animal);
		}

		[HttpGet("speciesRequest/{speciesRequest}")]
		public async Task<ActionResult<AnimalModel>> GetAnimalBySpecies(string speciesRequest)
		{
			AnimalModel animal = animals.FirstOrDefault(a => a.Species == speciesRequest);
			if (animal == null)
			{
				return BadRequest("Animal With Said Species Not Found");
			}
			return Ok(animal);
		}

		[HttpGet("isDomesticRequest/{isDomesticRequest}")]
		public async Task<ActionResult<AnimalModel>> GetAnimalByDomesticity(bool isDomesticRequest)
		{
			List<AnimalModel> animalsRequest = new List<AnimalModel>();
			for (int i = 0; i < animals.Count; i++)
			{
                if (animals[i].IsDomestic == isDomesticRequest)
                {
					animalsRequest.Add(animals[i]);
                }
            }
			if (animalsRequest.Count == 0)
			{
				return BadRequest("Animal With Said Domesticity Not Found");
			}
			return Ok(animalsRequest);
		}

		[HttpPost]
		public async Task<ActionResult<List<AnimalModel>>> AddAnimal(AnimalModel request)
		{
			i++;
			request.Id = i;
			animals.Add(request);
			return Ok(request);
		}

		[HttpPatch]
		public async Task<ActionResult<List<AnimalModel>>> UpdateAnimal(AnimalModel request)
		{
			AnimalModel target = animals.FirstOrDefault(a => a.Id == request.Id);
			if (request == null)
			{
				return BadRequest("Animal With Said ID Not Found");
			}
			for (int i = 0; i < animals.Count; i++)
			{
				if (animals[i].Id == request.Id)
				{
					animals[i] = request;
					break;
				}
			}
			return Ok(animals);
		}

		[HttpDelete("{idRequest}")]
		public async Task<ActionResult<AnimalModel>> DeleteAnimal(int idRequest)
		{
			AnimalModel animal = animals.FirstOrDefault(a => a.Id == idRequest);
			if (animal == null)
			{
				return BadRequest("Animal With Said ID Not Found");
			}
			animals.Remove(animal);
			return Ok(animal);
		}
	}
}