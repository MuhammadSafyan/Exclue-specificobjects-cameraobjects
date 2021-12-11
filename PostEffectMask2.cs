//Create a laye NO Effect
//attach this scpript with camera
//add the player to array in the script you want to exclude

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class PostEffectMask2 : MonoBehaviour {

    public GameObject[] ObjectsToExclude;
    private Camera m_camera;
    private GameObject Sample;
   
    private void Awake() {
        m_camera = GetComponent<Camera>();
        gameObject.GetComponent<Camera>().cullingMask = ~(1 << LayerMask.NameToLayer("No Effect"));

    }


  

    
    private void Start()
    {
        SetCamera();
        
    }

    

   
     void SetCamera()
     {
        Sample = new GameObject("Sample");
        Sample.transform.SetParent(gameObject.transform);
        Sample.AddComponent<Camera>();
        Sample.GetComponent<Camera>().fieldOfView = gameObject.GetComponent<Camera>().fieldOfView;
        Sample.GetComponent<Camera>().clearFlags = CameraClearFlags.Nothing;
        Sample.gameObject.layer = LayerMask.NameToLayer("No Effect");
        Sample.GetComponent<Camera>().cullingMask = 1 << LayerMask.NameToLayer("No Effect");
        for (int i = 0; i < ObjectsToExclude.Length; i++)
        {
            ObjectsToExclude[i].gameObject.layer= LayerMask.NameToLayer("No Effect");
        }
     }
    


    
}
