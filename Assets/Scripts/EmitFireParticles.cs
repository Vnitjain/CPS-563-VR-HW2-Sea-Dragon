using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitFireParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSys;
    [SerializeField] private Transform targetObject;
    private ParticleSystem.EmitParams emitParameters;
    private void Start()
    {

    }

    private void Update()
    {
        if (particleSys != null && targetObject != null)
        {
            // Calculate world position based on target object and offset
            Vector3 worldPosition = targetObject.position;

            emitParameters = new ParticleSystem.EmitParams();
            emitParameters.startSize = 0.5f;
            emitParameters.position = targetObject.position;

            // Emit particles directly, using default lifetime
            particleSys.Emit(emitParameters, 1000);
        }
        else
        {
            Debug.LogError("Please assign Particle System and Target Object in the Inspector!");
        }

    }
}
