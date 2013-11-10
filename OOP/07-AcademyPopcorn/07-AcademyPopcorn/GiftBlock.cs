using System.Collections.Generic;
namespace AcademyPopcorn
{
    public class GiftBlock : Block
    {
        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0, 0] = 'G';
        }

        public new const string CollisionGroupString = "giftBlock";
        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override System.Collections.Generic.IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> fallingGifts = new List<GameObject>();
            if (this.IsDestroyed)
            {
                fallingGifts.Add(new Gift(this.topLeft, new char[,] { { 's' } }, new MatrixCoords(1, 0)));
            }
            return fallingGifts;
        }

        public override string GetCollisionGroupString()
        {
            return GiftBlock.CollisionGroupString;
        }
    }
}
