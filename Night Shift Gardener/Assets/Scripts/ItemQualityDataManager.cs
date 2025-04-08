using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemQualityDataManager : Singleton<ItemQualityDataManager>
{
    [SerializeField] private List<ItemQualityData> itemQualityDatas;
    private Dictionary<ItemQuality, ItemQualityData> _lookup;

    private void Start()
    {
        _lookup = itemQualityDatas.ToDictionary(x => x.itemQuality, x => x);
    }
    
    public Sprite GetSlotFrame(ItemQuality quality)
    {
        return _lookup[quality].slotFrameSprite;
    }
}