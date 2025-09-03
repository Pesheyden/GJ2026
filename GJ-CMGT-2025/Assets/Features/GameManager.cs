using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (!_instance)
                _instance = FindAnyObjectByType<GameManager>();

            return _instance;
        }
    }

    [SerializeField] private GameObject _gameEndBlock;
    public bool HasKey;

    public void GameEnd()
    {
        Debug.Log("GameEnd");
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
        _gameEndBlock.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void GameWin()
    {
        
    }

    public void SetTrapsVisible(bool value)
    {
        var list = GameObject.FindGameObjectsWithTag("Blind");
        foreach (var gameObject in list)
        {
                gameObject.SetActive(value);
        }
    }
}
