using System;

[Serializable]
public class Item
{
    public int id;
    public string itemName;
    public string itemDescription;

    public Item(int id, string itemName, string itemDescription){
        this.id = id;
        this.itemName = itemName;
        this.itemDescription = itemDescription;
    }
    public int getId() { return id; }
    public string getItemName() { return itemName;}
    public string getItemDescription() { return itemDescription;}
}
