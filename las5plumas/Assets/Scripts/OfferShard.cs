using UnityEngine;
using Project.Testing;

public class OfferShard : MonoBehaviour
{
    public GameObject thisContainer;
    public GameObject nextContainer;
    public LevelProgress currentLvlAsset;
    public StackeableContainer shardContainer;

    public void CheckOffer()
    {
        if (currentLvlAsset.Shard)
        {
            thisContainer.SetActive(true);
        }
        else
        {
            nextContainer.SetActive(true);
        }
    }

    public void PayOffer()
    {
        shardContainer.Withdraw(1);
    }
}
