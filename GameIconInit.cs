using Microsoft.Xna.Framework;
using System;

namespace Screensaver
{
    internal class GameIconInit
    {
        private string _iconPath;
        private Vector2 _startPosition;
        private Vector2 _direction;
        private double _speed;

        public GameIconInit(string iconPath, Vector2 startPosition, double angle, double speed)
        {
            _iconPath = iconPath;
            _startPosition = startPosition;
            double radians = angle * (Math.PI / 180.0d);
            _direction = new Vector2((float)Math.Cos(radians), (float)Math.Sin(radians));
            _speed = speed;
        }

        public string GetIconPath() { return _iconPath; }
        public Vector2 GetStartPosition() { return _startPosition; }
        public Vector2 GetDirection() { return _direction; }
        public double GetSpeed() { return _speed; }
    }
}
