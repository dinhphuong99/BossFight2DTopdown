using UnityEngine;
using UnityEngine.Tilemaps;

public class GetPositionFromGround : MonoBehaviour
{
    public Tilemap groundTilemap; // Kéo và thả Tilemap Renderer của Ground vào đây
    [SerializeField] private GameObject player; // Tham chiếu đến game object người chơi
    [SerializeField] private GameObject [] gameObjects;
    [SerializeField] private float[] minDistances;
    [SerializeField] private bool canSetPosition = false;


    private void Start()
    {
        if (groundTilemap == null)
        {
            Debug.LogError("Vui lòng gán Tilemap Renderer của Ground vào biến groundTilemap.");
            return;
        }

        if (player == null)
        {
            Debug.LogError("Vui lòng gán game object người chơi vào biến player.");
            return;
        }
    }

    private void Update()
    {
        if (canSetPosition)
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].transform.position = GetRandomPositionOnTilemap(minDistances[i]);
                Debug.Log("Vị trí ngẫu nhiên trên Ground cách xa ít nhất 8 đơn vị từ người chơi: " + GetRandomPositionOnTilemap(minDistances[i]));
            }
        }
    }

    // Hàm để lấy vị trí ngẫu nhiên trên Tilemap cách xa ít nhất 8 đơn vị từ người chơi
    private Vector3 GetRandomPositionOnTilemap(float distance)
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 randomPosition;

        // Lặp cho đến khi tìm được vị trí thỏa mãn khoảng cách
        do
        {
            // Lấy các ô (tiles) trong Tilemap
            BoundsInt bounds = groundTilemap.cellBounds;

            // Chọn ngẫu nhiên một ô trong Tilemap
            Vector3Int randomCell = new Vector3Int(
                Random.Range(bounds.x, bounds.x + bounds.size.x),
                Random.Range(bounds.y, bounds.y + bounds.size.y),
                0 // Đối với Tilemap 2D, giá trị Z = 0
            );

            // Lấy vị trí thế giới của ô được chọn
            randomPosition = groundTilemap.GetCellCenterWorld(randomCell);

        } while (Vector3.Distance(randomPosition, playerPosition) < distance);

        return randomPosition;
    }

    public void SetFalseCanSet()
    {
        this.canSetPosition = false;
    }

    public void SetTrueCanSet()
    {
        this.canSetPosition = true;
    }
}