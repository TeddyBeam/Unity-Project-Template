using System;
using System.Collections.Generic;

namespace ApplicationLayer
{
    /// <summary>
    /// The object can be run and stop manually.
    /// All objects that have consecutive work (Update, Physic detection, Coroutine,...) should implement this interface.
    /// </summary>
    public interface IRunnable
    {
        void Run();
        void Stop();
        bool IsRunning { get; }
    }
}
