using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSound : MonoBehaviour
{

    public GameObject HitObject;
    public string MaterialsOcclusion;

    public object[] SMaterial()
    {
        if (MaterialsOcclusion == "concrete") {

             return new[] { "200", "1" };
                
        }
        else if (MaterialsOcclusion == "wood") {
            return new[] { "700", "0" };
        }
        else if (MaterialsOcclusion == "metal")
        {
            return new[] { "600", "1.5" };
        }
        else
        {
            return new[] { "22000", "1" };
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
