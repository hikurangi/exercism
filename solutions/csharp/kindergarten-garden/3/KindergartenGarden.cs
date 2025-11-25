using System;
using System.Collections.Generic;
using System.Linq;

public enum Plant { Violets = 'V', Radishes = 'R', Clover = 'C', Grass = 'G' }

public class KindergartenGarden
{
    private enum Student { Alice, Bob, Charlie, David, Eve, Fred, Ginny, Harriet, Ileana, Joseph, Kincaid, Larry };
    private readonly IEnumerable<IEnumerable<Plant>> _garden;

    private IEnumerable<string> ChunkBy(int size, string chunkee) => Enumerable.Range(0, chunkee.Count() / 2).Select(i => chunkee.Substring(i * size, size));

    public KindergartenGarden(string diagram)
    {
        _garden = diagram
          .Split('\n')
          .Select(r => ChunkBy(2, r).SelectMany(plants => plants.Select(p => (Plant)p)));
    }

    public IEnumerable<Plant> Plants(string student) => _garden.ToList().SelectMany(row => row.ElementAt((int)Enum.Parse(typeof(Student), student)));
}