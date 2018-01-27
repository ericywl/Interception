using UnityEngine;

namespace Assets.Scripts {
    public class BoardManager : MonoBehaviour {
        private const float TILE_SIZE = 1.0f;
        private const float TILE_OFFSET = 0.5f;
        public int NUM_ROWS = 8;
        public int NUM_COLS = 8;
        public GameObject invisibleBox;
        public Quaternion orientation = Quaternion.Euler(0, 180f, 0);

        void Start() {
            SpawnColliders();
        }

        void Update() {
            DrawTiles();
            UpdateSelection();
        }

        void DrawTiles() {
            Vector3 widthLine = Vector3.right * NUM_ROWS;
            Vector3 heightLine = Vector3.forward * NUM_COLS;
            for (int i = 0; i <= NUM_ROWS; i++) {
                Vector3 start = Vector3.forward * i;
                Debug.DrawLine(start, start + widthLine);
                for (int j = 0; j <= NUM_COLS; j++) {
                    start = Vector3.right * j;
                    Debug.DrawLine(start, start + heightLine);
                }
            }
        }

        private void UpdateSelection() {
            if (!Camera.main)
                return;

            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),
                out hit, 25.0f,
                LayerMask.GetMask("BoardPlane"))) {
                Debug.Log(hit.point);
            }
        }

        void SpawnColliders() {
            for (int i = 0; i < NUM_ROWS; i++) {
                for (int j = 0; j < NUM_COLS; j++) {
                    GameObject colliderObject = Instantiate(invisibleBox,
                        new Vector3(i + 0.5f, 0.5f, j + 0.5f), orientation);
                    colliderObject.transform.SetParent(transform);
                }
            }
        }
    }
}