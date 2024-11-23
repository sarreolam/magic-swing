using System.Collections;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCam;
    private CinemachineBasicMultiChannelPerlin perlinNoise;

    private void Awake()
    {
        virtualCam = GetComponent<CinemachineVirtualCamera>();
        perlinNoise = virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        ResetIntensity();
    }

    private void Start()
    {
        StartCoroutine(Shake(3, 3));
    }

    public void ShakeCamera(float intensity, float shakeDuration)
    {
        StartCoroutine(Shake(intensity, shakeDuration));
    }

    private IEnumerator Shake(float intensity, float duration)
    {
        perlinNoise.m_AmplitudeGain = intensity;

        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Reset the intensity after shaking
        ResetIntensity();
    }

    private void ResetIntensity()
    {
        perlinNoise.m_AmplitudeGain = 0f;
    }
}
