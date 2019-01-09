using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;          //Install-Package System.Threading.Tasks.Dataflow -Version 4.9.0 
using ConsoleA1._00_Common;
using static ConsoleA1._00_Common.Statics;
using static ConsoleA1._21_Tasks_Threads_Synchronization.Tasks;

using con = System.Console;
using rws = ConsoleA1._21_Tasks_Threads_Synchronization.ReaderWriterSim;

namespace ConsoleA1._21_Tasks_Threads_Synchronization
{
    class _Main1
    {
        public static void Main(string[] args)
        {
            int doCase = 27;
            bool waitReq = true;
            CancellationTokenSource cts2 = null;
            switch (doCase)
            {
                #region Cases 1 - nn Done                
                case 1:
                    con.WriteLine($"Start Looping with Parallel.For!");

                    ParallelLoopResult pRes = Parallel.For(0, 10, i =>
                    {
                        Thread.Sleep(10000 - i * 1000); //Old Way of doing it... 
                        con.WriteLine(
                            $"Iteration {i}, Task: {Task.CurrentId}, Thread: {Thread.CurrentThread.ManagedThreadId}");
                    });

                    con.WriteLine($"First set completed? {pRes.IsCompleted}");
                    break;
                case 2:
                    //Adding the async and wait key words
                    ParallelLoopResult pRes2 = Parallel.For(100, 110, async i =>
                    {
                        try
                        {
                            con.WriteLine(
                                $"Iteration {i}, Task: {Task.CurrentId}, Thread: {Thread.CurrentThread.ManagedThreadId}");
                            await Task.Delay(10000 - i * 10);
                        }
                        catch (Exception e)
                        {
                            con.WriteLine($"Error: {e.Message}!");
                        }

                        con.WriteLine(
                            $"Iteration {i}, Task: {Task.CurrentId}, Thread: {Thread.CurrentThread.ManagedThreadId}");
                    });

                    con.WriteLine($"All Threads completed! {pRes2.IsCompleted}");
                    break;
                
                case 3:
                    //Adding the Break method which dose not quite work like the documentation seems to be telling me! Break must be before await keyword!          
                    var brk = 15;
                    ParallelLoopResult pRes3 = Parallel.For(10, 20, async (i, pLS) =>
                    {
                        if (i >= brk)
                            pLS.Break();

                        try
                        {
                            con.WriteLine(
                                $"3rd Loop Iteration {i}, Task: {Task.CurrentId}, Thread: {Thread.CurrentThread.ManagedThreadId}");
                            await Task.Delay(10);
                        }
                        catch (Exception e)
                        {
                            con.WriteLine($"Iteration {i}, Error: {e.Message}!");
                        }

                        con.WriteLine(
                            $"3rd Loop Iteration {i}, Task: {Task.CurrentId}, Thread: {Thread.CurrentThread.ManagedThreadId}");

                    });

                    con.WriteLine($"3rd Loop - All Threads completed! {pRes3.IsCompleted}");
                    con.WriteLine($"Last iteration: {pRes3.LowestBreakIteration}"); //This is null 
                    break;
                case 4:
                    //Getting funky now...
                    con.WriteLine($"Lets get funky when you are ready hit a key!");
                    con.ReadLine();
                    Parallel.For<string>(0, 2, () =>
                        {
                            // Invoked once for each thread...
                            con.WriteLine(
                                $"Init for thread {Thread.CurrentThread.ManagedThreadId}, task {Task.CurrentId}");

                            return String.Format($"t{Thread.CurrentThread.ManagedThreadId}");   //returns to initStr1.
                        }, (i, pLs, initStr1) =>
                        {
                            // Invoked for each member.
                            con.WriteLine(
                                $"Body i {i}, str {initStr1}, thread {Thread.CurrentThread.ManagedThreadId}, task {Task.CurrentId}");
                            Thread.Sleep(10);
                            return $"i {i}";    //this is the return type for the For<string>
                        },
                        (str1) =>   //exit method
                        {
                            //Final action on each thread
                            con.WriteLine($"Finally {str1}");
                        });

                    con.WriteLine($"What happened there!");
                    break;
                case 5:
                    //Looping with the Parallel.ForEach
                    string[] sample =
                    {
                        "zéro", "un", "deux", "trois", "quatre", "cinq", "six", "sept", "huit", "neuf", "dix", "onze",
                        "douze", "trize", "quatorze", "quinze", "seize"
                    };
                    ParallelLoopResult plRes = Parallel.ForEach<string>(sample, (s, spl, lItr) => {con.WriteLine($"{lItr} - {s}"); });
                    break;

                case 6:
                    // Multiple Methods with Parallel.Invoke
                    try
                    {
                        Parallel.Invoke(bonjour("Jane"),bonjour("Paul"),bonjour("Jon"), bienvenue("Jane"), au_revoir("Jon"));
                    }
                    catch (Exception e)
                    {     
                        con.WriteLine($"{e.Message} - Actions should be null!");
                    }
                    break;
                case 7:
                    //Starting Tasks 1. TaskFactory 2. Factory via class 3. Task Constructor 4. Run method 
                    var tf = new TaskFactory();
                    Task t1 = tf.StartNew(Tasks.TaskMethod, "Using a TaskFactory Object!");
                  
                    Task t2 = Task.Factory.StartNew(Tasks.TaskMethod, "Using the Factory via a Task class");
                    
                    var t3 = new Task(Tasks.TaskMethod, "Using a Task constructor and the Start method");
                    t3.Start();

                    Task.Run(() => Tasks.TaskMethod("Using the Run method and Lambda syntax"));
                    
                    break;

                case 8:
                    //Now with TaskCreation Options
                    Tasks.TaskMethod("Now sure this will work!");
                    var t4 = new Task(Tasks.TaskMethod, "Running on new Thread.");
                    t4.Start();
                    Tasks.TaskMethod("What Thread Am I?");
                    var t5 = new Task(Tasks.TaskMethod, "Running Synchronously on the same Thread.");
                    t5.RunSynchronously();

                    //What if we know a Task is going to take some time!
                    var lT1 = new Task(Tasks.TaskMethod, "A Long Runner!", TaskCreationOptions.LongRunning);
                    lT1.Start();
                    Thread.Sleep(10);
                    if (lT1.Status == TaskStatus.RanToCompletion)
                        lT1.Dispose();
                        // lT1.RunSynchronously(); can't do this !

                    //Futures because the result it going to be in the future!
                    var rT1 = new Task<Tuple<int, int>>(Tasks.TaskWithRes, Tuple.Create<int, int>(19, 3));
                    rT1.Start();
                    rT1.Wait();
                    con.WriteLine(rT1.Result);                    
                    con.WriteLine($"Results: Res = {rT1.Result.Item1}; Rem = {rT1.Result.Item2}");                                        
                    break;
                case 9:
                    //Continuation Tasks
                    Task t1T = new Task(DoOnFirst);
                    Task cT1 = t1T.ContinueWith(DoOnSecond);
                    Task cT2 = t1T.ContinueWith(DoOnSecond);
                    Task cT1_3 = cT1.ContinueWith(DoOnSecond, TaskContinuationOptions.OnlyOnFaulted);
                    t1T.Start();
                    break;
                case 10:
                    //Task Hierarchies
                    con.WriteLine($"Parent and Child Tasks....");
                    Task pC = new Task(ParentAndChild);
                    pC.Start();
                    break;
                case 11:
                    // Cancellation methods.
                    var cts = new CancellationTokenSource();
                    cts.Token.Register(() => con.WriteLine($"*** Token Canceled ***"));

                    //Send or Cancel after 500 ms.
                    cts.CancelAfter(500);

                    try
                    {
                        ParallelLoopResult plr = Parallel.For(0, 20, new ParallelOptions()
                            {
                                CancellationToken = cts.Token,
                            },
                            x =>
                            {
                                con.WriteLine($"Itr {x}");
                                Thread.Sleep(1000);
                                con.WriteLine($"{x}: Why did I get here?");
                            }
                        );
                        con.WriteLine($"Result: {plr.IsCompleted}");
                    }
                    catch (OperationCanceledException oce)
                    {
                        con.WriteLine($"Operation cancelled in time: {oce.Message}!");
                    }
                    
                    //Same cancellation pattern used with tasks.
                    //Can't use the sane token as has already been cancelled!

                    cts2.Token.Register(() => con.WriteLine($"*** Token Canceled ***"));
                    cts2.CancelAfter(500);
                    
                    //Create the task.
                    Task ct1 = Task.Run(() =>
                        {
                            con.WriteLine($"Im In the Task....");
                            for (int i = 0; i < 20; i++)
                            {
                                Thread.Sleep(100);
                                CancellationToken cToken = cts2.Token;
                                if (cToken.IsCancellationRequested)
                                {
                                    con.WriteLine($"Cancel has been requested! Cancelling from within task i={i}");
                                    cToken.ThrowIfCancellationRequested();
                                    break; //Not liking this breaking all over the place....
                                }
                                con.WriteLine($"Bottom of loop {i}");
                            }

                            con.WriteLine($"Finished with out cancellation.");
                        }
                    );

                    //Run the Task
                    try
                    {
                        ct1.Wait();
                    }
                    catch (AggregateException aEx)
                    {
                        con.WriteLine($"Aggregate Exception: {aEx.GetType()}, {aEx.Message}");
                        foreach (var iEx in aEx.InnerExceptions)
                        {
                            con.WriteLine($"Inner exception: {iEx.GetType()}, {iEx.Message}");
                        }
                    }
                    break;
                
                case 12:
                    //Thread Pools.....Notes: All are background threads and will end when the job does.
                    int nWorkerThreads;
                    int nCompletionPortThreads;
                    ThreadPool.GetMaxThreads(out nWorkerThreads, out nCompletionPortThreads);
                    con.WriteLine($"Max w threads: {nWorkerThreads}. I/O comp threads: {nCompletionPortThreads}");

                    for (int i = 0; i < 100; i++)
                    {
                        ThreadPool.QueueUserWorkItem(JobForAThread);
                    }

                    break;                

                case 13:
                    // The Thread Class...
                    var countDown = new Thread(ThreadMain);
                    countDown.Start();
                    con.WriteLine($"Main thread.");

                    //Passing Data To Threads 1.ParameterizedThreadStart 2.Defined Class
                    var d = new TData {Message = "Far Far Away..."};
                    var pT1 = new Thread(MThread);
                    pT1.Start(d);
                
                    //2. Use MyThread class....
                    var tC = new TClass("Stop Stop Stop");
                    var cT = new Thread(tC.TSend);
                    cT.Start();

                    //Background Threads
                    var pT2 = new Thread(MThread) {Name = "MyNewThread", IsBackground = true};
                    pT2.Start(d);
                    break;

               case 14:
                    //Race Condition
                    var state = new StateObject();
                    for (int i = 0; i < 2; i++)
                    {
                        Task.Run(() => new RaceClass().RaceCondition(state));
                    }
                    break;

                case 15:
                    //Race Condition With Lock
                    var state2 = new StateObject();
                    for (int i = 0; i < 2; i++)
                    {
                        Task.Run(() => new RaceClass().RaceConditionLock(state2));
                    }
                    break;

                case 16:
                    //Race Condition
                    var state3 = new StateObjectWithLock();
                    for (int i = 0; i < 2; i++)
                    {
                        Task.Run(() => new RaceClass().RaceConditionSyncObject(state3));
                    }
                    break;
                
                case 17:
                    //Deadlocks
                    var stateL1 = new StateObjectWithLock();
                    var stateL2 = new StateObjectWithLock();
                    new Task(new DeadLock(stateL1, stateL2).DeadLock1).Start();
                    new Task(new DeadLock(stateL1, stateL2).DeadLock2).Start();
                    break;
                
                case 18:
                    //Synchronization to avoid deadlocks
                    SyncWorker.main();
                    SyncWorker.main();
                    break;
                
                case 19:
                    Interlocking inter = new Interlocking();

                    Task.Run(() => inter.AddToValue(10));
                    Task.Run(() => inter.AddToValue(20));
                    Thread.Sleep(100);
                    Task.Run(() => inter.AddToValue(30));
                    Task.Run(() => inter.AddToValue(40));

                    con.WriteLine($"{inter.Total}");

                    Task ct2 = Task.Run(() =>
                    {
                        Task.Run(() => inter.AddToValue(10));
                        Task.Run(() => inter.AddToValue(20));
                        Thread.Sleep(100);
                        Task.Run(() => inter.AddToValue(30));
                        Task.Run(() => inter.AddToValue(40));

                    });

                    ct2.Wait();
                    
                    con.WriteLine($"{inter.Total}");
                    break;

                case 20:
                    Monitors.WMain();
                    break;

                case 21:
                    MutexesNSemaphores.MainMutex();
                    con.WriteLine("Now for the Semaphore thing.");
                    MutexesNSemaphores.MainSemephore();
                    break;

                case 22:
                    con.Write("Some event watching possible!");
                    SysWideEvents.SWEMain();
                    break;
                
                case 23:
                    con.Write("Using the Countdown event...");
                    SysWideEvents.SWECountDown();
                    break;

                case 24:
                    const int nTasks = 2;
                    const int pSize = 100000;
                    var data = new List<string>(DataFunctions.FillData(pSize * nTasks));
                    
                    var bar = new Barrier(nTasks + 1);

                    var tasks = new Task<int[]>[nTasks];

                    for (int i = 0; i < nTasks; i++)
                    {
                        int jNo = i;
                        tasks[i] = Task.Run(() => BarrierStuff.CalcInTask(jNo, pSize, bar, data));
                    }

                    con.WriteLine($"Signal and Wait! bar pCount{bar.ParticipantCount} ");
                    bar.SignalAndWait();
                    var resultCol = tasks[0].Result.Zip(tasks[1].Result, (c1, c2) => c1 + c2);
                    

                    char ch = 'a';
                    int sum = 0;
                    foreach (var x in resultCol)
                    {
                        con.WriteLine($"{ch++}, count: {x}");
                        sum += x;
                    }

                    con.WriteLine($"Main finished {sum}");
                    con.WriteLine("remaining {0}, phase {1}", bar.ParticipantsRemaining, bar.CurrentPhaseNumber);

                    break;                

                case 25:
                    con.WriteLine($"Read Writer Lock Simulation when one needs many readers but only one writer!");

                    var tFact = new TaskFactory(TaskCreationOptions.LongRunning, TaskContinuationOptions.None);
                    var t25 = new Task[16];

                    t25[0] = tFact.StartNew(rws.WriteMethod, 1);
                    t25[1] = tFact.StartNew(rws.ReaderMethod, 1);
                    
                    t25[2] = tFact.StartNew(rws.ReaderMethod, 2);
                    t25[3] = tFact.StartNew(rws.WriteMethod, 2);
                    
                    t25[4] = tFact.StartNew(rws.ReaderMethod, 3);
                    
                    t25[5] = tFact.StartNew(rws.ReaderMethod, 4);

                    for (int i = 0; i < 6; i++)
                    {
                        t25[i].Wait();
                    }

                    con.WriteLine($"All Done!");
                    break;


                case 26:
                    con.WriteLine($"Looking at Timers....");
                    Timers.ThreadingTimer();

                    con.WriteLine($"Looking at Timers....");
                    Timers.TTimer();
                    break;

                #endregion Cases 1 - nnn

                case 27:
                    con.WriteLine($"Task Parallel Library Data Flow....");

                    var pInput = new ActionBlock<string>(s =>
                    {
                        con.WriteLine($"Last Entry: {s}");
                    });

                    bool exit = false;
                    while (!exit)
                    {
                        Thread.Sleep(1000);
                        con.Write($"Enter:");
                        string input = con.ReadLine();
                        if (string.Compare(input, "exit", ignoreCase: true) == 0)
                        {
                            exit = true;
                        }
                        else
                        {
                            pInput.Post(input);
                        }
                    }
                    
                    //BufferBlock for Source and Target
                    Task b1 = Task.Run(() => DataFlowStuff.Producer());
                    Task b2 = Task.Run(() => DataFlowStuff.Consumer());
                    Task.WaitAll(b1, b2);
                    break;
                default:
                    break;
            }

            
            

            
            var test = "Abc";
            switch (test)
            {
                case "Abc":
                    break;
            }


            //ToDo: Test Staging
            if (waitReq)
            {
                con.ReadLine();
            }
        }
    
      
    }
    
}
