namespace LR_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool triangleValidation = false;
            double[] triangle = new double[3];
            while (triangleValidation == false)
            {
                triangle = EnterTriangle();
                triangleValidation = TriangleValidation(triangle);
            }

            double perimeter = PerimeterOfTriangle(triangle);
            Console.WriteLine("Perimeter of triangle = " + perimeter);

            double area = AreaOfTriangle(triangle, perimeter);
            Console.WriteLine("Area of triangle = " + area);

            KindOfTriangle(triangle);
        }

        static double[] EnterTriangle()
        {
            Console.WriteLine("Enter the first side of the triangle: ");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the second side of the triangle: ");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the third side of the triangle: ");
            double c = double.Parse(Console.ReadLine());

            double[] triangle = { a, b, c };

            return triangle;
        }

        static bool TriangleValidation(double[] triangle)
        {
            if (triangle[0] + triangle[1] > triangle[2] &&
                triangle[0] + triangle[2] > triangle[1] &&
                triangle[1] + triangle[2] > triangle[0] &&
                triangle[0] > 0 && triangle[1] > 0 && triangle[2] > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Validation failed!");
                return false;
            }
        }

        static double PerimeterOfTriangle(double[] triangle)
        {
            return triangle[0] + triangle[1] + triangle[2];
        }

        static double AreaOfTriangle(double[] triangle, double perimeter)
        {
            double p = perimeter / 2;
            double area = Math.Sqrt(p * (p - triangle[0]) * (p - triangle[1]) * (p - triangle[2]));
            return area;
        }

        static void KindOfTriangle(double[] triangle)
        {
            bool a = true;
            if (triangle[0] == triangle[1] && triangle[1] == triangle[2])
            {
                Console.WriteLine("Equilateral triangle");
                a = false;
            } 
            if(triangle[0] == triangle[1] || triangle[1] == triangle[2] || triangle[0] == triangle[2])
            {
                Console.WriteLine("Isosceles triangle");
                a = false;
            } 
            if (((Math.Pow(triangle[0], 2) + Math.Pow(triangle[1], 2)) == Math.Pow(triangle[2], 2)) || ((Math.Pow(triangle[1], 2) + Math.Pow(triangle[2], 2)) == Math.Pow(triangle[0], 2)) || ((Math.Pow(triangle[0], 2) + Math.Pow(triangle[2], 2)) == Math.Pow(triangle[1], 2)))
            {
                Console.WriteLine("Right-angled triangle");
                a = false;
            }
            if(a) { Console.WriteLine("Arbitrary triangle"); }
        }
    }
}
