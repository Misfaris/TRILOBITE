using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"TRIGGER: {other.name} | trigger={other.isTrigger} | layer={LayerMask.LayerToName(other.gameObject.layer)}");

        if (other.CompareTag("Floor")) return;

        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance is NULL");
            return;
        }

        GameManager.Instance.FailRun();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"COLLISION: {collision.collider.name} | layer={LayerMask.LayerToName(collision.collider.gameObject.layer)}");
    }
}