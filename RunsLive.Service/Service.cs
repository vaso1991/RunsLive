using RunsLive.Data;

namespace RunsLive.Service
{
    public abstract class Service
    {
        public Service()
        {
            this.Context = new RunsLiveContext();
        }

        protected RunsLiveContext Context { get; }
    }
}
