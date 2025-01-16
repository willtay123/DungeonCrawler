using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : ScriptableObject
{
    const int INVALID_SLOT_INDEX = -1;

    [SerializeField]
    [Min(0)]
    private int SlotCount = 10;

    private ItemInstance[] Slots;


    // Start is called before the first frame update
    public ItemContainer()
    {
        Slots = new ItemInstance[SlotCount];
    }

    public int GetNumberOfSlots()
    {
        return Slots.Length;
    }
    public bool AddSlot()
    {
        return false;
    }
    public bool RemoveSlot()
    {
        return false;
    }

    public int PushItem(ItemInstance item, int slotIndex)
    {
        if (!IsValidSlotIndex(slotIndex))
        {
            Debug.Log("Invalid slot index");
            return 0;
        }

        if (Slots[slotIndex] == null)
        {
            // nothing there, place it
            Slots[slotIndex] = item;
            return Slots[slotIndex].Count;
        }
        else
        {
            // something there, can it stack?
            if (Slots[slotIndex].CanStackWith(item))
            {
                return 0;
            }
            else
            {
                return 0;
            }
        }
    }

    public int AddItem(ItemInstance item)
    {
        // NOTE: if partial stack, we would have to re-search which is slow, want better solution

        // iterate slots
        // if empty slot, store first empty
        // iterate more and look for match
        // stack, if left over, continue to look for match
        // if end and some left, place in first empty
        // if no empty, return leftovers

        int firstMatchingIndex = GetFirstSlotIndexForId(item.Data);
        if (firstMatchingIndex == INVALID_SLOT_INDEX)
        {
            // No existing stack, find empty slot
        }

        return 0;
    }

    public ItemInstance PopItem(int slotIndex)
    {
        if (!IsValidSlotIndex(slotIndex))
        {
            return null;
        }

        if (Slots[slotIndex] == null)
        {
            return null;
        }

        ItemInstance item = Slots[slotIndex];
        Slots[slotIndex] = null;

        return item;
    }
    public ItemInstance PopItem(int slotIndex, int count)
    {
        if (!IsValidSlotIndex(slotIndex))
        {
            return null;
        }

        if (Slots[slotIndex] == null)
        {
            return null;
        }

        if (count < Slots[slotIndex].Count)
        {
            // TODO: Split stack
            return null;
        }
        else
        {
            ItemInstance item = Slots[slotIndex];
            Slots[slotIndex] = null;
            return item;
        }
    }

    public ItemInstance PeekItem(int slotIndex)
    {
        if (IsValidSlotIndex(slotIndex))
        {
            return Slots[slotIndex];
        }
        return null;
    }

    public bool SwapSlots(int slotIndexOne, int slotIndexTwo)
    {
        return false;
    }

    public bool IsValidSlotIndex(int slotIndex)
    {
        return (slotIndex >= 0 && slotIndex < Slots.Length);
    }

    public int GetFirstSlotIndexForId(ItemData itemID)
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            if (Slots[i] != null)
            {
                if (Slots[i].Data.Equals(itemID))
                {
                    return i;
                }
            }
        }
        return INVALID_SLOT_INDEX;
    }
}
