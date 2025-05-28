using UnityEngine;

namespace Scripts.Nodes
{
    public class NodePathBridge : MonoBehaviour
    {
        public Transform startPoint;
        public Transform endPoint;
        public int curveResolution = 20;
        public float arcHeight = 2.0f;

        private LineRenderer lineRenderer;

        private void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.positionCount = curveResolution;
            lineRenderer.useWorldSpace = true;
        }

        private void Start()
        {
            DrawCurve();
        }

        public void DrawCurve()
        {
            for (int i = 0; i < curveResolution; i++)
            {
                float t = i / (float)(curveResolution - 1);
                Vector3 point = GetArcPoint(t);
                lineRenderer.SetPosition(i, point);
            }
        }

        private Vector3 GetArcPoint(float t)
        {
            // 중간점을 위로 들어서 곡선 생성
            Vector3 mid = (startPoint.position + endPoint.position) / 2 + Vector3.up * arcHeight;
            Vector3 p0 = Vector3.Lerp(startPoint.position, mid, t);
            Vector3 p1 = Vector3.Lerp(mid, endPoint.position, t);
            return Vector3.Lerp(p0, p1, t); // 2차 베지어 곡선
        }
        
    }
}