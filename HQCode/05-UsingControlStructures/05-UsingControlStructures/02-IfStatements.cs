using System;

class Program
{
    static void Main()
    {
        {
            Potato potato;

            // ... 

            if (potato == null) 
            {
                throw new ArgumentException();
            }

            if (!potato.IsPeeled)
            {
                throw new ArgumentException();
            }

            if (potato.IsRotten)
            {
                throw new ArgumentException();
            }

            Cook(potato);
        }

        {
            isInside = (x, y) =>
                MIN_X <= x && x <= MAX_X &&
                MIN_Y <= y && y <= MAX_Y

            isNext = (x, y) =>
                // ...

            if (isInside(x, y) && isNext(x, y))
            {
               VisitCell();
            }
        }
    }
}