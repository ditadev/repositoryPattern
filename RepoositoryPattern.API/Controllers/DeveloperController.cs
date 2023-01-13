using DataAccess.EFCore;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace RepoositoryPattern.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DeveloperController : ControllerBase
{
    private readonly UnitOfWork _unitOfWork;
    public DeveloperController(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    [HttpPost]
    public IActionResult AddDeveloperAndProject()
    {
        var developer = new Developer
        {
            Followers = 35,
            Name = "Abraham Inyaka"
        };
        var project = new Project
        {
            Name = "codeWiithDitaDev"
        };
        _unitOfWork.Developers.Add(developer);
        _unitOfWork.Projects.Add(project);
        _unitOfWork.Complete();
        return Ok();
    }
    
    [HttpGet]
    public IActionResult GetPopularDevelopers([FromQuery]int count)
    {
        var popularDevelopers = _unitOfWork.Developers.GetPopularDevelopers(count);
        return Ok(popularDevelopers);
    }
}