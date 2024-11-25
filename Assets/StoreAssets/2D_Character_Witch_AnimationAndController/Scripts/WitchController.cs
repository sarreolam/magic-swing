using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kazuto777.WitchAnimationAndController {
    public class WitchController : MonoBehaviour {

        [SerializeField] Animator characterAnimator;
        public float MoveSpeed = 5f;
        [SerializeField] GameObject fireObject;
        [SerializeField] Rigidbody2D myRigidbody2D;
        [SerializeField] Transform muzzlePoint;

        void Update() {
            // Move
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            Vector2 direction = new Vector2(x, y).normalized;

            myRigidbody2D.velocity = direction * MoveSpeed;

            // Shot
            if ((Input.GetKeyDown(KeyCode.Space)) || (Input.GetButtonDown("Fire1"))) {
                characterAnimator.SetTrigger("IsShot");
                Instantiate(fireObject, muzzlePoint.position, muzzlePoint.rotation);
            }
        }

        private void OnCollisionEnter2D(Collision2D other) {
            // Damage
            if (other.gameObject.tag == "Player") return;
            characterAnimator.SetTrigger("IsDamage");
        }
    }
}