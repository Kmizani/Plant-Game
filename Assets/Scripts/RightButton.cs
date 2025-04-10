using UnityEngine;
using UnityEngine.UI;

public class CameraRightButton : MonoBehaviour
{
    public CameraController cameraController;

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => cameraController.MoveRight());
    }
}