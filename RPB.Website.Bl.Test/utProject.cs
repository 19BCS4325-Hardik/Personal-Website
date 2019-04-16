using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPB.Website.BL;

namespace RPB.Website.Bl.Test
{
    [TestClass]
    public class utProject
    {
        [TestMethod]
        public void LoadTest()
        {
            PersonalProjectList projects = new PersonalProjectList();
            projects.Load();
            Assert.AreEqual(3, projects.Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            PersonalProject project = new PersonalProject();
            project.Name = "Test Project";
            project.Languages = "Test Languages";
            project.Description = "Test Description";
            project.GitHubRepository = "Test GitHub Repo";
            project.Demonstration = "Test Demo";
            project.Insert();
            project.LoadById();
            Assert.AreEqual("Test Demo", project.Demonstration);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            PersonalProject project = new PersonalProject();
            project.Id = 5;
            project.LoadById();
            Assert.AreEqual("Test Demo", project.Demonstration);
        }

        [TestMethod]
        public void UpdateTest()
        {
            PersonalProject project = new PersonalProject();
            project.Id = 5;
            project.LoadById();
            project.Languages = "C#";
            project.Update();
            project.LoadById();
            Assert.AreEqual("C#", project.Languages);
        }

        [TestMethod]
        public void DeleteTest()
        {
            PersonalProjectList projectsInitial = new PersonalProjectList();
            projectsInitial.Load();

            PersonalProject project = new PersonalProject();
            project.Id = 5;
            project.Delete();

            PersonalProjectList projectsFinal = new PersonalProjectList();
            projectsFinal.Load();

            Assert.AreEqual(projectsFinal.Count, (projectsInitial.Count - 1));
        }
    }
}
