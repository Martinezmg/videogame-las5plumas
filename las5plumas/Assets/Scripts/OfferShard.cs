using UnityEngine;
using Project.Testing;

public class OfferShard : MonoBehaviour
{
    public LevelProgress currentLvlAsset;
    public StackeableContainer shardContainer;

    public void PayOffer()
    {
        shardContainer.Withdraw(1);
    }
}
