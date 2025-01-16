using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu]
    public class WeaponAsset : ScriptableObject
    {
        [Tooltip("The time in seconds the weapon will be actively colliding after being used")]
        public float ActiveTime = 1f;
        
        [Tooltip("The time in seconds after using the weapon before it can be used again")]
        public float CooldownTime = 1f;

        [Tooltip("The size of the weapon's bounding box")]
        public Vector3 Size = Vector3.one;
    }
}