using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosestMirrors : MonoBehaviour
{
    public bool ReflectedSound;
    public AudioReverbFilter WallEcho;
    public int SoundRadius;
    private bool rever;


    public GameObject FindClosestWall()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Wall");
        GameObject closest = null;
        float distance = 200;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        if (closest != null)
        {
            return closest;
        }
        else
        {
            return null;
        }
        
    }

    public void ReverbCheck(GameObject reflected)
    {
        if (reflected != null)
        {
            Ray refR = new Ray(reflected.transform.position, (transform.position - reflected.transform.position));
            Debug.DrawRay(reflected.transform.position, (transform.position - reflected.transform.position), Color.red);
            Ray oppR = new Ray(transform.position, (transform.position - reflected.transform.position));
            Debug.DrawRay(transform.position, (transform.position - reflected.transform.position), Color.yellow);
            RaycastHit dist;
            RaycastHit dist2;

            if (Physics.Raycast(refR, out dist) && Physics.Raycast(oppR, out dist2))
            {
                if (reflected && dist2.transform.tag == "Wall" && (dist.distance <= SoundRadius) && (dist2.distance <= SoundRadius))
                {
                    WallEcho.enabled = true;
                }
                else
                {
                    WallEcho.enabled = false;
                }
            }
            else
            {
                WallEcho.enabled = false;
            }

        }
        else
        {
            WallEcho.enabled = false;
        }
    }
    void Start()
    {
    }


    void Update()
    {
        if (ReflectedSound)
        {
            ReverbCheck(FindClosestWall());
        }
        else
        {
            WallEcho.enabled = false;
        }
    }
}
