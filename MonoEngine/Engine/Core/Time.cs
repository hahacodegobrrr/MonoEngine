using System.Collections.Generic;

namespace MonoEngine.Engine.Core
{
    public static class Time
    {
        public static double now { get; private set; }
        public static double deltaTime { get; private set; }

        private static Dictionary<int, Timer> timers = new Dictionary<int, Timer>();

        public static void Update(double timeSinceGameStart)
        {
            deltaTime = timeSinceGameStart - now;
            now = timeSinceGameStart;
            foreach (Timer t in timers.Values)
                t.Update(deltaTime);
        }

        //returns id of timer (should be stored by caller)
        public static int StartNewTimer()
        {
            //find next available timer id
            int i = 0;
            while (timers.ContainsKey(i))
                i++;
            timers.Add(i, new Timer());
            return i;
        }

        public static double GetElapsedTimeOfTimer(int timerId)
        {
            return timers.ContainsKey(timerId) ? timers[timerId].timeElapsed : 0;
        }

        public static double GetDeltaTimeOfTimer(int timerId)
        {
            return timers.ContainsKey(timerId) ? timers[timerId].deltaTime : 0;
        }

        public static void ResumeTimer(int timerId)
        {
            if (timers.ContainsKey(timerId)) timers[timerId].active = true;
        }

        public static void PauseTimer(int timerId)
        {
            if (timers.ContainsKey(timerId)) timers[timerId].active = false;
        }

        public static void DeleteTimer(int timerId)
        {
            if (timers.ContainsKey(timerId))
                timers.Remove(timerId);
        }
    }

    public class Timer
    {
        public bool active;
        public double deltaTime { get; private set; }
        public double timeElapsed { get; private set; }

        public Timer()
        {
            active = true;
            deltaTime = 0;
            timeElapsed = 0;
        }

        public void Update(double deltaTime)
        {
            if (active)
            {
                this.deltaTime = deltaTime;
                timeElapsed += deltaTime;
            }
        }
    }
}
