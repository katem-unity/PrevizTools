using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class LiveController : MonoBehaviour
{
	public GameObject playerView;
	public GameObject currentShot;
	public GameObject birdsEyeView;
	public GameObject playerAvatar;
	public GameObject cameraAvatar;

	public InputAction changeCameraAction;
	//public InputAction moveAction;
	public InputAction horizontalAction;
	public InputAction verticalAction;
	public InputAction lookAroundAction;
	public InputActionMap cinematographerMode;

	public float moveSpeed = 10.0f;
    public Vector2 position;

    Vector3 rot = new Vector3(0, 0, 0);
    float sensitivity = 10.0f;

	int cameraCount = 3;
	int activeCamera = 1;

	float birdpath = 0;
	float birddist = 1;

	public CinemachineVirtualCamera virtualCamera;
	public CinemachineTrackedDolly trackedDolly;

    // Start is called before the first frame update
	void Start(){
		cameraCount = 2;
		activeCamera = 1;
		horizontalAction.Enable();
		verticalAction.Enable();
		lookAroundAction.Enable();
		ChangeCamera();
		//lookAroundAction.Enable();
	}


    void Awake(){
    	changeCameraAction.performed += ChangeCamera;
    	changeCameraAction.performed += ChangeCamera;
    	//cinematographerMode["changeCamera"].performed += ChangeCamera;
    }

	// Buttons
    void OnEnable(){
    	changeCameraAction.Enable();
    	cinematographerMode.Enable();
    }

    void OnDisable(){
    	changeCameraAction.Disable();
    	cinematographerMode.Disable();
    }

    void Update()
    {
    	//This works for x and y
        //var moveDirection = moveAction.ReadValue<Vector2>();
        //position += moveDirection * moveSpeed * Time.deltaTime;

  		float x = (horizontalAction.ReadValue<float>()) * Time.deltaTime * moveSpeed;
  		float z = (verticalAction.ReadValue<float>()) * Time.deltaTime * moveSpeed;

        //Debug.Log("Horizontal: " + horizontalAction.ReadValue<float>().ToString("#.#####"));

        //Debug.Log("Vertical: " + verticalAction.ReadValue<float>().ToString("#.#####"));

        if(activeCamera == 0){
       	//PlayerView camera behavior
  		//Guy can't fly, always on ground collision
  		//Crouch option
			playerView.transform.rotation = Quaternion.Euler(rot);
        	playerView.transform.Translate (x , 0, z);
    	} else if(activeCamera == 1){
    		//ShotView camera behavior
  			//Sensitivity x5
    		currentShot.transform.Translate (x*.2f , 0, z*.2f);
    		currentShot.transform.rotation = Quaternion.Euler(rot);
    	} else if(activeCamera == 2){
    		//BirdsEyeView camera behavior
  			//A+D to rotate camera (Path position)
  			//W+S to zoom in and out (Path offset Y)

  			var dolly = virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
  			birdpath = birdpath + (x*.5f);
			dolly.m_PathPosition = birdpath;

			//Path offset x 1 to 40
			birddist = birddist + (z*2.0f);
			dolly.m_PathOffset = new Vector3(Mathf.Clamp(birddist, 1, 40), 0f, 0f);
			if(birddist < 1){
				birddist = 1;
			}
			if(birddist > 40){
				birddist = 40;
			}

			//Path offset x 1 to 40
			//Near clip plane 24 to 52
    		//trackedDolly.m_PathPosition = 0;
    		//trackedDolly.m_PathOffset = birdpath + y;

    		//birdsEyeView.transform.Translate (x , 0, z);
    		//birdsEyeView.transform.rotation = Quaternion.Euler(rot);
    	}


		Vector2 lookValue = lookAroundAction.ReadValue<Vector2>();
    	rot.x += -lookValue.y * 0.022f * sensitivity;
        rot.y += lookValue.x * 0.022f * sensitivity;

    }


    void ChangeCamera(InputAction.CallbackContext context){

    	//virtualCamera = context.GetComponent<CinemachineVirtualCamera>();
    	//trackedDolly = virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
    	ChangeCamera();
    }

    void ChangeCamera(){
    	switch (cameraCount)
    	{
    		case 1:
    			//Player view
    		  	//Camera avatar visible
    			activeCamera = 0;
    			playerView.SetActive(true);
    			currentShot.SetActive(false);
    			birdsEyeView.SetActive(false);
    			cameraAvatar.SetActive(true);
				playerAvatar.SetActive(false);
    			//virtualCamera = playerView.GetComponent<CinemachineVirtualCamera>();
    			cameraCount = 2;
				Debug.Log("Switching Camera to Player View");
    			break;
    		case 2:
    			//Shot camera
    		  	//No avatars visible
    			activeCamera = 1;
    			playerView.SetActive(false);
    			currentShot.SetActive(true);
    			birdsEyeView.SetActive(false);
    			cameraAvatar.SetActive(false);
				playerAvatar.SetActive(false);
    			//virtualCamera = currentShot.GetComponent<CinemachineVirtualCamera>();
    			cameraCount = 3;
				Debug.Log("Switching Camera to Current Shot");
    			break;
    		case 3:
    			//Bird's Eye
    			//Both avatars visible
    			activeCamera = 2;
    			playerView.SetActive(false);
    			currentShot.SetActive(false);
    			birdsEyeView.SetActive(true);
    			cameraAvatar.SetActive(true);
    			playerAvatar.SetActive(true);
    			//virtualCamera = birdsEyeView.GetComponent<CinemachineVirtualCamera>();
    			//trackedDolly = birdsEyeView.GetComponent<CinemachineTrackedDolly>();
    			cameraCount = 1;
				Debug.Log("Switching Camera to Bird's Eye");
    			break;
    		default:
    			Debug.Log("Camera change error");
    			break;
    	}
    }


    void LookAround(InputAction.CallbackContext context){
    	
    }
}
