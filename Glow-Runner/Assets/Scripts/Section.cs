using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Section : MonoBehaviour
{
    private int sectionsCount = 0;
    public float sectionSize = 20;
  public List<GameObject> obstacles;
    public float speed;
    private static int lastRandomIndex = -1;

    void Start(){
        sectionsCount = GameObject.FindGameObjectsWithTag("Section").Length;
       obstacles = new List<GameObject>();
            
        foreach(Transform child in transform)
            {
                if (child.tag == "Obstacle")
                {
                    obstacles.Add(child.gameObject);
                }
            }
        EnableRandomObstacle();
        }

    public void EnableRandomObstacle()
    {
        foreach (GameObject obstacle in obstacles)
        {
            obstacle.SetActive(false);
        }
        int randomIndex = lastRandomIndex;
        while (randomIndex == lastRandomIndex)
        {
          randomIndex = Random.Range(0, obstacles.Count);
        }
        lastRandomIndex = randomIndex;
        obstacles[randomIndex].SetActive(true);
    }

    private void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        if (transform.position.z <= -sectionSize)
        {
            transform.Translate(Vector3.forward * sectionSize * sectionsCount); // para que el primer piso pase al final 
           
            EnableRandomObstacle();
        }  
    }
}
