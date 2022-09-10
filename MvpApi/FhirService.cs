using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Serialization;


namespace MvpApi
{
    public static class FhirService
    {

        private const string FhirServer = "http://vonk.fire.ly";

        public static async Task<List<Encounter>> GetEncounter(string id){
            var client = new FhirClient(FhirServer){
                PreferredFormat = ResourceFormat.Json,
                PreferredReturn = Prefer.ReturnRepresentation
            };


            var result = await client.SearchAsync<Encounter>(null);

         
            var encounters = new List<Encounter>();
            foreach (var item in result.Entry)
            {
                var encounter = item.Resource as Encounter;
                encounter.Id = id;
                encounters.Add(encounter);
            }
            return encounters;
        }

    }
}