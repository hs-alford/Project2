using Project2.Data;
using Project2.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Project2.Repositories.Interfaces;

namespace Project2.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Project CreateProject(Project project)
        {
            var result = _context.Projects.Add(project);
            _context.SaveChangesAsync();
            return result.Entity;
        }

        public void DeleteProjectById(string id)
        {
            var project = _context.Projects.FirstOrDefault(u => u.ProjectId == id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                _context.SaveChangesAsync();
            }
        }

        public Project GetProjectById(string id)
        {
            return _context.Projects.FirstOrDefault(u => u.ProjectId == id);
        }

        public List<Project> GetProjects()
        {
            return _context.Projects.ToList();
        }

        public Project UpdateProject(Project project)
        {
            var result = _context.Projects
                .FirstOrDefault(e => e.ProjectId == e.ProjectId);

            if (result != null)
            {
                result.Descripton = project.Descripton;
                result.CustId = project.CustId;
                result.OrderNumber = project.OrderNumber;
                result.StartDate = project.StartDate;
                result.EndDate = project.EndDate;
                result.PM_EmpId = project.PM_EmpId;

                _context.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
