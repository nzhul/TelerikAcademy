namespace AcademyPopcorn
{
    using System.Collections.Generic;
    public class ShootingRacket : Racket
    {
        private bool isShooting = false;

        public ShootingRacket(MatrixCoords topLeft, int width)
            : base(topLeft, width)
        { }

        public void Shoot()
        {
            isShooting = true;
        }

        public override System.Collections.Generic.IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> bullets = new List<GameObject>();
            if (isShooting)
            {
                isShooting = false;
                bullets.Add(new Bullet(new MatrixCoords(this.topLeft.Row, this.topLeft.Col + 5)));
            }
            return bullets;
        }
    }
}
