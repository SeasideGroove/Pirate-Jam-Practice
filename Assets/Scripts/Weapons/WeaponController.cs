using UnityEngine;

namespace Weapons
{
    public class WeaponController : MonoBehaviour
    {
        public BoxCollider LeftHitBox;
        public BoxCollider RightHitBox;

        public LayerMask ExcludeLayers;
        public LayerMask IncludeLayers;
        public WeaponAsset Weapon;

        private float attackTimer = -1f;
       
        // Weapon Controller Interface

        public void Attack(Vector2 direction)
        {
            BoxCollider weaponHitBox = direction.x < 0? LeftHitBox : RightHitBox;
            weaponHitBox.enabled = true;
            attackTimer = 0f;
        }

        // Unity Events

        private void Awake()
        {
            LeftHitBox.excludeLayers = ExcludeLayers;
            LeftHitBox.includeLayers = IncludeLayers;
            RightHitBox.excludeLayers = ExcludeLayers;
            RightHitBox.includeLayers = IncludeLayers;

            DisableHitBoxes();
        }

        private void FixedUpdate()
        {
            if (attackTimer >= Weapon.ActiveTime)
            {
                attackTimer = -1f;
                DisableHitBoxes();
            }
            else if (attackTimer >= 0f)
            {
                attackTimer += Time.fixedDeltaTime;
            }
        }

        // Internal Interface

        private void DisableHitBoxes()
        {
            LeftHitBox.enabled = false;
            RightHitBox.enabled = false;
        }
    }
}