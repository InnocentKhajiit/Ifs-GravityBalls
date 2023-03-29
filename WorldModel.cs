using System;
using System.Drawing;
using System.Windows.Forms;

namespace GravityBalls
{
    public class WorldModel
    {
        public double BallX;
        public double BallY;
        public double BallRadius;
        public double WorldWidth;
        public double WorldHeight;

        private const double Drag = 0.01;
        private const double GravitationalConstant = 9.8;
        private const double CursorPulse = 500;
        public Vector2 MovingVector = new Vector2(100, 100);


        /// <summary>This method changes the ball's location according
        ///    to its current direction and given speed.
        /// </summary>
        private void Move(out double x, out double y, double dt)
        {
            var dx = MovingVector.X * dt;
            var dy = MovingVector.Y * dt;
            x = dx < 0 ? Math.Max(BallRadius, BallX + dx) : Math.Min(WorldWidth - BallRadius, BallX + dx);
            y = dy < 0 ? Math.Max(BallRadius, BallY + dy) : Math.Min(WorldHeight - BallRadius, BallY + dy);
        }

        /// <summary>This method makes the ball bounce
        ///    as soon as it hits the wall.
        /// </summary>
        private void BounceWhenNeeded(double ballX, double ballY)
        {
            if (ballX == BallX)
                MovingVector.X *= -1;
            if (ballY == BallY)
                MovingVector.Y *= -1;
        }

        private void ApplyDrag()
        {
            MovingVector *= (1 - Drag);
        }

        private void ApplyGravity()
        {
            MovingVector += new Vector2(0, GravitationalConstant);
        }

        public void SimulateTimeFrame(double dt)
        {
            ApplyCursorPulse();
            ApplyGravity();
            ApplyDrag();
            
            Move(out var newX, out var newY, dt);
            BounceWhenNeeded(newX, newY);
            
            BallX = newX;
            BallY = newY;
        }

        private void ApplyCursorPulse()
        {
            var cursorPosition = GetCursorPosition();
            var vector = new Vector2(cursorPosition.X, cursorPosition.Y, BallX, BallY);
            if (BallRadius > vector.Length)
            {
                MovingVector = vector * (CursorPulse / vector.Length);
            }
        }

        private Point GetCursorPosition()
        {
            var form =  Form.ActiveForm;
            var position = form.PointToClient(Cursor.Position);
            return position;
        }
    }
}