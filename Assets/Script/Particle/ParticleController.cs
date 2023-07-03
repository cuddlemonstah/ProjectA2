using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] ParticleSystem movementParticle;
    int occurAfterVelocity = 1;
    float dirtFormationPeriod = 0.2f;
    [SerializeField] Rigidbody2D playerRb;

    float counter;
    void Update()
    {
        counter += Time.deltaTime;

        if (Mathf.Abs(playerRb.velocity.x) > occurAfterVelocity || Mathf.Abs(playerRb.velocity.y) > occurAfterVelocity)
        {
            if (counter > dirtFormationPeriod)
            {
                movementParticle.Play();
                counter = 0;
            }
        }
    }
}
