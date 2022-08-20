using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesTest : MonoBehaviour
{
    public ParticleSystem particleBurst;
    private bool Emitted = false;
    private float cooldownTime = 0f;

    // Update is called once per frame
    void Start() {
        particleBurst = GameObject.Find("ParticleTest").GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetKey("r") && Emitted == false) {
            particleBurst.Emit(15);
            Emitted = true;
        }

        cooldownTime += Time.deltaTime;
        if (Emitted == true && cooldownTime > 0.1f) {
            Emitted = false;
            cooldownTime = 0f;
        }
    }
}
