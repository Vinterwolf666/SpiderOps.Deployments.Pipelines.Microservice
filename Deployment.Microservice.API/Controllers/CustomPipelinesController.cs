using Deployment.Microservice.APP;
using Deployment.Microservice.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Deployment.Microservice.API.Controllers
{
    [ApiController]
    [Route("Deployment.Microservice.API")]
    public class CustomPipelinesController : Controller
    {
        private readonly ICustomPipelinesServices _customPipelinesServices;
        public CustomPipelinesController(ICustomPipelinesServices c)
        {
            _customPipelinesServices = c;
        }

        [HttpGet]
        [Route("UpdatePipelineAndDownload")]
        public async Task<ActionResult> UpdatePipelineAndDownload(int customer_id, int template_id, string cluster_name, string ArtifactRegistry, string REGION, string APP_NAME)
        {
            try
            {
                var result = await _customPipelinesServices.UpdatePipeline(customer_id, template_id, cluster_name, ArtifactRegistry, REGION, APP_NAME);

                return result;



            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet]
        [Route("dropGithub")]
        public async Task<ActionResult<List<object>>> DropGitHub()
        {
            try
            {
                var result = await _customPipelinesServices.dropGitHub();

                return result;



            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("Secrets")]
        public async Task<ActionResult<List<object>>> DropSecrets()
        {
            try
            {
                var result = await _customPipelinesServices.dropSecrets();

                return result;



            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
