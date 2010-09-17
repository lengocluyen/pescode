namespace Pes.Core
{
    public class MessageWithRecipient
    {
        public Account Sender { get; set; }
        public Messages Message { get; set; }
        public MessageRecipient MessageRecipient { get; set; }
    }
}
