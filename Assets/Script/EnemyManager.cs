using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance; // Instancia única del administrador de enemigos

    private List<GameObject> aliveEnemies = new List<GameObject>(); // Lista de enemigos vivos

    private int playerDamageIncrease = 5; // Aumento de daño del jugador por cada enemigo eliminado

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Mantener el objeto entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // Suscribirse al evento de carga de escena
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Al cargar una nueva escena, limpiar la lista de enemigos vivos
        aliveEnemies.Clear();
    }

    public void RegisterEnemy(GameObject enemy)
    {
        aliveEnemies.Add(enemy); // Agregar un enemigo a la lista de enemigos vivos
    }

    public void UnregisterEnemy(GameObject enemy)
    {
        aliveEnemies.Remove(enemy); // Eliminar un enemigo de la lista de enemigos vivos
    }

    public int GetAliveEnemyCount()
    {
        return aliveEnemies.Count; // Obtener la cantidad de enemigos vivos
    }

    public void PlayerEliminatedEnemy()
    {
        // Aumentar el daño del jugador por eliminar un enemigo
        Combat playerCombat = FindObjectOfType<Combat>(); // Encontrar el componente Combat del jugador
        if (playerCombat != null)
        {
            playerCombat.IncreaseAttackDamage(playerDamageIncrease); // Llamar al método para aumentar el daño
        }
    }
}

