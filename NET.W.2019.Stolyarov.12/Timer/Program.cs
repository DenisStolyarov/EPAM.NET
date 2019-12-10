using System;

namespace Clock
{
    public class WorkerThreadExample
    {
        public static void Main()
        {
            Timer timer = new Timer();
            Second second = new Second();
            Minute minute = new Minute();
            Hour hour = new Hour();

            timer.Add(second);
            timer.Add(minute);
            timer.Add(hour);

            timer.Start(6000);

            timer.Remove(hour);

            timer.Start(6000);
        }
    }
}