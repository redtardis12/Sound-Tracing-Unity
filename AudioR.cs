using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioR : MonoBehaviour
{
    public AudioSource MainSound;
    public float Volume;
    public AudioLowPassFilter WallFX;
    public Camera Listener;
    public int SoundDistance;
    public MaterialSound oclussed;
    


    void Start()
    {
    }

    void Update()
    {
        Ray mainR = new Ray(transform.position, (Listener.transform.position - transform.position));
        Debug.DrawRay(transform.position, (Listener.transform.position - transform.position), Color.green);
        RaycastHit occlusion;
        if (Vector3.Distance(Listener.transform.position, transform.position) <= SoundDistance)
        {
            MainSound.volume = Volume;
            if (Physics.Raycast(mainR, out occlusion))
            {
                oclussed = occlusion.collider.gameObject.GetComponent<MaterialSound>();
                if (oclussed)
                {
                    WallFX.cutoffFrequency = System.Convert.ToInt32(oclussed.SMaterial()[0]);
                    WallFX.lowpassResonanceQ = System.Convert.ToInt32(oclussed.SMaterial()[1]);
                }
                else
                {
                    WallFX.cutoffFrequency = (22000);
                }
            }
            else
            {
                WallFX.cutoffFrequency = (22000);
            }
        }
        else
        {
            MainSound.volume = 0;
        }
    }
}