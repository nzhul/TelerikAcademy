namespace AcademyPopcorn
{
    public class UnstoppableBall : Ball
    {
        public new const string CollisionGroupString = "unstoppableBall";
        public UnstoppableBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        { }

        public override string GetCollisionGroupString()
        {
            return UnstoppableBall.CollisionGroupString;
        }

        public override


    }
}
