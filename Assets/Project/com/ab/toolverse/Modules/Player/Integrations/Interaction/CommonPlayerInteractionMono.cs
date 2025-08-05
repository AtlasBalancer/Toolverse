using Project.com.ab.toolverse.sharedkernel;
using UnityEngine;

namespace Project.com.ab.toolverse.Common.CommonPlayer.Interaction
{
    public class CommonPlayerInteractionMono : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IHarvest harvest))
            {
                Debug.Log($"{nameof(CommonPlayerInteractionMono)}::Enter:{other.name}");
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out IHarvest harvest))
            {
                Debug.Log($"{nameof(CommonPlayerInteractionMono)}::Exit:{other.name}");
            }
        }
    }
}