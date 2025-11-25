using System.Collections.Generic;
using System.Collections.Immutable;

public class SpaceAge
{

  public SpaceAge(int seconds)
  {
    _ageInSeconds = seconds;
  }

  private readonly double _ageInSeconds;
  private static readonly ImmutableDictionary<string, double> PlanetYearInSeconds = new Dictionary<string, double> {
      {"Earth", 31_557_600},
      {"Mercury", 0.2408467 * 365.25 * 24 * 60 * 60},
      {"Venus", 0.61519726 * 365.25 * 24 * 60 * 60},
      {"Mars", 1.8808158 * 365.25 * 24 * 60 * 60},
      {"Jupiter", 11.862615 * 365.25 * 24 * 60 * 60},
      {"Saturn", 29.447498 * 365.25 * 24 * 60 * 60},
      {"Uranus", 84.016846 * 365.25 * 24 * 60 * 60},
      {"Neptune", 164.79132 * 365.25 * 24 * 60 * 60}
    }.ToImmutableDictionary();

  public double OnEarth()
  {
    return _ageInSeconds / PlanetYearInSeconds["Earth"];
  }

  public double OnMercury()
  {
    return _ageInSeconds / PlanetYearInSeconds["Mercury"];

  }

  public double OnVenus()
  {
    return _ageInSeconds / PlanetYearInSeconds["Venus"];
  }

  public double OnMars()
  {
    return _ageInSeconds / PlanetYearInSeconds["Mars"];
  }

  public double OnJupiter()
  {
    return _ageInSeconds / PlanetYearInSeconds["Jupiter"];
  }

  public double OnSaturn()
  {
    return _ageInSeconds / PlanetYearInSeconds["Saturn"];
  }

  public double OnUranus()
  {
    return _ageInSeconds / PlanetYearInSeconds["Uranus"];
  }

  public double OnNeptune()
  {
    return _ageInSeconds / PlanetYearInSeconds["Neptune"];
  }
}