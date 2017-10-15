using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GraphicTestProject
{
    class FPS
    {
        DateTime _lastCheckTime = DateTime.Now;
        long _frameCount = 0;
        public void OnMapUpdated()
        {
            Interlocked.Increment(ref _frameCount);
        }

        public double GetFps()
        {
            double secondsElapsed = (DateTime.Now - _lastCheckTime).TotalSeconds;
            long count = Interlocked.Exchange(ref _frameCount, 0);
            double fps = count / secondsElapsed;
            _lastCheckTime = DateTime.Now;
            return fps;
        }

    }
}
