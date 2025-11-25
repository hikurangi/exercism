using System;
using System.Linq;
using System.Collections.Generic;

public static class NucleotideCount
{
    private static readonly List<char> Nucleotides = new List<char> { 'A', 'C', 'G', 'T' };

    public static IDictionary<char, int> Count(string sequence) => sequence.Aggregate(new Dictionary<char, int>
    {
        ['A'] = 0,
        ['C'] = 0,
        ['G'] = 0,
        ['T'] = 0
    }, (state, c) =>
    {
        if (!Nucleotides.Contains(c))
        {
            throw new ArgumentException();
        }
        else
        {
            state[c] = state.GetValueOrDefault(c) + 1;
            return state;
        }
    });

}