using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFootstepSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioPlayer;
    private CharacterController charController;

    private float minVol = 0.1f;
    private float maxVol = 0.6f;
    private float stepDistance = 0.5f;
    private float accumulateDistance;

    public void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    public void Update()
    {
        SettingVolumes();
        CheckingIfPlay();
    }

    public void SettingVolumes()
    {
        minVol = 0.3f;
        maxVol = 0.6f;
        stepDistance = 0.5f;
    }

    public void CheckingIfPlay()
    {
        if (charController.velocity.sqrMagnitude > 0)
        {
            accumulateDistance += Time.deltaTime;

            if (accumulateDistance > stepDistance)
            {
                audioPlayer.volume = Random.Range(minVol, maxVol);
                audioPlayer.Play();
                accumulateDistance = 0f;
            }
        }
        else
        {
            accumulateDistance = 0f;
        }
    }
}
