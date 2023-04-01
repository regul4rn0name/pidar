using UnityEngine;

public class pacman_enemyMove : MonoBehaviour
{
    public Transform pacman;
    public float speed = 5f;
    public LayerMask obstacleLayer;
    

    void Start() {
        obstacleLayer = LayerMask.NameToLayer("Obstacle");
    }
    private void Update()
    {
        // Вычисляем направление движения к пакмену
        Vector2 direction = (pacman.position - transform.position).normalized;

        // Проверяем, есть ли препятствие в направлении движения
        if (Physics2D.Raycast(transform.position, direction, 0.1f, obstacleLayer))
        {
            // Если есть, выбираем новое направление движения
            direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        }

        // Перемещаем призрака в заданном направлении
        transform.Translate(direction * speed * Time.deltaTime);
    }
}