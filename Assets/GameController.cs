using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject scoreText;
    private Text Text;
    public GameObject Asteroid;
    public GameObject PlayerShip;


    private CameraScript camera;

    private int score = 0;
    private Grid grid;
    private readonly int gridHeight = 160, gridLength = 160;
    private Vector3 CameraBottomLeft, CameraTopRight;
    private Vector3 topPointCoordinate;
    bool spawn = false;
    private GameObject[,] asterArray;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Before " + Time.realtimeSinceStartup);
        asterArray = new GameObject[gridHeight, gridLength];
        Text = scoreText.GetComponent<Text>();
        grid = GetComponent<Grid>();
        camera = Camera.main.GetComponent<CameraScript>();
        Vector3 spawnPostionShip = grid.CellToWorld(new Vector3Int(gridHeight, gridLength, 0)) / 2;
        Instantiate(PlayerShip, spawnPostionShip, Quaternion.identity);
        camera.Search();

        CameraBottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camera.offsetZ))+spawnPostionShip;
        CameraTopRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camera.offsetZ))+spawnPostionShip;
        Debug.Log(CameraBottomLeft + " BoTTOM LEFT");
        Debug.Log(CameraTopRight + " TOP RIGHT LEFT");

        for (int i = 0; i < 160; ++i)
        {
            for (int j = 0; j < 160; ++j)
            {
                Vector3 spawnPostion = grid.GetCellCenterWorld(new Vector3Int(j, i, 0));// GetMiddlePosition(i, j);


                Instantiate(Asteroid, spawnPostion, Quaternion.identity);
            }
        }

        //for(int i = 0; i < 160 ; i++)
        //{   for(int j=0; j < 160; j++)
        //    {

        //        var go = Instantiate(Asteroid, Vector3.zero, Quaternion.identity);
        //        go.SetActive(false);
        //        asterArray[i, j] = go;

        //    }


        //}
        //for(int i=0; i < asterArray.GetLength(0); i++)
        //{
        //    for(int j=0; j < asterArray.GetLength(1); j++)
        //    {
        //        Vector3 spawnPostion = grid.GetCellCenterWorld(new Vector3Int(j, i, 0));
        //        asterArray[i,j].transform.position = spawnPostion;
        //        asterArray[i, j].SetActive(true);
        //    }
        //}
        Debug.Log("After " + Time.realtimeSinceStartup);
        topPointCoordinate = grid.CellToWorld(new Vector3Int(100, 100, 0));
        UpdateText();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateText()
    {
        Text.text = "Score: " + score++;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    private bool IsInsideCamera(Vector3 bottomLeft, Vector3 topRight, Vector3 point)
    {
        if (point.x >= bottomLeft.x && point.x <= topRight.x) return true;
        if (point.y >= bottomLeft.y && point.y <= topRight.y) return true;
        return false;
    }
    

    public IEnumerator RespawnAsteroid(GameObject asteroid)
    {
       asteroid.SetActive(false);
       
        int randomHeight = Random.Range(0, gridHeight);
        int randomLength = Random.Range(0, gridLength);
        Vector3 randomPosition = grid.GetCellCenterWorld(new Vector3Int(randomLength, randomHeight, 0));
         if (!IsInsideCamera(CameraBottomLeft, CameraTopRight, randomPosition))
        {
            //Instantiate(Asteroid, randomPosition, Quaternion.identity);
            asteroid.transform.position = randomPosition;
            asteroid.gameObject.SetActive(true);
           
        }
        //else
        //{
        //    RespawnAsteroid(asteroid);
        //}
       yield return new WaitForSeconds(1f);

    }
    public void RespAster(GameObject a)
    {
        a.SetActive(false);
        int randomHeight = Random.Range(0, gridHeight);
        int randomLength = Random.Range(0, gridLength);
        Vector3 randomPosition = grid.GetCellCenterWorld(new Vector3Int(randomLength, randomHeight, 0));
        if (!IsInsideCamera(CameraBottomLeft, CameraTopRight, randomPosition))
        {
            a.transform.position = randomPosition;
            a.gameObject.SetActive(true);


        }
    }
}
