using System;
using System.Collections.Generic;
using System.Linq;

public class HighScores
{
  private readonly int _latest;
  private readonly int _max;
  private readonly List<int> _scores;
  private readonly List<int> _sorted;

  public HighScores(List<int> list)
  {
    _latest = list.Last();
    _max = list.Max();
    
    // maintain an intact copy of the original list
    _scores = new List<int>(list);

    var listToSort = new List<int>(list);
    
    // the following methods mutate the list in-place
    listToSort.Sort();
    listToSort.Reverse();

    // only set the property once it is ready
    _sorted = listToSort;
  }

  public List<int> Scores() => _scores;

  public int Latest() => _latest;

  public List<int> PersonalTopN(int count) =>
    (_sorted.Count >= count && count != 1)
      ? _sorted.GetRange(0, count)
      : _sorted;

  public int PersonalBest() => _max;
  public List<int> PersonalTopThree() => PersonalTopN(3);
}