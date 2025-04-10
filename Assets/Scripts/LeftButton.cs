using UnityEngine;
using UnityEngine.UI;

public class CameraLeftButton : MonoBehaviour
{
    public CameraController cameraController;

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => cameraController.MoveLeft());
    }
}