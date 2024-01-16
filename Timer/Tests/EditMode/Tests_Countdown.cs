using System;
using EC.Timer;
using NUnit.Framework;

namespace Timer.Tests.EditMode
{
    public class Tests_Countdown
    {
        [Test]
        public void IsCountdownStartsSuccessfully()
        {
            ITimer countdown = new Countdown(5);
            countdown.Start();
            Assert.That(countdown.Status is Status.Active);
        }
        
        [Test]
        public void IsCountdownPausesSuccessfully()
        {
            IPausable countdown = new Countdown(5, true);
            countdown.Pause();
            Assert.That(countdown.IsPaused);
        }
        
        [Test]
        public void IsCountdownResumesSuccessfully()
        {
            IPausable countdown = new Countdown(5, true);
            countdown.Pause();
            Assert.That(countdown.IsPaused);
            countdown.Resume();
            Assert.That(!countdown.IsPaused);
        }
        
        [Test]
        public void IsCountdownStopsSuccessfully()
        {
            ITimer countdown = new Countdown(5, true);
            Assert.That(countdown.Status is Status.Active);
            countdown.Stop();
            Assert.That(countdown.Status is Status.Inactive);
        }
        
        [Test]
        [TestCase(3), TestCase(5), TestCase(10)]
        public void IsCountdownFinishesSuccessfully(int countdownTime)
        {
            bool finished = false;
            ITimer countdown = new Countdown(countdownTime, onTimeOut:()=> finished = true);
            countdown.Start();
            countdown.Tick(countdownTime);
            Assert.That(finished);
        }

        [Test]
        [TestCase(-3), TestCase(-1), TestCase(0)]
        public void IsCountdownChecksForInvalidTime(int countdownTime)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { ITimer countdown = new Countdown(countdownTime); });
        }
        
        [Test]
        [TestCase(3), TestCase(5), TestCase(10)]
        public void IsCountdownRestartsSuccessfully(int countdownTime)
        {
            bool restarted = false;
            ITimer countdown = new Countdown(countdownTime); 
            countdown.OnRestart += () => restarted = true;
            countdown.Start();
            countdown.Restart();
            Assert.That(restarted);
        }
    }
}
