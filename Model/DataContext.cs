using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutApplication.Model
{
    public class DataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Exercise>? ExerciseList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Exercise>().HasData(
                new Exercise
                {
                    Id = 1,
                    Title = "Kätekõverdused jala tõstega",
                    Description = "Tavalised kätekõverdused korda mööda jalga tõstes",
                    Intensity = Exercise.ExerciseIntensity.Medium,
                    RecommendedDurationInSeconds = 40,
                    RecommendedTimeInSecondsBeforeExercise = 10,
                    RecommendedTimeInSecondsAfterExercise = 10
                },
                new Exercise
                {
                    Id = 2,
                    Title = "Slaalomhüpped",
                    Description = "kükist hüpped küljelt küljele",
                    Intensity = Exercise.ExerciseIntensity.Hard,
                    RecommendedDurationInSeconds = 40,
                    RecommendedTimeInSecondsBeforeExercise = 10,
                    RecommendedTimeInSecondsAfterExercise = 10
                    RestTimeInstructions = "Venita reie esikülge"
                },
                new Exercise
                {
                    Id = 3,
                    Title = "Alt läbi jooks",
                    Description = "Toenglamangus jooksmine",
                    Intensity = Exercise.ExerciseIntensity.Medium,
                    RecommendedDurationInSeconds = 40,
                    RecommendedTimeInSecondsBeforeExercise = 10,
                    RecommendedTimeInSecondsAfterExercise = 10
                }
            )
        }
    }
}