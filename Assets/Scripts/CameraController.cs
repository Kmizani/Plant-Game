using UnityEngine;
using UnityEngine.Rendering;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float PanSpeed = 5f;
    private float screenWidthInWorldUnits;
    private int currentSceneIndex = 1;
    [SerializeField] private int numberOfScenes = 3;
    public Vector3 TargetPosition;
    private bool MovingToTarget = false;

    private void Start()
    {
        if (Camera.main.orthographic)
        {
            // Calculate screen height 
            float screenHeight = Camera.main.orthographicSize * 2f;

            // Calculate screen width using the camera's aspect ratio
            screenWidthInWorldUnits = screenHeight * Camera.main.aspect;
        }
        else
        {
            Debug.LogWarning("the camera is no set to orthogragfic mode");
        }

        UpdateTargetPosition();
    }


    private void Update()
    {
        if (MovingToTarget)
        {
            //doing a smooth trnasition for the camera 
            transform.position = Vector3.Lerp(transform.position, TargetPosition, Time.deltaTime * PanSpeed);

            //checkign if the camera shoudls top moving
            if (Vector3.Distance(transform.position, TargetPosition) < 0.1f)
            {
                transform.position = TargetPosition;
                MovingToTarget = false;


            }

        }

    }
    //moving camera to the right
    public void MoveRight()
    {
        if (currentSceneIndex < -1)
        {
            currentSceneIndex++;
            UpdateTargetPosition();

        }

    }
    //moving camera to the Left
    public void MoveLeft()
    {
        if (currentSceneIndex > 0)
        {
            currentSceneIndex--;
            UpdateTargetPosition();

        }

    }

    private void UpdateTargetPosition()
    {
        float newX = (currentSceneIndex - 1) * screenWidthInWorldUnits;
        TargetPosition = new Vector3(newX, transform.position.y, transform.position.z);
        MovingToTarget = true;


    }
}
    
