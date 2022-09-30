using System;

namespace GravityBalls
{
	public class WorldModel
	{
		public double BallX;
		public double BallY;
		public double BallRadius;
		public double WorldWidth;
		public double WorldHeight;

        public const double HorizontalSpeed = 100;
        public const double VerticalSpeed = 200;
		public void SimulateTimeframe(double dt)
        {
            var dx = HorizontalSpeed * dt;
			var dy = VerticalSpeed * dt;
            var newX = dx < 0 ? Math.Max(BallRadius, BallX + dx) : Math.Min(WorldWidth - BallRadius, BallX + dx);
			var newY = dy < 0 ? Math.Max(BallRadius, BallY + dy) : Math.Min(WorldHeight - BallRadius, BallY + dy);
            if (newX == BallX || newY == BallY) 
                return;
            BallX = newX;
            BallY = newY;
        }
	}
}