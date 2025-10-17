namespace InventoryHub.Models;
public class NotificationItem
{
    public string Message { get; set; }
    public string Time { get; set; }

    public NotificationItem(string message, string time)
    {
        Message = message;
        Time = time;
    }
}