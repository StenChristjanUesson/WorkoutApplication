using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutApplication.Model
{
    public class Exercise
    {
        public int Id { get; init}
        public string? Title { get; init}
        public string? Description { get; init}
        public ExerciseIntensity Intensity { get; init}
        public int RecommendedDurationInSeconds { get; init}
        public int RecommendedTimeInSecondsBeforeExercise { get; init}
        public int RecommendedTimeInSecondsAfterExercise { get; init}
        public string? RestTimeInstructions { get; init}

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum ExerciseIntensity {
            Easy = 1,
            Medium = 2,
            Hard = 3
        }
    }
}