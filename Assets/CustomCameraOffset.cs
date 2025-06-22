using Unity.Cinemachine;
using UnityEngine;

public class CustomCameraOffset : MonoBehaviour
{
    public CinemachineCamera CinemachineCamera;
    private CinemachinePositionComposer positionComposer;
    private Vector3 originalOffset;

    private void Start()
    {
        positionComposer = CinemachineCamera.GetComponent<CinemachinePositionComposer>();
        originalOffset = positionComposer.TargetOffset; // Guardar offset original
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter Camera Offset Zone");
        positionComposer.TargetOffset = new Vector3(originalOffset.x, -1.8f, originalOffset.z);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit Camera Offset Zone");
        positionComposer.TargetOffset = originalOffset; // Restaurar offset original
    }
}
