
using Unity.Cinemachine;
using UnityEngine;

public class ActivateCamara : MonoBehaviour
{
    public CinemachineCamera camVigilancia;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            camVigilancia.Priority = 20;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            camVigilancia.Priority = 0;
        }
    }
}