using UnityEngine;
using System.Collections;

public class ScrollBehaviour : MonoBehaviour
{
    public int materialIndex = 0;
    public Vector3 uvAnimationRate = new Vector3(1.0f, 0.0f, 0.0f);
    public string textureName = "_MainTex";

    Vector3 uvOffset = Vector3.zero;

    void LateUpdate()
    {
        uvOffset += (uvAnimationRate * Time.deltaTime * 100);
        if (GetComponent<Renderer>().enabled)
        {
            GetComponent<Renderer>().materials[materialIndex].SetTextureOffset(textureName, uvOffset);
        }
    }
}
