using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create/OfferItem",fileName = "Offer")]
public class SoOffersData : ScriptableObject
{
    public ItemId ItemId;
    public ItemId[] itemsForOffer;
}
