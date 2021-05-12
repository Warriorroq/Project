using System;

namespace Project
{
    public class InvokeRepeatingAction : InvokeAction
    {
        private float _repeatTime;
        public InvokeRepeatingAction(Timer timer, Action action, float startTime, float repeatTime) 
            : base(timer, action, startTime)
        {
            _repeatTime = repeatTime;
        }
        protected override void Invoke()
        {
            _action.Invoke();
            _startTime = _repeatTime;
        }
    }
}
