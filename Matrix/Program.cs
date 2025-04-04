using System;
using System.Collections.Generic;

public class FitnessProgram
{
    public List<string> Exercises { get; set; } = new List<string>();
    public string DifficultyLevel { get; set; }

    public void ShowProgram()
    {
        Console.WriteLine($"Программа тренировки ({DifficultyLevel} уровень):");
        foreach (var exercise in Exercises)
        {
            Console.WriteLine("- " + exercise);
        }
        Console.WriteLine();
    }
}

public interface IWorkoutBuilder
{
    void AddCardio();
    void AddStrengthTraining();
    void AddStretching();
    void AddYoga();
    FitnessProgram GetProgram();
}

public class BeginnerWorkoutBuilder : IWorkoutBuilder
{
    private readonly FitnessProgram _program = new FitnessProgram { DifficultyLevel = "Начальный" };

    public void AddCardio()
    {
        _program.Exercises.Add("Легкий бег 5 минут");
    }

    public void AddStrengthTraining()
    {
        _program.Exercises.Add("Приседания с собственным весом 10 раз");
    }

    public void AddStretching()
    {
        _program.Exercises.Add("Растяжка ног 5 минут");
    }

    public void AddYoga()
    {
        _program.Exercises.Add("Легкая йога 10 минут");
    }

    public FitnessProgram GetProgram()
    {
        return _program;
    }
}

public class IntermediateWorkoutBuilder : IWorkoutBuilder
{
    private readonly FitnessProgram _program = new FitnessProgram { DifficultyLevel = "Средний" };

    public void AddCardio()
    {
        _program.Exercises.Add("Бег 10 минут");
    }

    public void AddStrengthTraining()
    {
        _program.Exercises.Add("Отжимания 15 раз, Приседания с гантелями 15 раз");
    }

    public void AddStretching()
    {
        _program.Exercises.Add("Динамическая растяжка 10 минут");
    }

    public void AddYoga()
    {
        _program.Exercises.Add("Хатха-йога 15 минут");
    }

    public FitnessProgram GetProgram()
    {
        return _program;
    }
}

public class AdvancedWorkoutBuilder : IWorkoutBuilder
{
    private readonly FitnessProgram _program = new FitnessProgram { DifficultyLevel = "Продвинутый" };

    public void AddCardio()
    {
        _program.Exercises.Add("Интервальный бег 20 минут");
    }

    public void AddStrengthTraining()
    {
        _program.Exercises.Add("Приседания со штангой 20 раз, Отжимания на брусьях 15 раз");
    }

    public void AddStretching()
    {
        _program.Exercises.Add("Глубокая растяжка 15 минут");
    }

    public void AddYoga()
    {
        _program.Exercises.Add("Аштанга-йога 20 минут");
    }

    public FitnessProgram GetProgram()
    {
        return _program;
    }
}


public class WorkoutDirector
{
    private readonly IWorkoutBuilder _builder;

    public WorkoutDirector(IWorkoutBuilder builder)
    {
        _builder = builder;
    }

    public void ConstructWorkout()
    {
        _builder.AddCardio();
        _builder.AddStrengthTraining();
        _builder.AddStretching();
        _builder.AddYoga();
    }

    public FitnessProgram GetWorkout()
    {
        return _builder.GetProgram();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var beginnerDirector = new WorkoutDirector(new BeginnerWorkoutBuilder());
        beginnerDirector.ConstructWorkout();
        var beginnerWorkout = beginnerDirector.GetWorkout();
        beginnerWorkout.ShowProgram();

        var intermediateDirector = new WorkoutDirector(new IntermediateWorkoutBuilder());
        intermediateDirector.ConstructWorkout();
        var intermediateWorkout = intermediateDirector.GetWorkout();
        intermediateWorkout.ShowProgram();

        var advancedDirector = new WorkoutDirector(new AdvancedWorkoutBuilder());
        advancedDirector.ConstructWorkout();
        var advancedWorkout = advancedDirector.GetWorkout();
        advancedWorkout.ShowProgram();

        Console.ReadKey();
    }
}
