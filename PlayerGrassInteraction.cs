using UnityEngine;

public class PlayerGrassInteraction : MonoBehaviour
{
    public Material[] grassMaterials; // 셰이더가 적용된 Material 배열
    private Vector3 lastPlayerPos;

    void Start()
    {
        lastPlayerPos = transform.position;
    }

    void Update()
    {
        Vector3 currentPlayerPos = transform.position;
        // 현재 위치와 이전 위치를 비교하여 이동 방향 벡터를 계산
        Vector3 playerVelocity = (currentPlayerPos - lastPlayerPos) / Time.deltaTime;

        if (grassMaterials != null)
        {
            foreach (Material material in grassMaterials)
            {
                if (material != null)
                {
                    material.SetVector("_PlayerPos", currentPlayerPos);
                    // 플레이어의 이동 방향(정규화된 벡터)을 셰이더에 전달
                    material.SetVector("_PlayerVelocity", playerVelocity.normalized);
                }
            }
        }
        lastPlayerPos = currentPlayerPos;
    }
}