using UnityEngine;

namespace Scripts.Nodes
{
    public class WalkableBridge : MonoBehaviour
    {
        public float bridgeWidth = 0.5f;

        private LineRenderer lineRenderer;
        private MeshFilter meshFilter;
        private MeshCollider meshCollider;

        void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
            meshFilter = GetComponent<MeshFilter>();
            meshCollider = GetComponent<MeshCollider>();
        }

        void Start()
        {
            GenerateBridgeMesh();
        }

        void GenerateBridgeMesh()
        {
            Vector3[] points = new Vector3[lineRenderer.positionCount];
            lineRenderer.GetPositions(points);

            int segmentCount = points.Length - 1;
            Vector3[] vertices = new Vector3[segmentCount * 4];
            int[] triangles = new int[segmentCount * 6];

            for (int i = 0; i < segmentCount; i++)
            {
                Vector3 forward = (points[i + 1] - points[i]).normalized;
                Vector3 right = Vector3.Cross(Vector3.up, forward) * (bridgeWidth / 2);

                // 네 모서리 점
                vertices[i * 4 + 0] = points[i] - right;
                vertices[i * 4 + 1] = points[i] + right;
                vertices[i * 4 + 2] = points[i + 1] - right;
                vertices[i * 4 + 3] = points[i + 1] + right;

                // 삼각형 인덱스
                triangles[i * 6 + 0] = i * 4 + 0;
                triangles[i * 6 + 1] = i * 4 + 2;
                triangles[i * 6 + 2] = i * 4 + 1;

                triangles[i * 6 + 3] = i * 4 + 1;
                triangles[i * 6 + 4] = i * 4 + 2;
                triangles[i * 6 + 5] = i * 4 + 3;
            }

            Mesh mesh = new Mesh();
            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.RecalculateNormals();

            meshFilter.mesh = mesh;
            meshCollider.sharedMesh = mesh;
        }
    }
}