using System.Collections;
using UnityEngine;
using Zenject;

public class PaintController : MonoBehaviour
{
#region param
    private Camera mainCamera;
    [Range(2, 512)]
    [SerializeField] private int _brushSize = 8;

    private int _oldRayX = 0, _oldRayY = 0;

    private Color _color = Color.red;

    [Inject] private InputPlayer input;
#endregion

    public void IsPaint(Color color){
        _color = color;
    }

    private void Start(){
        mainCamera = Camera.main;

        #region input
        input.Player.Attack.started += i => StartCoroutine(OnPaintPerformed());
        input.Player.Attack.canceled += i => StopAllCoroutines();
        #endregion
    }
    private IEnumerator OnPaintPerformed(){
        while(true){
            Paints();
            yield return new WaitForFixedUpdate();
        }
    }

    private void Paints()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            if (hit.transform.gameObject.TryGetComponent(out Renderer renderer))
            {
                Texture2D texture2D = renderer.material.mainTexture as Texture2D;

                // Вычисление координат пикселей
                int rayX = (int)(hit.textureCoord.x * texture2D.width);
                int rayY = (int)(hit.textureCoord.y * texture2D.height);

                if (_oldRayX != rayX || _oldRayY != rayY)
                {
                    DrawCircle(rayX, rayY, texture2D);
                    _oldRayX = rayX;
                    _oldRayY = rayY;
                }
            }
        }    
    }

    private void DrawCircle(int rayX, int rayY, Texture2D texture2D) {
        for (int y = 0; y < _brushSize; y++) {
            for (int x = 0; x < _brushSize; x++) {
                float x2 = Mathf.Pow(x - _brushSize / 2, 2);
                float y2 = Mathf.Pow(y - _brushSize / 2, 2);
                float r2 = Mathf.Pow(_brushSize / 2 - 0.5f, 2);

                if (x2 + y2 < r2) {
                    int pixelX = rayX + x - _brushSize / 2;
                    int pixelY = rayY + y - _brushSize / 2;

                    if (pixelX >= 0 && pixelX < texture2D.height && pixelY >= 0 && pixelY < texture2D.width) {
                        Color oldColor = texture2D.GetPixel(pixelX, pixelY);
                        Color resultColor = Color.Lerp(oldColor, _color, _color.a);
                        texture2D.SetPixel(pixelX, pixelY, resultColor);
                    }
                }
            }
        }
        texture2D.Apply();
    }
}
