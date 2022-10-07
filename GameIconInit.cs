using Microsoft.Xna.Framework;

namespace Screensaver
{
    internal class GameIconInit
    {
        private string _iconPath;
        private Vector2 _startPosition;
        private Vector2 _direction;
        private double _speed;

        public GameIconInit(string iconPath, Vector2 startPosition, Vector2 direction, double speed)
        {
            _iconPath = iconPath;
            _startPosition = startPosition;
            _direction = direction;
            _speed = speed;
        }

        public string GetIconPath() { return _iconPath; }
        public Vector2 GetStartPosition() { return _startPosition; }
        public Vector2 GetDirection() { return _direction; }
        public double GetSpeed() { return _speed; }
    }
}
