using DataAPI.Data;
using DataAPI.Models;
using DataAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DataAPI.Controllers
{
    public class GroupController : ControllerBase
    {
        private readonly ILogger<GroupController> _logger;
        private readonly IGroupService _groupService;
        private readonly GroupDbContext _context;
        public GroupController(IGroupService groupService, ILogger<GroupController> logger, GroupDbContext context)
        {
            _groupService = groupService;
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetGroups()
        {
            // Logic to get groups from the database or any other source
            var groups = _groupService.GetGroupsAsync();
            return Ok(groups);
        }
        [HttpGet("GetGroupById")]
        public IActionResult GetGroup()
        {
            var group = new string("Group1");
            return Ok(group);
        }
        [HttpGet("GetGroupsByParentId")]
        public IActionResult getGroupsByParentId(int ParentId)
        {
            var task = _groupService.GetGroupsByParentIdAsync(ParentId);
            var groups = task.Result;
            return Ok(groups);
        }
        [HttpPost("InsertGroup")]
        public IActionResult InsertGroup(int ParentID)
        {
            var group = _groupService.InsertGroupAsync(ParentID);
            return Ok(group);
        }
        [HttpGet("GetPersonsByGroupId")]
        public IActionResult GetPersonsByGroupId(int GroupId)
        {
            var task = _groupService.GetPersonsByGroupIdAsync(GroupId);
            var persons = task.Result;
            if (persons == null)
            {
                return NotFound();
            }
            return Ok(persons);
        }
        [HttpPost("InsertPerson")]
        public IActionResult InsertPerson(PersonEntity fromBody)
        {
            var person = _groupService.InsertPersonAsync(fromBody);
            return Ok(person);
        }
        [HttpGet("GetGroupsWithPersons")]
        public IActionResult GetGroupsWithPersons()
        {
            var group = _groupService.GetGroupsWithPersonsAsync();
            if (group == null)
            {
                return NotFound();
            }
            return Ok(group);
        }
    }
}