using UnityEngine;

public class ValidateModule : MonoBehaviour {

    private bool isOkay;
    public GameObject HaloNo;
    public GameObject HaloYes;

    private void Start()
    {
        isOkay = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOkay = true;
        HaloNo.SetActive(false);
        HaloYes.SetActive(true);
    }

    private void OnCollisionExit(Collision collision)
    {
        isOkay = false;
        HaloNo.SetActive(true);
        HaloYes.SetActive(false);
    }
}
