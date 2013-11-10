namespace AcademyPopcorn
{
    using System.Collections.Generic;
    public class ExplodingBlock : Block
    {
        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0, 0] = 'E';
        }

        public new const string CollisionGroupString = "explodingBlock";
        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override System.Collections.Generic.IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> splashObjects = new List<GameObject>();
            if (this.IsDestroyed)
            {
                splashObjects.Add(new Explosion(this.topLeft, new char[,] { { '+' } }, new MatrixCoords(-1, 0)));
                splashObjects.Add(new Explosion(this.topLeft, new char[,] { { '+' } }, new MatrixCoords(1, 0)));
                splashObjects.Add(new Explosion(this.topLeft, new char[,] { { '+' } }, new MatrixCoords(0, 1)));
                splashObjects.Add(new Explosion(this.topLeft, new char[,] { { '+' } }, new MatrixCoords(0, -1)));
            }
            return splashObjects;
        }

        public override string GetCollisionGroupString()
        {
            return ExplodingBlock.CollisionGroupString;
        }
    }
}
