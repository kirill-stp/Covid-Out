using UnityEngine;

public class MaskPickUp : PickUp
{
    [SerializeField] private int maskAmount;

    protected override void PickUpEffect(GameObject player)
    {
        FindObjectOfType<MaskManager>().AddMask(maskAmount);
    }
}
