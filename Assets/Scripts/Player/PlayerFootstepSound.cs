using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootstepSound : MonoBehaviour
{
    private AudioSource audioPlayer;
    [SerializeField]
    private CharacterController charController;
    [SerializeField]
    private Animator playerAnim;

    private float minVol = 0.1f;
    private float maxVol = 0.6f;
    private float stepDistance = 0.5f;
    private float accumulateDistance;

    public void Awake()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    public void Update()
    {
        SettingVolumes();
        CheckingIfPlay();
    }

    public void SettingVolumes()
    {
        if (playerAnim.GetBool("isRunning"))
        {
            minVol = 0.4f;
            maxVol = 0.8f;
            stepDistance = 0.3f;
        }
        else
        {
            minVol = 0.3f;
            maxVol = 0.6f;
            stepDistance = 0.5f;
        }
    }

    public void CheckingIfPlay()
    {
        if (!charController.isGrounded)
        {
            return;
        }

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
