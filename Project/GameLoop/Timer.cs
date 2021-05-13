using SFML.System;
using System;
using System.Collections.Generic;

namespace Project
{
    public class Timer
    {
        public float deltaTime;
        public float TimeScale;
        public event Action<float> TimeUpdate;
        public List<InvokeAction> repeatActions;

        private float TotalTimeElapsed => _clock.ElapsedTime.AsSeconds();
        private float _totalTimeBeforeUpdate;
        private float _updateTime;
        private float _previosTimeElapsed;
        private Clock _clock;
        public Timer()
        {
            deltaTime = 0f;
            _totalTimeBeforeUpdate = 0f;
            _previosTimeElapsed = 0f;
            TimeScale = 1f;
            _clock = new Clock();
            repeatActions = new();
        }
        public void Init(float updates)
            =>_updateTime = 1f/updates;
        public bool IsUpdate()
        {
            _totalTimeBeforeUpdate += TotalTimeElapsed - _previosTimeElapsed;
            _previosTimeElapsed = TotalTimeElapsed;
            if (_totalTimeBeforeUpdate >= _updateTime)
            {
                deltaTime = _totalTimeBeforeUpdate * TimeScale;
                TimeUpdate?.Invoke(deltaTime);
                _totalTimeBeforeUpdate = 0;
                return true;
            }
            return false;
        }
        public void Invoke(Action action, float startTime)
            =>new InvokeAction(this, action, startTime);
        public void InvokeRepeating(Action action, float startTime, float repeatTime)
            =>repeatActions.Add(new InvokeRepeatingAction(this, action, startTime, repeatTime));
    }
}
