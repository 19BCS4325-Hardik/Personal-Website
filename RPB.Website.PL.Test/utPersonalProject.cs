using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace RPB.Website.PL.Test
{
    [TestClass]
    public class utStudent
    {
        [TestMethod]
        public void LoadTest()
        {            
            using (PersonalProjectEntities oDc = new PersonalProjectEntities())
            {
                int expected = 3;
                var projects = (from pp in oDc.tblPersonalProjects
                           select pp).ToList();
                int actual = projects.Count;
                Assert.AreEqual(expected, actual); 
            }
        }

        [TestMethod]
        public void InsertTest()
        {
            using (PersonalProjectEntities oDc = new PersonalProjectEntities())
            {
                tblPersonalProject newRow = new tblPersonalProject();
                newRow.Name = "Test Project";
                newRow.Languages = "C#";
                newRow.GitHubRepository = "Test Repo";
                newRow.Description = "Test Description";
                newRow.Demonstration = "Test Demonstration";
                oDc.tblPersonalProjects.Add(newRow);
                oDc.SaveChanges();
                tblPersonalProject projects = oDc.tblPersonalProjects.FirstOrDefault(pp => pp.Id == 4);
                Assert.IsNotNull(projects);
            }
        }

        [TestMethod]
        public void UpdateTest()
        {
            using (PersonalProjectEntities oDc = new PersonalProjectEntities())
            {
                tblPersonalProject project = oDc.tblPersonalProjects.FirstOrDefault(pp => pp.Id == 4);
                project.Languages = "C++";
                oDc.SaveChanges();
                tblPersonalProject updatedProject = oDc.tblPersonalProjects.FirstOrDefault(pp => pp.Id == 4);
                Assert.AreEqual(updatedProject.Languages, project.Languages);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            using (PersonalProjectEntities oDc = new PersonalProjectEntities())
            {
                tblPersonalProject project = oDc.tblPersonalProjects.FirstOrDefault(pp => pp.Id == 4);
                oDc.tblPersonalProjects.Remove(project);
                oDc.SaveChanges();
                tblPersonalProject deletedProject = oDc.tblPersonalProjects.FirstOrDefault(pp => pp.Id == 4);
                Assert.IsNull(deletedProject);
            }
        }
    }
}
