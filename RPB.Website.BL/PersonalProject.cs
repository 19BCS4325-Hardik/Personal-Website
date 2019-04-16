using RPB.Website.PL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace RPB.Website.BL
{
    public class PersonalProject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Languages { get; set; }
        public string Description { get; set; }
        [DisplayName("GitHub")]
        public string GitHubRepository { get; set; }
        public string Demonstration { get; set; }

        public PersonalProject() { }

        public PersonalProject(int id, string name, string languages, string description, string githubrepository, string demonstration)
        {
            Id = id;
            Name = name;
            Languages = languages;
            Description = description;
            GitHubRepository = githubrepository;
            Demonstration = demonstration;
        }

        private void MapToDatabase(tblPersonalProject project)
        {
            project.Name = Name;
            project.Languages = Languages;
            project.Description = Description;
            project.GitHubRepository = GitHubRepository;
            project.Demonstration = Demonstration;
        }

        private void MapToObject(tblPersonalProject project)
        {
            Id = project.Id;
            Name = project.Name;
            Languages = project.Languages;
            Description = project.Description;
            GitHubRepository = project.GitHubRepository;
            Demonstration = project.Demonstration;
        }

        public void LoadById()
        {
            try
            {
                using (PersonalProjectEntities oDc = new PersonalProjectEntities())
                {
                    var project = oDc.tblPersonalProjects.FirstOrDefault(p => p.Id == Id);
                    if (project != null)
                        MapToObject(project);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert()
        {
            try
            {
                using (PersonalProjectEntities oDc = new PersonalProjectEntities())
                {
                    tblPersonalProject project = new tblPersonalProject();
                    MapToDatabase(project);
                    oDc.tblPersonalProjects.Add(project);
                    oDc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update()
        {
            try
            {
                using (PersonalProjectEntities oDc = new PersonalProjectEntities())
                {
                    tblPersonalProject project = oDc.tblPersonalProjects.FirstOrDefault(p => p.Id == Id);
                    MapToDatabase(project);
                    oDc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete()
        {
            try
            {
                using (PersonalProjectEntities oDc = new PersonalProjectEntities())
                {
                    tblPersonalProject project = oDc.tblPersonalProjects.FirstOrDefault(p => p.Id == Id);
                    oDc.tblPersonalProjects.Remove(project);
                    oDc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class PersonalProjectList : List<PersonalProject>
    {
        public void Load()
        {
            try
            {
                using (PersonalProjectEntities oDc = new PersonalProjectEntities())
                    oDc.tblPersonalProjects.OrderByDescending(p => p.Id).ToList().ForEach(p => Add(new PersonalProject(p.Id, p.Name, p.Languages, p.Description, p.GitHubRepository, p.Demonstration)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
