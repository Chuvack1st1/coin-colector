
using UnityEngine;

public class PickUpZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PickUpingItem(other);
    }

    private void PickUpingItem(Collider other)
    {
        var triggeredItem = other.gameObject.GetComponent<ItemView>();
        
        if (triggeredItem != null)
        {
            var playerView = gameObject.GetComponent<PlayerView>();

            if (playerView.PlayerModel.Inventory.AddItem(triggeredItem.GetItem()))
            {
                Destroy(other.gameObject);
            }
        }
    }
}
