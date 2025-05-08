using UnityEngine;
using Zenject;

public class PaintController : MonoBehaviour
{
#region param
    public Camera mainCamera;
    public Texture2D texture;
    public Color paintColor = Color.red;
    public float brushSize = 5f;
    [Inject] private InputPlayer input;
#endregion

    private void Start(){

    }

    private void Update()
    {
        if (Input.GetMouseButton(0)) // ЛКМ
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
                Paint(hit);
        }
    }

    private void Paint(RaycastHit hit)
    {
        Renderer renderer = hit.collider.GetComponent<Renderer>();
        if (renderer != null && renderer.material.mainTexture == texture)
        {
            Vector2 uv;
            if (GetUV(hit, out uv))
            {
                int x = (int)(uv.x * texture.width);
                int y = (int)(uv.y * texture.height);
                DrawOnTexture(x, y);
                texture.Apply();
            }
        }
    }

    private bool GetUV(RaycastHit hit, out Vector2 uv)
    {
        MeshCollider meshCollider = hit.collider as MeshCollider;
        if (meshCollider != null)
        {
            Vector3 localPoint = hit.transform.InverseTransformPoint(hit.point);
            Vector3[] vertices = meshCollider.sharedMesh.vertices;
            Vector2[] uvs = meshCollider.sharedMesh.uv;

            // Простой расчет UV (может потребовать доработки для более сложных моделей)
            float minX = float.MaxValue;
            float maxX = float.MinValue;
            float minY = float.MaxValue;
            float maxY = float.MinValue;

            foreach (Vector3 vertex in vertices)
            {
                if (vertex.x < minX) minX = vertex.x;
                if (vertex.x > maxX) maxX = vertex.x;
                if (vertex.y < minY) minY = vertex.y;
                if (vertex.y > maxY) maxY = vertex.y;
            }

            uv = new Vector2((localPoint.x - minX) / (maxX - minX), (localPoint.y - minY) / (maxY - minY));
            return true;
        }

        uv = Vector2.zero;
        return false;
    }

    private void DrawOnTexture(int x, int y)
    {
        int halfBrushSize = (int)(brushSize / 2);
        for (int i = x - halfBrushSize; i < x + halfBrushSize; i++)
        {
            for (int j = y - halfBrushSize; j < y + halfBrushSize; j++)
                if (i >= 0 && i < texture.width && j >= 0 && j < texture.height)
                    texture.SetPixel(i, j, paintColor);
        }
    }
}
