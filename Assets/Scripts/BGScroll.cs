using UnityEngine;


public class BGScroll : MonoBehaviour
{
    public float scrollspeed=0.2f;
    private float X_scroll;
    public MeshRenderer meshrenderer;

    void Awake()
    {
        meshrenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        Scroll();   
    }

    public void Scroll()
    {
        X_scroll = Time.time * scrollspeed;
        Vector2 offset = new Vector2(X_scroll, 0f);
        meshrenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

}//class
