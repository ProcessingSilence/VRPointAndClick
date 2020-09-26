using UnityEngine;

public class ReticleScaleMaintainer : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.localScale != Testing.GlobalReticleScale.globalScale)
        {
            transform.localScale = Testing.GlobalReticleScale.globalScale;
        }
    }
}
