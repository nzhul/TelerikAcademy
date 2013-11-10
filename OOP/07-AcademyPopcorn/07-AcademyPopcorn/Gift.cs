using System.Collections.Generic;
namespace AcademyPopcorn
{
    public class Gift : MovingObject
    {
        public new const string CollisionGroupString = "gift";
        public Gift(MatrixCoords topLeft, char[,] body, MatrixCoords speed)
            : base(topLeft, body, speed)
        { 
            
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override string GetCollisionGroupString()
        {
            return Gift.CollisionGroupString;
        }

        public override System.Collections.Generic.IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> produceShootingRacket = new List<GameObject>();
            if (this.IsDestroyed)
            {
                produceShootingRacket.Add(new ShootingRacket(new MatrixCoords(this.topLeft.Row + 1, this.topLeft.Col - 10), 10));
            }
            return produceShootingRacket;
        }
    }
}
