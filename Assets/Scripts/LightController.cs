using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
   [SerializeField] List<GameObject> lights;


    public void SetLights()
    {
        lights.ForEach(light => { light.SetActive(!light.activeSelf); });
    }
}
