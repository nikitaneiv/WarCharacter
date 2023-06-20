using UnityEngine;

public class FootStep : MonoBehaviour
{
    [SerializeField] private GameObject leftFootPrint;
    [SerializeField] private GameObject rightFootPrint;

    [SerializeField] private Transform leftFootLocation;
    [SerializeField] private Transform rightFootLocation;

    private float footPrintOffset = 0.5f;
    
    public void LeftFoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(leftFootLocation.position, leftFootLocation.forward, out hit))
        {
            var leftFootStep = Instantiate(leftFootPrint, hit.point + hit.normal * footPrintOffset, Quaternion.LookRotation(hit.normal, leftFootLocation.up));
            Destroy(leftFootStep, 3f);
        }
    }

    public void RightFoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(rightFootLocation.position, rightFootLocation.forward, out hit))
        {
            var rightFootStep =Instantiate(rightFootPrint, hit.point + hit.normal * footPrintOffset, Quaternion.LookRotation(hit.normal, rightFootLocation.up));
            Destroy(rightFootStep, 3f);
        }
    }
}
