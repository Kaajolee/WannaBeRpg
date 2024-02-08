using UnityEngine;
using UnityEngine.UI;

public class CastBar : MonoBehaviour
{
    public static GameObject castBarPrefab;
    
    public static GameObject CreateCastBar(Transform parentTransform)
    {
        GameObject castBarObject = Instantiate(Resources.Load<GameObject>("CastBarPrefab"));
        castBarObject.transform.SetParent(parentTransform, false);
        return castBarObject;
    }
}
