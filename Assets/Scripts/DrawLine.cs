using UnityEngine;
using UnityEngine.UI;

public class DrawLine : MonoBehaviour
{ 
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Image startImage;
    [SerializeField] private Image endImage;

    private bool isDrawing = false;
    private Vector3 start;
    private Vector3 end;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(startImage.rectTransform, Input.mousePosition))
            {
                start = startImage.transform.position;
                isDrawing = true;
            }
        }

        if (isDrawing)
        {
            lineRenderer.SetPosition(0, start);
            lineRenderer.SetPosition(1, Input.mousePosition);

            if (Input.GetMouseButtonUp(0) && RectTransformUtility.RectangleContainsScreenPoint(endImage.rectTransform, Input.mousePosition))
            {
                end = endImage.transform.position;
                isDrawing = false;
                lineRenderer.SetPosition(1, end);
            }
        }
    }
}
