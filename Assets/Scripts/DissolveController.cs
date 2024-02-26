using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveController : MonoBehaviour
{
    // Start is called before the first frame update
    public float dissolveDuration;
    public float dissolveStrength;
    public GameObject bodyGO;
    //public GameObject trausersGO;
    //public GameObject hairGO;

    public void StartDissolver()
    {
        StartCoroutine(Dissolver());
    }
    public IEnumerator Dissolver()
    {
        float elapsedTime = 0;

        Renderer[] dissolveMaterialRenderers = bodyGO.GetComponentsInChildren<Renderer>();
        while (elapsedTime < dissolveDuration)
        {
            elapsedTime += Time.deltaTime;
            dissolveStrength = Mathf.Lerp(0, 1, elapsedTime / dissolveDuration);
            foreach (Renderer renderer in dissolveMaterialRenderers)
            {

                renderer.material.SetFloat("_Dissolve", dissolveStrength);
            }
            yield return null;
        }
        Destroy(gameObject);
        
    }
}
