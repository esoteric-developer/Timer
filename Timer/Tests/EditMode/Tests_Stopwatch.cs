using EC.Timer;
using NUnit.Framework;

namespace Timer.Tests.EditMode
{
    [TestFixture]
    public class Tests_Stopwatch
    {
        [Test]
        public void IsStopwatchStartsSuccessfully()
        {
            ITimer stopWatch = new StopWatch();
            stopWatch.Start();
            Assert.That(stopWatch.Status is Status.Active);
        }

        [Test]
        public void IsStopwatchPausesSuccessfully()
        {
            IPausable stopwatch = new StopWatch();
            stopwatch.Pause();
            Assert.That(stopwatch.IsPaused);
        }

        [Test]
        public void IsStopwatchResumesSuccessfully()
        {
            IPausable stopwatch = new StopWatch(true);
            stopwatch.Pause();
            Assert.That(stopwatch.IsPaused);
            stopwatch.Resume();
            Assert.That(!stopwatch.IsPaused);
        }

        [Test]
        public void IsStopwatchStopsSuccessfully()
        {
            ITimer stopwatch = new StopWatch(true);
            Assert.That(stopwatch.Status is Status.Active);
            stopwatch.Stop();
            Assert.That(stopwatch.Status is Status.Inactive);
        }

        [Test]
        public void IsStopwatchRestartsSuccessfully()
        {
            bool restarted = false;
            ITimer stopwatch = new StopWatch();
            stopwatch.OnRestart += () => restarted = true;
            stopwatch.Start();
            stopwatch.Restart();
            Assert.That(restarted);
        }
    }
}
