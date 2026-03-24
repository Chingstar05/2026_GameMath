using UnityEngine;
using UnityEngine.InputSystem;

public class ClickToMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 mouseScreenPosition;
    private Vector3 targetPosition;
    private bool isMoving = false;

    public void OnPoint(InputValue value)
    {
        mouseScreenPosition = value.Get<Vector2>();
    }

    public void OnClick(InputValue value)
    {
        if(value.isPressed)
        {
            Ray ray = Camera.main.ScreenPointToRay(mouseScreenPosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);

            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.gameObject != gameObject)
                {
                    targetPosition = hit.point;
                    targetPosition.y = targetPosition.y;
                    isMoving = true;

                    break;
                }
            }
        }   
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            // 방향 벡터 구하기
            Vector3 toTarget = targetPosition - transform.position;

            // 길이 제곱 계산
            float sqrDist = toTarget.x * toTarget.x + toTarget.y * toTarget.y + toTarget.z * toTarget.z;

            if (sqrDist < 0.01f)   // 0.1 * 0.1 = 0.01
            {
                isMoving = false;  // 목적지에 거의 도착 → 이동 중지
            }
            else
            {
                float dist = Mathf.Sqrt(sqrDist);
                Vector3 normalized = new Vector3(
                    toTarget.x / dist,
                    toTarget.y / dist,
                    toTarget.z / dist
                );

                transform.position += normalized * moveSpeed * Time.deltaTime;
            }
        }
    }
}
