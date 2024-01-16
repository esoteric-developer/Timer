using System;

namespace EC.Timer
{
    /// <summary>
    /// An interface for a pausable things like Game, Minigames, Timer, Countdown, Stopwatch etc.
    /// </summary>
    public interface IPausable
    {
        /// <summary>
        /// 
        /// </summary>
        bool IsPaused { get; }

        /// <summary>
        /// 
        /// </summary>
        event Action OnPause;

        /// <summary>
        /// 
        /// </summary>
        event Action OnResume;

        /// <summary>
        /// 
        /// </summary>
        void Pause();

        /// <summary>
        /// 
        /// </summary>
        void Resume();
    }
}
