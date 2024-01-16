using System;
using UnityEngine;

namespace EC.Timer
{
    public class StopWatch : ITimer, IPausable
    {
        public Status Status { get; private set; } = Status.Inactive;
        public bool IsPaused { get; private set; } = false;
        public float StartTime { get; private set; } = -1;
        public float StopTime { get; private set; } = -1;
        public float ElapsedTime { get; private set; } = 0;

        public event Action OnStart;
        public event Action OnPause;
        public event Action OnResume;
        public event Action OnStop;
        public event Action OnRestart;

        public StopWatch(bool autoStart = false)
        {
            if (autoStart) Start();
        }

        public void Start()
        {
            Status = Status.Active;
            StartTime = Time.time;
            OnStart?.Invoke();
        }

        public void Stop()
        {
            if (Status is Status.Inactive) return;
            Status = Status.Inactive;
            StopTime = Time.time;
            OnStop?.Invoke();
        }

        public void Tick(float deltaTime)
        {
            if (Status is Status.Inactive || IsPaused) return;
            ElapsedTime += deltaTime;
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
            Status = Status.Inactive;
            IsPaused = false;
            ElapsedTime = 0;
            StartTime = -1;
            StopTime = -1;
        }
        
        public void Restart()
        {
            Reset();
            Start();
            OnRestart?.Invoke();
        }
    }
}
