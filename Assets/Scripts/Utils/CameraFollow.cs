using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region Vars
    public Transform player;

    [Header("Configs")]
    public float distanceFromTarget = 5;

    [Range(0.0f, 90.0f)]
    public float elevationAngle = 30;

    [Range(0.0f, 10.0f)] // 1 is fast 10 is slow
    public float smoothFactorPostion = 10.0f;

    [Range(0.0f, 10.0f)] // 1 is fast 10 is slow
    public float smoothFactorRotation = 3.0f;

    #endregion

    private void Update()
    {
        MoveToPlayer();
        FaceToPlayer();
    }

    Vector3 followVelocity; //For SmoothDamp

    private void MoveToPlayer()
    {
        Vector3 desiredPosition;
        desiredPosition.x = player.position.x;
        desiredPosition.y = player.position.y + Mathf.Sin(elevationAngle * (Mathf.PI / 180)) * distanceFromTarget;
        desiredPosition.z = player.position.z - Mathf.Cos(elevationAngle * (Mathf.PI / 180)) * distanceFromTarget;

        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref followVelocity, smoothFactorPostion);
        transform.position = smoothPosition;
    }

    private void FaceToPlayer() 
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion desiredRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, (1/smoothFactorRotation) * Time.deltaTime);
    }
}
