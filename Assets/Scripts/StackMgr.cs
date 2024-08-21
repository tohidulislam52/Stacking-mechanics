using System;
using System.Linq;
using UnityEngine;

public class StackMgr : MonoBehaviour
{
    // [SerializeField] private ParticleSystem _ex;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("blue"))
        {
             other.transform.parent = transform;
             other.gameObject.AddComponent<Rigidbody>().isKinematic = true;
             other.gameObject.AddComponent<StackMgr>();
             other.gameObject.GetComponent<Collider>().isTrigger = true;
             other.tag = gameObject.tag;
             other.GetComponent<Renderer>().material = GetComponent<Renderer>().material;
             Gamemanager.GameManagerInstance.Balls.Add(other.transform);
        }
        
        if (other.CompareTag("add"))
        {
            var NoAdd = Int16.Parse(other.transform.GetChild(0).name);
            Gamemanager.GameManagerInstance.Explosion.Play();
            for (int i = 0; i < NoAdd; i++)
            {
                GameObject Ball =  Instantiate(Gamemanager.GameManagerInstance.Newball, Gamemanager.GameManagerInstance.Balls
                        .ElementAt(Gamemanager.GameManagerInstance.Balls.Count - 1).position + new Vector3(0f, 0f, 0.5f),
                    Quaternion.identity);
              
                Gamemanager.GameManagerInstance.Balls.Add(Ball.transform);
              
            }

            other.GetComponent<Collider>().enabled = false;
        }


        if (other.CompareTag("sub"))
        {
            var NoSub = Int16.Parse(other.transform.GetChild(0).name);
            Gamemanager.GameManagerInstance.Explosion.Play();
            if (Gamemanager.GameManagerInstance.Balls.Count > NoSub)
            {
                for (int i = 0; i < NoSub; i++)
                {
                   Gamemanager.GameManagerInstance.Balls.ElementAt(  Gamemanager.GameManagerInstance.Balls.Count - 1).gameObject.SetActive(false);
                   Gamemanager.GameManagerInstance.Balls.RemoveAt(Gamemanager.GameManagerInstance.Balls.Count - 1);
                }
                
            }
            else if(Gamemanager.GameManagerInstance.Balls.Count < NoSub)
            {
                // for (int i = 0; i < Gamemanager.GameManagerInstance.Balls.Count; i++)
                // {
                // //    Gamemanager.GameManagerInstance.Balls.ElementAt(  Gamemanager.GameManagerInstance.Balls.Count - 1).gameObject.SetActive(false);
                // //    Gamemanager.GameManagerInstance.Balls.RemoveAt(Gamemanager.GameManagerInstance.Balls.Count - 1);
                //    Gamemanager.GameManagerInstance.Balls.ElementAt(i).gameObject.SetActive(false);
                //    Gamemanager.GameManagerInstance.Balls.RemoveAt(i);
                // }
                // Gamemanager.GameManagerInstance._Player.SetActive(false);
                GameObject[] game = GameObject.FindGameObjectsWithTag("Player");
                for (int i = 0; i < game.Length; i++)
                {
                    game[i].SetActive(false);
                }
                Gamemanager.GameManagerInstance.StartTheGame = false;
                Gamemanager.GameManagerInstance._uiManager.GameOver();

                
            }

            // if (Gamemanager.GameManagerInstance.Balls.Count == 0)
            // {
            //     Gamemanager.GameManagerInstance.StartTheGame = false;
            // }
            other.GetComponent<Collider>().enabled = false;
        }


        if(other.CompareTag("red"))
        {
            GameObject[] game = GameObject.FindGameObjectsWithTag("Player");
                for (int i = 0; i < game.Length; i++)
                {
                    game[i].SetActive(false);
                }
                Gamemanager.GameManagerInstance.StartTheGame = false;
                Gamemanager.GameManagerInstance._uiManager.GameOver();

        }
    }


}
