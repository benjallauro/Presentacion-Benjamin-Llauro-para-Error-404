using UnityEngine;

namespace Tools
{
    public class RandomAreaPositioner : MonoBehaviour
    {
        [SerializeField] private float XRange;
        [SerializeField] private float ZRange;
        [SerializeField] private float height;

        public Vector3 RandomizePosition(Vector3 position)
        {
            return new Vector3(position.x + Random.Range(-XRange, XRange), height, position.z + Random.Range(-ZRange, ZRange));
        }
    }
}
