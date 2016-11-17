using System.Data.Entity;

namespace Chat.Core.DAL
{
    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<ChatContext>
    {
    }
}
