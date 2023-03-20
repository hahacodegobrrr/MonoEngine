using System.Collections.Generic;

namespace MonoEngine.Engine.Core {
    public static class Time {
        public static double now { get; private set; }
        public static float deltaTime { get; private set; }

        private static Dictionary<string, Timer> timers = new Dictionary<string, Timer>();

        public static void Update(double timeSinceGameStart) {
            deltaTime = (float)(timeSinceGameStart - now);
            now = timeSinceGameStart;
            foreach (Timer t in timers.Values)
                t.Update(deltaTime);
        }

        public static void StartNewTimer(string timerId) {
            if (!timers.ContainsKey(timerId))
                timers.Add(timerId, new Timer());
        }

        public static double GetElapsedTimeOfTimer(string timerId) {
            return timers.ContainsKey(timerId) ? timers[timerId].timeElapsed : 0;
        }

        public static float GetDeltaTimeOfTimer(string timerId) {
            return timers.ContainsKey(timerId) ? timers[timerId].deltaTime : 0;
        }

        public static void ResumeTimer(string timerId) {
            if (timers.ContainsKey(timerId)) timers[timerId].active = true;
        }

        public static void PauseTimer(string timerId) {
            if (timers.ContainsKey(timerId)) timers[timerId].active = false;
        }

        public static void ResetTimer(string timerId) {
            if (timers.ContainsKey(timerId)) timers[timerId].timeElapsed = 0;
        }

        public static void DeleteTimer(string timerId) {
            if (timers.ContainsKey(timerId))
                timers.Remove(timerId);
        }
    }

    public class Timer {
        public bool active;
        public float deltaTime;
        public double timeElapsed;

        public Timer() {
            active = true;
            deltaTime = 0;
            timeElapsed = 0;
        }

        public void Update(float deltaTime) {
            if (active) {
                this.deltaTime = deltaTime;
                timeElapsed += deltaTime;
            }
        }
    }
}
