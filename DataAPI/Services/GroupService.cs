using DataAPI.Data;
using DataAPI.Models;

namespace DataAPI.Services
{
    public class GroupService : IGroupService
    {
        private readonly GroupDbContext _context;
        public GroupService(GroupDbContext context)
        {
            _context = context;
        }
        public Task<GroupEntity> GetGroupByIdAsync(int id)
        {
            return Task.FromResult(_context.Groups.FirstOrDefault(g => g.Id == id));
        }

        public List<GroupEntity> GetGroupsAsync()
        {
            return _context.Groups.ToList();
        }

        public Task<List<GroupEntity>> GetGroupsByParentIdAsync(int parentId)
        {
            return Task.FromResult(_context.Groups.Where(G => G.ParentId.Contains(parentId)).ToList());
        }

        public object GetGroupsWithPersonsAsync()
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
                        g.ParentId
                    });
            return group;
        }

        public Task<List<PersonEntity>> GetPersonsByGroupIdAsync(int groupId)
        {
            return Task.FromResult(_context.Persons.Where(p => p.GroupId == groupId).ToList());
        }

        public Task<GroupEntity> InsertGroupAsync(int ParentId)
        {
            var group = new GroupEntity
            {
                ParentId = [ParentId],
                GroupName = "Group1"
            };
            _context.Groups.Add(group);
            _context.SaveChanges();
            return Task.FromResult(group);
        }

        public Task<PersonEntity> InsertPersonAsync(PersonEntity person)
        {
            var result = _context.Persons.Add(person).Entity;
            _context.SaveChanges();
            return Task.FromResult(result);
        }

    }
}
