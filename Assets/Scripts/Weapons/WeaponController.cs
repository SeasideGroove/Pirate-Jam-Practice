using System;
using Character;
using UnityEngine;

namespace Weapons
{
    public class WeaponController : MonoBehaviour
    {
        public Transform LeftAttackPoint;
        public Transform RightAttackPoint;

        public LayerMask HitMask;
        public WeaponAsset Weapon;

        public bool ShouldDrawDebugRect = false;
        public float DebugDrawTime = 0.5f;
        public Color DebugColor = Color.red;

        private void Awake()
        {
            sourceController = GetComponent<SurvivorCharacterController>();
        }

        public void Attack()
        {
            // TODO: move to player controller and parameterize attack direction
            var screenMouse = Input.mousePosition;
            var worldMouse = Camera.main? Camera.main.ScreenToWorldPoint(screenMouse) : transform.position;
            
            var diff = worldMouse - transform.position;
            Transform attackPoint = diff.x < 0? LeftAttackPoint: RightAttackPoint;
            var lowerLeft = new Vector2(attackPoint.position.x, attackPoint.position.y) - Weapon.Size / 2f;
            var upperRight = lowerLeft + Weapon.Size;
            

            if (ShouldDrawDebugRect)
            {
                DrawDebugRect(attackPoint.localToWorldMatrix*lowerLeft,
                              attackPoint.localToWorldMatrix*upperRight);
            }

            var hits = Physics2D.OverlapAreaAll(lowerLeft, upperRight, HitMask);
            foreach (var hit in hits) { Destroy(hit.gameObject); }
        }

        private void OnDrawGizmosSelected()
        {
            if (LeftAttackPoint)
            {
                Gizmos.DrawWireCube(LeftAttackPoint.position, Weapon? Weapon.Size : Vector2.one);
            }
            if (RightAttackPoint)
            {
                Gizmos.DrawWireCube(RightAttackPoint.position, Weapon? Weapon.Size : Vector2.one);
            }
        }

        private void DrawDebugRect(Vector2 lowerLeft, Vector2 upperRight)
        {
            var lowerRight = new Vector2(upperRight.x, lowerLeft.y);
            var upperLeft = new Vector2(lowerLeft.x, upperRight.y);

            Debug.DrawLine(lowerLeft, lowerRight, DebugColor, DebugDrawTime, false);
            Debug.DrawLine(lowerLeft, upperLeft, DebugColor, DebugDrawTime, false);
            Debug.DrawLine(upperLeft, upperRight, DebugColor, DebugDrawTime, false);
            Debug.DrawLine(lowerRight, upperRight, DebugColor, DebugDrawTime, false);
        }

        private SurvivorCharacterController sourceController;
    }
}