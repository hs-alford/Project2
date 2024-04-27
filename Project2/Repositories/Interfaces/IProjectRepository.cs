using Project2.Models;

namespace Project2.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        List<Project> GetProjects();
        Project GetProjectById(string projectId);
        Project CreateProject(Project project);
        Project UpdateProject(Project project);
        void DeleteProjectById(string projectId);
    }
}
