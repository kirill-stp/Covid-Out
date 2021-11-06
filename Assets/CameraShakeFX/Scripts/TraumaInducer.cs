using UnityEngine;

/* Example script to apply trauma to the camera or any game object */
public class TraumaInducer : MonoBehaviour 
{
    [Tooltip("Stress the effect can inflict upon objects)")]
    public float Stress = 1f;

    public void StartPlayShake()
    {
        var targets = FindObjectsOfType<StressReceiver>();
        foreach(var receiver in targets)
        {
            receiver.InduceStress(Stress);
        }
    }

}