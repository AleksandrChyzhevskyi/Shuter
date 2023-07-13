namespace Assets.Scripts
{
    internal class Healths
    {
        private int _maxPoints;
        private int _points;
        private bool _isLife;

        public Healths(int maxPoints)
        {
            _maxPoints = maxPoints;
            _points = _maxPoints;
            _isLife = true;
        }

        public int Points => _points;
        public bool IsLife => _isLife;

        public void TakeAwayPoints(int value)
        {
            if (value < 0)
                return;

            if (value > _points)
            {
                _points = 0;
                _isLife = false;
            }
            else
            {
                _points -= value;
            }
        }

        public void RestorePoints(int value)
        {
            if (value < 0)
                return;

            if (_points + value > _maxPoints)
            {
                _points = _maxPoints;
            }
            else
            {
                _points += value;
            }
        }
    }
}
