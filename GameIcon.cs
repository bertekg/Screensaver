﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Screensaver
{
    internal class GameIcon
    {
        private Texture2D _gameIcon;
        private Vector2 _iconPosition;
        private double _speed;
        private Vector2 _directionMove;
        private Vector2 _targetPostion;

        private float currChangeValue;
        private float _screenWidth, _screenHeight;
        private float _iconWidth, _iconHeight;

        public GameIcon(Texture2D gameIcon, Vector2 iconPosition, double speed, Vector2 direction, 
            float screenWidth, float screenHeight)
        {
            _gameIcon = gameIcon;
            _iconPosition = iconPosition;
            _speed = speed;
            _directionMove = direction;
            _targetPostion = new Vector2();
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
            _iconWidth = gameIcon.Width;
            _iconHeight = gameIcon.Height;
        }
        public void UpdateIconPosition(double elepsedTime)
        {
            currChangeValue = (float)(_speed * elepsedTime);

            _targetPostion.X = _iconPosition.X + (_directionMove.X * currChangeValue);

            if (_directionMove.X > 0)
            {
                if (_targetPostion.X < _screenWidth - _iconWidth)
                {
                    _iconPosition.X = _targetPostion.X;
                }
                else
                {
                    _iconPosition.X = 2 * (_screenWidth - _iconWidth) - _targetPostion.X;
                    _directionMove.X = -_directionMove.X;
                }
            }
            else
            {
                if (_targetPostion.X > 0)
                {
                    _iconPosition.X = _targetPostion.X;
                }
                else
                {
                    _iconPosition.X = -_targetPostion.X;
                    _directionMove.X = -_directionMove.X;
                }
            }

            _targetPostion.Y = _iconPosition.Y + (_directionMove.Y * currChangeValue);

            if (_directionMove.Y > 0)
            {
                if (_targetPostion.Y < _screenHeight - _iconHeight)
                {
                    _iconPosition.Y = _targetPostion.Y;
                }
                else
                {
                    _iconPosition.Y = 2 * (_screenHeight - _iconHeight) - _targetPostion.Y;
                    _directionMove.Y = -_directionMove.Y;
                }
            }
            else
            {
                if (_targetPostion.Y > 0)
                {
                    _iconPosition.Y = _targetPostion.Y;
                }
                else
                {
                    _iconPosition.Y = -_targetPostion.Y;
                    _directionMove.Y = -_directionMove.Y;
                }
            }
        }
        public void DrawIcon(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_gameIcon, _iconPosition, Color.White);
        }
    }
}
