using System;
using System.Collections.Generic;
using System.Linq;

public enum Plant { Violets, Radishes, Clover, Grass }

public class KindergartenGarden
{
    private enum Student { Alice, Bob, Charlie, David, Eve, Fred, Ginny, Harriet, Ileana, Joseph, Kincaid, Larry };
    private readonly Dictionary<Student, IEnumerable<Plant>> _plantsByStudent = new Dictionary<Student, IEnumerable<Plant>>();

    public KindergartenGarden(string diagram)
    {
        _plantsByStudent = diagram
          .Split('\n')
          .SelectMany(row => Enumerable.Range(0, row.Length / 2).Select((integer, position) => (Student: (Student)position, Plants: row.Substring(integer * 2, 2).Select(GetPlant))))
          .GroupBy(t => t.Student, t => t.Plants)
          .Select(g => (g.Key, g.SelectMany(i => i)))
          .ToDictionary(t => t.Item1, t => t.Item2);
    }

    private Plant GetPlant(char plant) => plant switch
    {
        'R' => Plant.Radishes,
        'C' => Plant.Clover,
        'G' => Plant.Grass,
        'V' => Plant.Violets,
        _ => throw new ArgumentException("Invalid plant type specified")
    };

    public IEnumerable<Plant> Plants(string student) => _plantsByStudent[(Student)Enum.Parse(typeof(Student), student)];
}