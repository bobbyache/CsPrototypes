using SmartSession.Domain.Records;
using System;

namespace CygSoft.SmartSession.EF
{
    public class DataAccess
    {
        public void InsertGoal(Goal goal)
        {
            if (goal.Id > 0)
                throw new ArgumentException("A new goal cannot have an id");

            using (var context = new SmartSessionContext())
            {
                context.Goals.Add(goal);
                // context.Add(goal); // for polymorphic inserts.
                // context is now tracking the goal.
                context.SaveChanges(); // now is saved.
            }
        }

        public void InsertExercise(Exercise exercise)
        {
            if (exercise.Id > 0)
                throw new ArgumentException("A new exercise cannot have an id");

            using (var context = new SmartSessionContext())
            {
                context.Exercises.Add(exercise);
                context.SaveChanges();
            }
        }

        public void InsertTask(PracticeTask task)
        {
            if (task.Id > 0)
                throw new ArgumentException("A new task cannot have an id");

            using (var context = new SmartSessionContext())
            {
                context.Tasks.Add(task);
                context.SaveChanges();
            }
        }
    }
}
