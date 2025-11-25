using System.Collections.Generic;

public class SpaceAge
{

    public SpaceAge(int seconds)
    {
        _ageInSeconds = seconds;
    }

    readonly double _ageInSeconds;

    static readonly IReadOnlyDictionary<string, double> PlanetYearInSeconds = new Dictionary<string, double> {
      {"Earth", 31_557_600},
      {"Mercury", 7_600_543.81992},
      {"Venus", 19_414_149.052176},
      {"Mars", 59_354_032.690079994},
      {"Jupiter", 374_355_659.12399995},
      {"Saturn", 929_292_362.8848001},
      {"Uranus", 2_651_370_019.3296},
      {"Neptune", 5_200_418_560.032}
    };

    public double OnEarth() => _ageInSeconds / PlanetYearInSeconds["Earth"];
    public double OnMercury() => _ageInSeconds / PlanetYearInSeconds["Mercury"];
    public double OnVenus() => _ageInSeconds / PlanetYearInSeconds["Venus"];
    public double OnMars() => _ageInSeconds / PlanetYearInSeconds["Mars"];
    public double OnJupiter() => _ageInSeconds / PlanetYearInSeconds["Jupiter"];
    public double OnSaturn() => _ageInSeconds / PlanetYearInSeconds["Saturn"];
    public double OnUranus() => _ageInSeconds / PlanetYearInSeconds["Uranus"];
    public double OnNeptune() => _ageInSeconds / PlanetYearInSeconds["Neptune"];
}