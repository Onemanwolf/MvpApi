using Hl7.Fhir.Model;
using Microsoft.AspNetCore.Mvc;

namespace MvpApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EncounterController : ControllerBase
{


    private readonly ILogger<EncounterController> _logger;

    public EncounterController(ILogger<EncounterController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "Encounter/{id}")]
    public ActionResult<List<Encounter>> Get(string id)
    {
      var encounters =  FhirService.GetEncounter(id);
        return encounters.Result;


    }
}
