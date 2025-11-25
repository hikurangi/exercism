using System.Linq;

public static class Triangle
{
    private static int UniqueElements(params double[] triangle) => triangle.Distinct().Count();

    private static bool IsTriangleInequalityViolation(params double[] triangle) => triangle.OrderByDescending(i => i).Skip(1).Sum() < triangle.Max();

    public static bool IsScalene(params double[] triangle) => UniqueElements(triangle) == 3 && !IsTriangleInequalityViolation(triangle);

    public static bool IsIsosceles(params double[] triangle) => IsEquilateral(triangle) || UniqueElements(triangle) == 2 && !IsTriangleInequalityViolation(triangle);

    public static bool IsEquilateral(params double[] triangle) => UniqueElements(triangle) == 1 && (triangle.Average() != 0);
}