using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCounter : MonoBehaviour
{
    public static EnemyCounter Instance {get; private set;}
    public int enemyCount = 4;

    private void Awake() {
        if(Instance == null){
            Instance = this;
        }
    }

    public void EnemyDied(){
        enemyCount--;
        if(enemyCount == 0){
            SceneManager.LoadScene("donkeykong"); 
        }
            
    }
}
