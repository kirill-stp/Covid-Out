using UnityEngine;

public class VaccinePickUp : PickUp
{
    [SerializeField] private float immuneSeconds;

    protected override void PickUpEffect(GameObject player)
    {
        player.GetComponent<PlayerCollision>().MakeImmune(immuneSeconds);
    }

}
