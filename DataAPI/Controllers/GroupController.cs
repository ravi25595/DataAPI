using DataAPI.Data;
using DataAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataAPI.Controllers
{
    public class GroupController : ControllerBase
    {
        private readonly ILogger<GroupController> _logger;
        private readonly GroupDbContext _context;
        public GroupController(GroupDbContext context, ILogger<GroupController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetGroups()
        {
            // Logic to get groups from the database or any other source
            var groups = _context.Groups.ToList();
            return Ok(groups);
        }
        [HttpGet("GetGroupById")]
        public IActionResult GetGroup()
        {
            var group = new string("Group1");
            return Ok(group);
        }
        [HttpGet("GetGroupsByParentId")]
        public IActionResult getGroupByParentId(int ParentId)
        {
            var groups = _context.Groups.Where(G => G.ParentId.Contains(ParentId)).ToList();
            return Ok(groups);
        }
        [HttpPost("InsertGroup")]
        public IActionResult InsertGroup(int ParentID)
        {
            var group = new GroupEntity
            {
                ParentId = [ParentID],
                GroupName = "Group1"
            };
            _context.Groups.Add(group);
            _context.SaveChanges();
            return Ok(group);
        }
        [HttpGet("GetPersonsByGroupId")]
        public IActionResult GetPersonsByGroupId(int GroupId)
        {
            var persons = _context.Persons.Where(p => p.GroupId == GroupId);
            return Ok(persons);
        }
        [HttpPost("InsertPerson")]
        public IActionResult InsertPerson(PersonEntity fromBody)
        {
            _context.Persons.Add(fromBody);
            _context.SaveChanges();
            return Ok(fromBody);
        }
        [HttpGet("GetGroupWithPersons")]
        public IActionResult GetGroupWithPersons()
        {
            var group = _context.Groups
                .GroupJoin(_context.Persons,
                    g => g.Id,
                    p => p.GroupId,
                    (g, p) => new
                    {
                        records = p.Select(p => new
                        {
                            p.Id,
                            p.Name,
                            p.Email,
                            p.Phone,
                            p.Subjects
                        }).ToList(),
                        g.Id,
                    });
            if (group == null)
            {
                return NotFound();
            }
            return Ok(group);
        }
    }
}