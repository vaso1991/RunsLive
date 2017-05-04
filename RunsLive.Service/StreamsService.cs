using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RunsLive.Models.BindingModels;
using RunsLive.Models.EntityModels;
using RunsLive.Models.ViewModels;
using RunsLive.Service.Interfaces;


namespace RunsLive.Service
{

    public class StreamsService:Service, IStreamsService
    {
       
        public void AddNewRequest(RequestStreamBindingModel bind, string username)
        {
            ApplicationUser currentUser = this.Context.Users.FirstOrDefault(u => u.UserName == username);
            StreamRequest model = Mapper.Map<RequestStreamBindingModel, StreamRequest>(bind);
            this.Context.StreamRequests.Add(model);
            currentUser.StreamRequests.Add(model);
            Context.SaveChanges();
        }

        public IEnumerable<StreamsViewModel> GetAllStreams()
        {
            IEnumerable<Stream> streams = Context.Streamers.ToArray();
            IEnumerable<StreamsViewModel> models =
                Mapper.Map<IEnumerable<Stream>, IEnumerable<StreamsViewModel>>(streams);
            return models;
        }
        

    }
}
