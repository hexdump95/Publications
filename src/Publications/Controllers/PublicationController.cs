using Microsoft.AspNetCore.Mvc;
using Publications.Entities;
using Publications.Services;

namespace Publications.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PublicationController : ControllerBase
{
    private readonly ILogger<PublicationController> _logger;
    private readonly IPublicationService _publicationService;

    public PublicationController(ILogger<PublicationController> logger, IPublicationService publicationService)
    {
        _logger = logger;
        _publicationService = publicationService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Publication>>> GetAllPublications()
    {
        _logger.LogInformation("Request to get all Publications");
        var publications = await _publicationService.GetAllPublications();
        return Ok(publications);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Publication>> GetPublicationById(long id)
    {
        _logger.LogInformation("Request to get Publication with id " + id);
        var publication = await _publicationService.GetPublicationById(id);
        if (publication == null)
        {
            return NotFound();
        }
        return Ok(publication);
    }

    [HttpPost]
    public async Task<ActionResult<Publication>> InsertPublication(Publication publication)
    {
        _logger.LogInformation("Request to post a Publication");
        await _publicationService.InsertPublication(publication);
        return CreatedAtAction(nameof(GetPublicationById), new { id = publication.Id }, publication);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Publication>> UpdatePublication(long id, Publication publication)
    {
        _logger.LogInformation("Request to update a Publication with id " + id);
        var entity = await _publicationService.GetPublicationById(id);
        if (entity == null)
        {
            return NotFound();
        }
        await _publicationService.UpdatePublication(id, publication);
        return Ok(await _publicationService.GetPublicationById(id));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePublication(long id)
    {
        _logger.LogInformation("Request to delete a Publication with id " + id);
        var publication = await _publicationService.GetPublicationById(id);
        if (publication == null)
        {
            return NotFound();
        }
        await _publicationService.DeletePublication(id);
        return Ok();
    }
}
