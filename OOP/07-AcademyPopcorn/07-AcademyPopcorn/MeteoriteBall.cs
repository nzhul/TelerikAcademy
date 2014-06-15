namespace AcademyPopcorn
{
    using System.Collections.Generic;
    public class MeteoriteBall : Ball
    {
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        { }

        public override System.Collections.Generic.IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> tailList = new List<GameObject>();
            tailList.Add(new TrailObject(base.TopLeft, new char[,] { { '*' } }, 3));
            return tailList;
        }
    }
}
