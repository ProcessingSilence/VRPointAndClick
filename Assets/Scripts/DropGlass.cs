// Makes glass fall upon being called.

// If the player drops orange into void but makes it to goal platform on level 2, the glass will drop and allow the
// player to grab the orange from the start again.

using System.Collections;
using UnityEngine;

public class DropGlass : MonoBehaviour
{
    private bool alreadyDone;

    public void GlassFall()
    {
        if (alreadyDone == false)
        {
            alreadyDone = true;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.AddComponent<Rigidbody>();
            StartCoroutine(WaitBeforeDelete());
        }
    }

    IEnumerator WaitBeforeDelete()
    {
        yield return new WaitForSecondsRealtime(10f);
        Destroy(gameObject);
    }
}
