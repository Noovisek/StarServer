namespace StarServer.Utils
{
    public enum ProcessState
    {
        Ready,
        Running,
        Sleeping,
        Stopped
    }

    public abstract class Process
    {
        public int PID { get; internal set; }
        public string Name { get; private set; }
        public ProcessState State { get; protected set; }

        protected Process(string name)
        {
            Name = name;
            State = ProcessState.Ready;
        }

        // wywoływane raz przy starcie
        public virtual void Start()
        {
            State = ProcessState.Running;
        }

        // wywoływane co tick
        public abstract void Update();

        // zatrzymanie procesu
        public virtual void Stop()
        {
            State = ProcessState.Stopped;
        }
    }
}
