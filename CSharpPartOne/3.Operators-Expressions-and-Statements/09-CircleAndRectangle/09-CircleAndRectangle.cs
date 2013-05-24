// 09. Write an expression that checks for given point (x, y) if it is 
// within the circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2).

using System;

class CircleAndRectangle
{
    static void Main()
    {
        Console.WriteLine("Please enter the coordinates X & Y coordinates:");

        Console.Write("X: ");
        double x = double.Parse(Console.ReadLine());
        double circlePointX = x - 1; // we subtract 1 because of the circle coordinates ((1,1),3)

        Console.Write("Y: ");
        double y = double.Parse(Console.ReadLine());
        double circlePointY = y - 1; // we subtract 1 because of the circle coordinates ((1,1),3)
        double circleRadius = 3;

        if ((circlePointX * circlePointX + circlePointY * circlePointY) <= (circleRadius * circleRadius)) // x*x + y*y = radius*radius
        {
            Console.WriteLine("The given point IS within a circle with radius of {0}!\n\n", circleRadius);
        }
        else
        {
            Console.WriteLine("The given point IS NOT within a circle with radius of {0}!\n\n", circleRadius);
        }

        // Rectangle Sides Coordinates
        // !!! Important - This solution is based on the assumption that the given variables "top=1" and "left=-1" represent the shift of the rectancle from the center of the coordinate system.
        // Also we assume that the Default ANCHOR POINT of the rectangle is his CENTER
        // The solution depends on the ANCHOR POINT of the rectangle and the coordinates of that point!
        // WATCH MY EXPLANATION ABOUT MY SOLUTION: http://www.youtube.com/watch?v=Mc7R3Ksihvc&feature=youtu.be
        double rectangleHeight = 2;
        double rectangleWidth = 6;
        double topY = 0 + (rectangleHeight / 2);
        double rightX = 0 + (rectangleWidth / 2);
        double bottomY = 0 - (rectangleHeight / 2);
        double leftX = 0 - (rectangleWidth / 2);

        Console.WriteLine("Rectangle Sides Coordinates:\nTop Y: {0}\nRight X: {1}\nBottom Y: {2}\nLeft X: {3}",topY,rightX,bottomY,leftX);

        double rectanglePointX = x - (-1); // = x + 1
        double rectanglePointY = y - 1;

        if ((rectanglePointY < topY) && (rectanglePointY > bottomY) && (rectanglePointX < rightX) && (rectanglePointX > leftX))
        {
            Console.WriteLine("The given point IS withing the rectangle R(top=1, left=-1, width=6, height=2)");
        }
        else
        {
            Console.WriteLine("The given point IS NOT withing rectangle R(top=1, left=-1, width=6, height=2)");
        }
    }
}