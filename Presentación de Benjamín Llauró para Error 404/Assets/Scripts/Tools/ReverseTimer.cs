namespace Tools
{
    public class ReverseTimer
    {
        enum State
        {
            None,
            Running,
            Finished
        }
        private float timer = 0.0f;
        private float accum = 0.0f;
        private float restartAccum = 0.0f;
        private State state = State.None;

        #region Management Orders
        public void Start()
        {
            state = State.Running;
        }

        public void StopAndReset()
        {
            accum = restartAccum;
            state = State.None;
        }

        public void SetTimer(float time)
        {
            timer = 0.0f;
            accum = time;
            restartAccum = time;
        }
        #endregion

        #region Getters
        public bool GetStarted()
        {
            if (state == State.Running)
                return true;
            else
                return false;
        }
        public bool GetFinished()
        {
            if (state == State.Finished)
                return true;
            else
                return false;
        }
        public float GetCurrentTime()
        {
            return accum;
        }
        #endregion

        public bool Update(float dt)
        {
            if (state == State.Running)
            {
                accum -= dt;
                if (accum <= timer)
                {
                    state = State.Finished;
                    return true;
                }
            }
            else if (state == State.Finished)
                return true;

            return false;
        }
    }
}
