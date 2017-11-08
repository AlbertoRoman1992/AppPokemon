using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using Java.Lang;

namespace appPokemon.Models.Prueba
{
    public class Worker
    {
        // This method will be called when the thread is started.
        public void DoWork()
        {
            while (!_shouldStop)
            {
                Debug.WriteLine("worker thread: working...");
            }
            Debug.WriteLine("worker thread: terminating gracefully.");
        }
        public void RequestStop()
        {
            _shouldStop = true;
        }
        // Volatile is used as hint to the compiler that this data
        // member will be accessed by multiple threads.
        private volatile bool _shouldStop;
    }

    public class WorkerThreadExample
    {
        public WorkerThreadExample()
        {
            Main();
        }

        static void Main()
        {
            // Create the thread object. This does not start the thread.
            Worker workerObject = new Worker();
            Thread workerThread = new Thread(workerObject.DoWork);
            
            // Start the worker thread.
            workerThread.Start();
            Debug.WriteLine("main thread: Starting worker thread...");

            // Loop until worker thread activates.
            while (!workerThread.IsAlive) ;

            // Put the main thread to sleep for 1 millisecond to
            // allow the worker thread to do some work:
            Thread.Sleep(1);

            // Request that the worker thread stop itself:
            workerObject.RequestStop();

            // Use the Join method to block the current thread 
            // until the object's thread terminates.
            workerThread.Join();
            Debug.WriteLine("main thread: Worker thread has terminated.");
        }
    }
}
