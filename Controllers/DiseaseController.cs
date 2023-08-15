using AnimalAPI.Models;

using Microsoft.AspNetCore.Mvc;

namespace AnimalAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DiseaseController : ControllerBase
	{
		private static List<DiseaseModel> diseases = new List<DiseaseModel>
		{
			new DiseaseModel
			{
				Id = 1,
				Name = "Common Cold",
				Agent = "Virus",
				Symptoms =
				{
					"cough",
					"runny nose",
					"sore throat",
					"nasal congestion",
					"sneezing",
					"muscle ache",
					"fatigue",
					"headache",
					"loss of appetite",
					"fever"
				},
				Treatment =
				{
					"symptomatic therapy",
					"zinc"
				},
				Frequency = "2-3 times per year per person",
				IsContagious = true
			},
			new DiseaseModel
			{
				Id = 2,
				Name = "Lung Cancer",
				Agent = "Mutagen",
				Symptoms =
				{
					"cough",
					"shortness of breath",
					"chest pain"
				},
				Treatment =
				{
					"surgery",
					"chemotherapy",
					"radiotherapy",
					"molecular therapies",
					"immune checkpoint inhibitors"
				},
				Frequency = "2.2 million (2020)",
				IsContagious = false
			},
			new DiseaseModel
			{
				Id = 3,
				Name = "Leprosy",
				Agent = "Bacteria",
				Symptoms =
				{
					"decreased ability to feel pain",
					"muscle weakness",
					"decreased eyesight"
				},
				Treatment =
				{
					"multidrug therapy"
				},
				Frequency = "209,000 (2018)",
				IsContagious = true
			}
		};

		private static int i = diseases.Count;

		[HttpGet]
		public async Task<IActionResult> GetAllDiseases()
		{
			return Ok(diseases);
		}

		[HttpGet("{idRequest}")]
		public async Task<ActionResult<DiseaseModel>> GetDiseaseById(int idRequest)
		{
			DiseaseModel disease = diseases.FirstOrDefault(a => a.Id == idRequest);
			if (disease == null)
			{
				return BadRequest("Disease With Said ID Not Found");
			}
			return Ok(disease);
		}

		[HttpGet("agentRequest/{agentRequest}")]
		public async Task<ActionResult<DiseaseModel>> GetDiseaseByAgent(string agentRequest)
		{
			DiseaseModel disease = diseases.FirstOrDefault(a => a.Agent == agentRequest);
			if (disease == null)
			{
				return BadRequest("Disease With Said Agent Not Found");
			}
			return Ok(disease);
		}

		[HttpGet("GetAllContagiousDiseases")]
		public async Task<ActionResult<DiseaseModel>> GetAllContagiousDiseases()
		{
			List<DiseaseModel> diseasesRequest = new List<DiseaseModel>();
			for (int i = 0; i < diseases.Count; i++)
			{
				if (diseases[i].IsContagious == true)
				{
					diseasesRequest.Add(diseases[i]);
				}
			}
			if (diseasesRequest.Count == 0)
			{
				return BadRequest("Contageous Disease Not Found");
			}
			return Ok(diseasesRequest);
		}

		[HttpPost]
		public async Task<ActionResult<List<DiseaseModel>>> AddDisease(DiseaseModel request)
		{
			i++;
			request.Id = i;
			diseases.Add(request);
			return Ok(request);
		}

		[HttpPatch]
		public async Task<ActionResult<List<DiseaseModel>>> UpdateDisease(DiseaseModel request)
		{
			DiseaseModel target = diseases.FirstOrDefault(a => a.Id == request.Id);
			if (request == null)
			{
				return BadRequest("Disease With Said ID Not Found");
			}
			for (int i = 0; i < diseases.Count; i++)
			{
				if (diseases[i].Id == request.Id)
				{
					diseases[i] = request;
					break;
				}
			}
			return Ok(diseases);
		}

		[HttpDelete("{idRequest}")]
		public async Task<ActionResult<DiseaseModel>> DeleteDisease(int idRequest)
		{
			DiseaseModel disease = diseases.FirstOrDefault(a => a.Id == idRequest);
			if (disease == null)
			{
				return BadRequest("Disease With Said ID Not Found");
			}
			diseases.Remove(disease);
			return Ok(disease);
		}
	}
}
