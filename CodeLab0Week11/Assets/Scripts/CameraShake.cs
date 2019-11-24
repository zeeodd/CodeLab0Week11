using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    // Speed var of the shaking
    public float freq = 25;

    // Speed at which the shaking falls off
    public float recoverySpeed = 0.5f;

    // Max translation shaking in pos
    public Vector3 maxTranslationShake = Vector3.one * 0.5f;

    // Max angular shaking in rot
    public Vector3 maxAngularShake = Vector3.one * 15;

    // Random seeds in order to give different objs random values
    private float seed;

    // Amount of stress the transform is taking
    private float stress = 1;

    private void Awake()
    {
        // Grab a random seed on waking up
        seed = Random.value;
    }

    void Update()
    {
        // Give the shake val an exponent so there's a smoother falloff
        float shake = Mathf.Pow(stress, 2);

        // PERLIN NOISE - - - (better for smoother randomness)
        // Returns a value in the 0...1 range, but below it is transformed to
        // be in the -1...1 range to ensure the shake travels in all directions.

        // Shake the pos of the camera
        transform.localPosition = new Vector3(
            maxTranslationShake.x * (Mathf.PerlinNoise(seed, Time.time * freq) * 2 - 1),
            maxTranslationShake.y * (Mathf.PerlinNoise(seed + 1, Time.time * freq) * 2 - 1),
            maxTranslationShake.z * (Mathf.PerlinNoise(seed + 2, Time.time * freq) * 2 - 1)
        ) * shake;

        // Shake the rot of the camera
        transform.localRotation = Quaternion.Euler(new Vector3(
            maxAngularShake.x * (Mathf.PerlinNoise(seed + 3, Time.time * freq) * 2 - 1),
            maxAngularShake.y * (Mathf.PerlinNoise(seed + 4, Time.time * freq) * 2 - 1),
            maxAngularShake.z * (Mathf.PerlinNoise(seed + 5, Time.time * freq) * 2 - 1)
        ) * shake);

        // Causes the shaking to decrement over time
        stress = Mathf.Clamp01(stress - recoverySpeed * Time.deltaTime);
    }
}
