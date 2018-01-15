using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class CameraController : MonoBehaviour{

    public float targetAspect = 16 / 9f;
    public float windowAspect, screenWidth, screenHeight;
	// Use this for initialization
    void Start(){
        screenHeight = Screen.height;
        screenWidth = Screen.width;
        windowAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = windowAspect / targetAspect;



        Camera camera = GetComponent<Camera>();

        if (scaleHeight < 1.0f){
            camera.orthographicSize = camera.orthographicSize / scaleHeight;
        }

	}

	// Update is called once per frame
	void Update()
	{
			
	}
}
