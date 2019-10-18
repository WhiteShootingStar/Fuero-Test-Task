using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject scoreText; 
    public GameObject Asteroid;
    public GameObject PlayerShip;


    private Text Text;
    private CameraScript camera;

    //grid
    private Grid grid;
    private readonly int gridHeight = 160, gridLength = 160;

    //some important points for camera and Grid
    private Vector3 CameraBottomLeft, CameraTopRight;
    private Vector3 topPointCoordinate, bottomPointCoordinate;
   
    private int score = 0;
    private float Distance;
    private float gridDistance;
    // Start is called before the first frame update
    void Start()
    {
        
        
        Text = scoreText.GetComponent<Text>();
        grid = GetComponent<Grid>();
        
        //creating ship at the center and assigning camera to it
        Vector3 spawnPostionShip = grid.CellToWorld(new Vector3Int(gridHeight, gridLength, 0)) / 2;
        Instantiate(PlayerShip, spawnPostionShip, Quaternion.identity);
        camera = Camera.main.GetComponent<CameraScript>();
        camera.Search();

        CameraBottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camera.offsetZ)); 
        CameraTopRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camera.offsetZ));
        Distance = Vector3.Distance(CameraBottomLeft, CameraTopRight);

        //fill grid with asteroid
<<<<<<< HEAD
        for (int i = 0; i < gridHeight; ++i)
        {
            for (int j = 0; j < gridLength; ++j)
=======
        for (int i = 0; i < 160; ++i)
        {
            for (int j = 0; j < 160; ++j)
>>>>>>> 2493ad097dd2438841c2c8f9cf4fd1c6e9f67695
            {
                Vector3 spawnPostion = grid.GetCellCenterWorld(new Vector3Int(j, i, 0));

                Instantiate(Asteroid, spawnPostion, Quaternion.identity);
            }
        }


        //distance between most farthest points in the grid
        topPointCoordinate = grid.CellToWorld(new Vector3Int(gridLength, gridHeight, 0));
        bottomPointCoordinate = grid.CellToWorld(new Vector3Int(0, 0, 0));
        gridDistance = Vector3.Distance(topPointCoordinate, bottomPointCoordinate);


        UpdateText();

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

    public void RespawnAtGoodPosition(GameObject  Aster) // respawning outisde of camera
    {
        Vector3 randomPoint = new Vector3(Random.Range(5f, 10f), Random.Range(5f, 10f));
        float randomAngle = Random.Range(0, 360);
         randomPoint= Quaternion.Euler(0, 0, randomAngle) * randomPoint;

        float randomMultiplier = Random.Range(Distance *Distance, gridDistance/2 );
<<<<<<< HEAD
        //final position to spawn
        Aster.transform.position = Vector3.Scale(camera.transform.position, new Vector3(1, 1, 0)) + randomPoint * randomMultiplier;
       
       
       
=======
        Aster.transform.position = Vector3.Scale(camera.transform.position, new Vector3(1, 1, 0));
       
        //final position to spawn
        Aster.transform.position += randomPoint * randomMultiplier;
>>>>>>> 2493ad097dd2438841c2c8f9cf4fd1c6e9f67695

    }

}
