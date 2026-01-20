using System.Collections.Generic;

namespace StarServer.Utils
{
    public static class ProcessManager
    {
        private static List<Process> processes = new List<Process>();
        private static int nextPid = 1;

        public static void AddProcess(Process process)
        {
            process.PID = nextPid++;
            processes.Add(process);
            process.Start();
        }

        public static void Update()
        {
            for (int i = 0; i < processes.Count; i++)
            {
                var proc = processes[i];

                if (proc.State == ProcessState.Running)
                {
                    proc.Update();
                }
            }
        }

        public static void KillProcess(int pid)
        {
            for (int i = 0; i < processes.Count; i++)
            {
                if (processes[i].PID == pid)
                {
                    processes[i].Stop();
                    processes.RemoveAt(i);
                    return;
                }
            }
        }
    }
}
