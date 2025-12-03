using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public float enemySpeed = 2f;
    public float slowedSpeed = 0f;
    public float baseSpeed = 2f;
    public UnityEvent onHitPlayer;
    public UnityEvent onDeath;
    public float charges = 5f;
    public float timer = 30f;
    public float targetTime = 10.0f;
    public bool timerRunning = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && charges > 0) {
            timerRunning = true;
            targetTime = 10.0f;
            charges--;
        } 
        if (timerRunning && charges >= 0){
            if (targetTime > 0){
                enemySpeed = slowedSpeed;
                Debug.Log(charges);
                targetTime -= Time.deltaTime;
            }
        }
        if (targetTime <= 0)
        {
            timerEnded();
        }
        transform.LookAt(player);
        transform.Translate(enemySpeed * Time.deltaTime * Vector3.forward);
    }
    void timerEnded()
    {
        enemySpeed = baseSpeed;
        targetTime = 0f;
        timerRunning = false;
    }
}
