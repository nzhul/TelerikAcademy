//05. TrailingObject TODO: Add Description of the task

namespace AcademyPopcorn
{
    using System;
    public class TrailObject : GameObject
    {
        private int _lifeTime;

        public int LifeTime
        {
            get { return _lifeTime; }
            set {
                    if (value < 0)
                    {
                        throw new ArgumentException("The value cannot be zero or negative!");
                    }
                    else
                    {
                        _lifeTime = value; 
                    }
                }
        }

        public TrailObject(MatrixCoords topLeft, char[,] body, int lifeTime)
            : base(topLeft, body)
        {
            this.LifeTime = lifeTime;
        }

        public override void Update()
        {
            if (this.LifeTime > 0)
            {
                this.LifeTime--;
            }
            else if (this.LifeTime == 0)
            {
                this.IsDestroyed = true;
            }
        }
        
    }
}
