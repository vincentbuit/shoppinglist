using System;

public class ShoppingItemList
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string DateStart { get; set; } // 2012-04-23T18:25:43
    public string DateEnd { get; set; } // 2012-04-23T18:25:43
    public Item[] Items { get; set; }
}