using Microsoft.EntityFrameworkCore;
using Shared.DataBase.Domain.Models;

namespace ErrorLogs.Domain.Models.MessageDataBase
{
    public class MessageDataBase : DataBase<Message.Message, Guid>
    {
        public MessageDataBase(DbContextOptions<DataBase<Message.Message, Guid>> options) :
            base(options) { }
    }
}