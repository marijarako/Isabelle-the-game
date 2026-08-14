using UnityEngine;

public class GlitchAnimate : MonoBehaviour
{
    public float speed = 0.5f;
    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        float x = Time.time * speed;
        float y = Mathf.Sin(Time.time * speed) * 0.2f;

        mat.mainTextureOffset = new Vector2(x, y);
    }
}
