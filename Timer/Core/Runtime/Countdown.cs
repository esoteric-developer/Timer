using System;
using UnityEngine;

namespace EC.Timer
{
    /// <summary>
    /// 
    /// </summary>
    public class Countdown : IPausable, ITimer
    {
        public Status Status { get; private set; } = Status.Inactive;
        public bool IsPaused { get; private set; } = false;
        public float StartTime { get; private set; } = -1;
        public float StopTime { get; private set; } = -1;
        public float ElapsedTime { get; private set; } = 0;
        public float TimeOutTime { get; private set; } = -1;
        public float RemainingTime { get; private set; } = float.MaxValue;
        public float CountdownTime { get; private set; } = -1;

        public event Action OnStart;
        public event Action OnStop;
        public event Action OnPause;
        public event Action OnResume;
        public event Action OnRestart;
        public event Action OnTimeOut;

        private Countdown()
        {
        }

        public Countdown(float countdownTime, bool autoStart = false, Action onTimeOut = null)
        {
            if (countdownTime <= 0f)
            {
                const string errorMessage = "Countdown time must be greater than 0!";
                throw new ArgumentOutOfRangeException(nameof(countdownTime), countdownTime, errorMessage);
            }
            this.CountdownTime = countdownTime;
            this.RemainingTime = countdownTime;
            this.OnTimeOut = onTimeOut;
            if (autoStart) Start();
        }

        public void Start()
        {
            this.Status = Status.Active;
            this.StartTime = Time.time;
            OnStart?.Invoke();
        }

        public void Stop()
        {
            this.Status = Status.Inactive;
            this.StopTime = Time.time;
            OnStop?.Invoke();
        }

        public void Pause()
        {
            IsPaused = true;
            OnPause?.Invoke();
        }

        public void Resume()
        {
            IsPaused = false;
            OnResume?.Invoke();
        }

        public void Reset()
        {
            this.Status = Status.Inactive;
            this.IsPaused = false;
            this.StartTime = default;
            this.ElapsedTime = default;
            this.TimeOutTime = default;
            this.RemainingTime = CountdownTime;
        }

        public void Restart()
        {
            Reset();
            Start();
            OnRestart?.Invoke();
        }

        public void Tick(float deltaTime)
        {
            if (Status is Status.Inactive || IsPaused) return;

            this.RemainingTime -= deltaTime;
            this.ElapsedTime += deltaTime;

            if (RemainingTime > 0) return;
            
            TimeOut();
        }

        private void TimeOut()
        {
            this.TimeOutTime = Time.time;
            this.Status = Status.Inactive;
            OnTimeOut?.Invoke();
        } 
    }
}
