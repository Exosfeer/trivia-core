using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trivia_api.Hubs.Interfaces
{
    public interface ILearningHubClient
    {
        Task ReceiveMessage(string message);
    }
}
