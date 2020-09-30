// Obsolete code: Originally childs XR Rig to one platform, but now this is done with every platform the player teleports to.

/*
using UnityEngine;

public class ChildXR : MonoBehaviour
{
    public Transform XRObj;

    private Vector3 scale;

    void Awake()
    {
        XRObj = GameObject.FindWithTag("XRObj").transform;
        scale = XRObj.transform.localScale;
    }

    public void MakeXrChild()
    {
        Debug.Log("Become Parent");
        XRObj.transform.parent = transform;
        XRObj.transform.localScale = new Vector3 (1/transform.localScale.x,1/transform.localScale.y,1/transform.localScale.z);
    }

    public void UnChildXr()
    {
        XRObj.transform.parent = null;
        XRObj.transform.localScale = scale;
    }
}
*/