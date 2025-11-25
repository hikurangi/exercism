using System.Linq;

class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek() => new int[] { 0, 2, 5, 3, 7, 8, 4 };
    public int Today() => birdsPerDay.Last();

    public void IncrementTodaysCount()
    {
      birdsPerDay[birdsPerDay.Length - 1]++; // ugh
    }

    public bool HasDayWithoutBirds() => birdsPerDay.Any(d => d == 0);
    public int CountForFirstDays(int numberOfDays) => birdsPerDay.Take(numberOfDays).Sum();
    public int BusyDays() => birdsPerDay.Where(d => d > 4).Count();
}