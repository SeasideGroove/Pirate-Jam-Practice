using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu]
    public class WeaponAsset : ScriptableObject
    {
        [Tooltip("The time in seconds the weapon will be actively colliding after being used")]
        public float ActiveTime = 1f;

        [Tooltip("The size of the weapon's bounding box")]
        public Vector2 Size;
    }
}