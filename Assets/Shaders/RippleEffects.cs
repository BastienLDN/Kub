// This effect is made by Devon O. Wolfgang of the onebyonedesign blog. 
using UnityEngine;

public class RippleEffects : MonoBehaviour
{
    #region Public members

    public Material RippleMaterial;
    public float MaxAmount = 50f;

    [Range(0, 1)]
    public float Friction = .9f;

    #endregion


    #region System members

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            this.Amount = this.MaxAmount;
            Vector3 pos = Input.mousePosition;
            this.RippleMaterial.SetFloat("_CenterX", pos.x);
            this.RippleMaterial.SetFloat("_CenterY", pos.y);
        }

        this.RippleMaterial.SetFloat("_Amount", this.Amount);
        this.Amount *= this.Friction;
    }

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        Graphics.Blit(src, dst, this.RippleMaterial);
    }

    #endregion


    #region Private and protected members

    private float Amount = 0f;

    #endregion 
}
