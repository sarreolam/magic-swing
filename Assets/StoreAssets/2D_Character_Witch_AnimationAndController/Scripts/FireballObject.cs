using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kazuto777.WitchAnimationAndController
{
    public class FireballObject : MonoBehaviour
    {
        [SerializeField] Rigidbody2D myRigidbody2D;
        [SerializeField] GameObject Body;
        [SerializeField] GameObject Hit;
        [SerializeField] ParticleSystem Trajectory;

        void Start()
        {
            myRigidbody2D.AddForce(transform.right * 350);
            var destroyTime = 6f;
            Destroy(this.gameObject, destroyTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player") return;
            else if (other.tag == "enemy")
            {
                Body.SetActive(false);
                Hit.SetActive(true);
                Trajectory.Stop();
            }
        }
    }
}