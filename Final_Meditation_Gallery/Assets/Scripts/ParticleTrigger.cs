using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTrigger : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem fire;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fire.Emit(1);
        }
    }

}
