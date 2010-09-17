using System;
using StructureMap;

namespace Pes.Core
{
    public interface IMessageService
    {
        void SendMessage(string Body, string Subject, string[]To);
    }
}
