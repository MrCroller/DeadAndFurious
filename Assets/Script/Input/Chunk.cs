using DF.Associations;
using UnityEngine;

namespace DF.Input
{
    public sealed class Chunk : TriggerInput
    {
        [field: SerializeField] public Transform Begin { get; private set; }
        [field: SerializeField] public Transform End { get; private set; }

        public new void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerAssociations.TRIGGER_END_ROAD)
            {
                TrigerEnter.Invoke(collision);
            }
        }
    }
}
