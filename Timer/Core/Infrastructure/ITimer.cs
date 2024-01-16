using System;

namespace EC.Timer
{
    /// <summary>
    /// An interface for the time-based things like countdowns, stopwatches etc. 
    /// </summary>
    public interface ITimer
    {
        /// <summary>
        /// 
        /// </summary>
        Status Status { get; }

        /// <summary>
        /// 
        /// </summary>
        float StartTime { get; }

        /// <summary>
        /// 
        /// </summary>
        float StopTime { get; }

        /// <summary>
        /// 
        /// </summary>
        float ElapsedTime { get; }
        
        /// <summary>
        /// 
        /// </summary>
        event Action OnStart;

        /// <summary>
        /// 
        /// </summary>
        event Action OnStop;
        
        /// <summary>
        /// 
        /// </summary>
        event Action OnRestart;

        /// <summary>
        /// 
        /// </summary>
        void Start();

        /// <summary>
        /// 
        /// </summary>
        void Stop();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deltaTime"></param>
        void Tick(float deltaTime);

        /// <summary>
        /// 
        /// </summary>
        void Reset();
        
        /// <summary>
        /// 
        /// </summary>
        void Restart();
    }
}
