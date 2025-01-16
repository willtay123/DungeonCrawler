using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : ScriptableObject
{
    public string ID { get; private set; }
    public int MaxCount {  get; private set; }

    public override bool Equals(object obj)
    {
        return obj is ItemData other && this.Equals(other);
    }

    public bool Equals(ItemData other)
    {
        return ID == other.ID;
    }

    public override int GetHashCode()
    {
        return ID.GetHashCode();
    }
}

public class ItemInstance : ScriptableObject
{
    public ItemData Data { get; private set; }
    public int Count { get; set; }

    public ItemInstance(ItemData data)
    {
        Data = data;
    }

    public int GetMaxItemCount()
    {
        return Data.MaxCount;
    }

    public bool CanStackWith(ItemInstance otherItem)
    {
        return Data.Equals(otherItem.Data);
    }
}
