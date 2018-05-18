using UnityEngine;
using System;

public class LevelUI : MonoBehaviour
{
    public LevelProgress lvlAsset;
    public LevelProgress currentLvlAsset;
    
    [SerializeField]
    private SpriteRenderer[] icons;

    public Sprite noShardSprite;
    public Sprite shardSprite;
    public Sprite noCoinSprite;
    public Sprite coinSprite;


    private Color noVisible = new Color(0, 0, 0, 0);

    private void Start()
    {
        

        icons = GetComponentsInChildren<SpriteRenderer>();        

        foreach (var icon in icons)
        {
            icon.color = noVisible;
        }

        if (!lvlAsset.IsActive)
            return;

        for (int i = 0; i < icons.Length; i++)
        {
            icons[i].color = currentLvlAsset.lvlColor;

            if (icons[i].transform.gameObject == transform.gameObject)
                continue;

            if (i == 1)
                icons[i].sprite = noShardSprite;
            else
                icons[i].sprite = noCoinSprite;

        }

        if (lvlAsset.Shard)
            icons[1].sprite = shardSprite; 

        if (lvlAsset.Coin1)
            icons[2].sprite = coinSprite;

        if (lvlAsset.Coin2)
            icons[3].sprite = coinSprite;

        if (lvlAsset.Coin3)
            icons[4].sprite = coinSprite;

        if (lvlAsset.Coin4)
            icons[5].sprite = coinSprite;

        if (lvlAsset.Coin5)
            icons[6].sprite = coinSprite;

        lvlAsset.LvlUpdated += UpdateSprites;
    }

    private void UpdateSprites()
    {
        if (lvlAsset.Shard)
            icons[1].sprite = shardSprite;

        if (lvlAsset.Coin1)
            icons[2].sprite = coinSprite;

        if (lvlAsset.Coin2)
            icons[3].sprite = coinSprite;

        if (lvlAsset.Coin3)
            icons[4].sprite = coinSprite;

        if (lvlAsset.Coin4)
            icons[5].sprite = coinSprite;

        if (lvlAsset.Coin5)
            icons[6].sprite = coinSprite;
    }

    private void OnDisable()
    {
        lvlAsset.LvlUpdated -= UpdateSprites;
    }
}
