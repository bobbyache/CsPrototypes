using System;
using CygSoft.SmartSession.EF;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartSession.Domain.Records;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Insert_A_Goal()
        {
            var goal = new Goal
            {
                Title = "Here is my first goal",
                DateCreated = DateTime.Now,
                TargetCompletionDate = DateTime.Now.AddMonths(6),
                Description = "My Description"
            };

            DataAccess dataAccess = new DataAccess();
            dataAccess.InsertGoal(goal);
        }

        [TestMethod]
        public void Insert_A_Task()
        {
            var task = new PracticeTask()
            {
                Title = "Here is my first goal",
                DateCreated = DateTime.Now,
                GoalTaskType = 1,
                TargetPracticeDuration = 10,
                TargetSpeed = 120,
                Exercise = new Exercise()
                {
                    Title = "Exercise Title",
                    DifficultyRating = 3,
                    RequiredDuration = 520,
                    DateCreated = DateTime.Now
                },
                Description = "My Description"
            };

            DataAccess dataAccess = new DataAccess();
            dataAccess.InsertTask(task);
        }
    }
}
