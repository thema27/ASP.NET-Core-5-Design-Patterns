﻿using System.Linq;

namespace FinalChainOfResponsibility
{
    public abstract class MessageHandlerBase : IMessageHandler
    {
        private readonly IMessageHandler _next;
        public MessageHandlerBase(IMessageHandler next = null)
        {
            _next = next;
        }

        public void Handle(Message message)
        {
            if (CanHandle(message))
            {
                Treat(message);
            }
            else if (HasNext())
            {
                _next.Handle(message);
            }
        }

        private bool HasNext()
        {
            return _next != null;
        }

        protected abstract bool CanHandle(Message message);
        protected abstract void Treat(Message message);
    }
}
