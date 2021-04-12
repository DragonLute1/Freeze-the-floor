using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMelt : MonoBehaviour
{
    public float meltTime = 1;

    private void Update()
    {
        StartCoroutine(Melt());
    }

    IEnumerator Melt()
    {
        //waits meltTime seconds and then destroys the ice
        yield return new WaitForSeconds(meltTime);
        Destroy(this.gameObject);
    }
}
