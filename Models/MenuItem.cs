namespace InventoryHub.Models;
public class MenuItem
{
    public string Label { get; set; }
    public string Url { get; set; }
    public string Icon { get; set; }
    public bool IsActive { get; set; }
    public string Badge { get; set; }

    public MenuItem(string label, string url, string icon, bool isActive = false, string badge = "")
    {
        Label = label;
        Url = url;
        Icon = icon;
        IsActive = isActive;
        Badge = badge;
    }
}