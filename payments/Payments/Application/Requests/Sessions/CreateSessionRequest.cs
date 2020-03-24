using Application.Models;
using Application.Results.Sessions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Requests.Sessions
{
    public class CreateSessionRequest
         : Request<CreateSessionModel, CreateSessionResult>
    {
        public CreateSessionRequest(CreateSessionModel model, string correlationId = null) 
            : base(model, correlationId)
        { }
    }
}
