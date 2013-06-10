using System;


    class ShipDamage
    {
        static void Main()
        {
            int sx1 = Int32.Parse(Console.ReadLine());
            int sy1 = Int32.Parse(Console.ReadLine());
            int sx2 = Int32.Parse(Console.ReadLine());
            int sy2 = Int32.Parse(Console.ReadLine());
            int horizont = Int32.Parse(Console.ReadLine());
            int cx1 = Int32.Parse(Console.ReadLine());
            int cy1 = Int32.Parse(Console.ReadLine());
            int cx2 = Int32.Parse(Console.ReadLine());
            int cy2 = Int32.Parse(Console.ReadLine());
            int cx3 = Int32.Parse(Console.ReadLine());
            int cy3 = Int32.Parse(Console.ReadLine());

            if (sx1 > sx2)
            {
                int temp = sx1;
                sx1 = sx2;
                sx2 = temp;
            }

            if (sy1 > sy2)
            {
                int temp = sy1;
                sy1 = sy2;
                sy2 = temp;                
            }


            int hitx1 = cx1;
            int hity1 = 2 * horizont - cy1;
            int hitx2 = cx2;
            int hity2 = 2 * horizont - cy2;
            int hitx3 = cx3;
            int hity3 = 2 * horizont - cy3;

            // ship Coordinates
            int topY = sy2;
            int rightX = sx1;
            int bottomY = sy1;
            int leftX = sx2;

            int damage = 0;
            if (hity1  < topY && hity1 > bottomY && hitx1 < rightX && hitx1 > leftX)
            {
                damage += 100;               
            }
            else if (hity1 == bottomY || hity1 == topY || hitx1 == rightX || hitx1 == leftX)
            {
                damage += 50;
            }
            else if ((hity1 == topY && hitx1 == leftX) || (hity1 == topY && hitx1 == rightX) || (hity1 == bottomY && hitx1 == leftX) || (hity1 == bottomY && hitx1 == rightX))
            {
                damage += 25;
            }

            // HIT 2
            if (hity2 < topY && hity2 > bottomY && hitx2 < rightX && hitx2 > leftX)
            {
                damage += 100;
            }
            else if (hity2 == bottomY || hity2 == topY || hitx2 == rightX || hitx2 == leftX)
            {
                damage += 50;
            }
            else if ((hity2 == topY && hitx2 == leftX) || (hity2 == topY && hitx2 == rightX) || (hity2 == bottomY && hitx2 == leftX) || (hity2 == bottomY && hitx2 == rightX))
            {
                damage += 25;
            }

            // HIT 3
            if (hity3 < topY && hity3 > bottomY && hitx3 < rightX && hitx3 > leftX)
            {
                damage += 100;
            }
            else if (hity3 == bottomY || hity3 == topY || hitx3 == rightX || hitx3 == leftX)
            {
                damage += 50;
            }
            else if ((hity3 == topY && hitx3 == leftX) || (hity3 == topY && hitx3 == rightX) || (hity3 == bottomY && hitx3 == leftX) || (hity3 == bottomY && hitx3 == rightX))
            {
                damage += 25;
            }

            Console.WriteLine(damage);

        }
    }