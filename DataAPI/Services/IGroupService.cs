using DataAPI.Models;

namespace DataAPI.Services
{
    public interface IGroupService
    {
        List<GroupEntity> GetGroupsAsync();
        Task<GroupEntity> GetGroupByIdAsync(int id);
        Task<List<GroupEntity>> GetGroupsByParentIdAsync(int parentId);
        Task<GroupEntity> InsertGroupAsync(int ParentId);
        Task<List<PersonEntity>> GetPersonsByGroupIdAsync(int groupId);
        Task<PersonEntity> InsertPersonAsync(PersonEntity person);
        object GetGroupsWithPersonsAsync();
    }
}
