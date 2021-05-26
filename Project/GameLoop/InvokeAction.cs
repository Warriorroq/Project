using System;

namespace Project
{
    public class InvokeAction
    {
        protected Timer _timer;
        protected Action _action;
        protected float _startTime;
        public InvokeAction(Timer timer,Action action, float startTime)
        {
            _timer = timer;
            _timer.TimeUpdate += Act;
            _action = action;
            _startTime = startTime;
        }
        public void Act(float deltaTime)
        {
            if (_startTime <= 0)
                Invoke();
            _startTime -= deltaTime;
        }
        protected virtual void Invoke()
        {
            _action?.Invoke();
            _timer.TimeUpdate -= Act;
            _timer.RemoveInvoke(this);
        }
    }
}
