using Microsoft.Azure.Mobile.Server;

namespace Facebook.MobileApp.DataObjects
{
    public class TodoItem : EntityData
    {
        public string Text { get; set; }

        public bool Complete { get; set; }
    }
}