using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbuelaScript : MonoBehaviour
{
    public GameObject GaboBolacopia;
    public int rutine;
    public float chronometer;
    public Quaternion angle;
    public float grade;
    private List<GameObject> players;
    private GameObject closestPlayer;

    void Start()
    {
        UpdatePlayerList();
    }

    void Update()
    {
        UpdatePlayerList();
        Enemie_Behavior();
    }

    void UpdatePlayerList()
    {
        // Find all players with the tag "Player" and store them in the list
        players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
    }

    GameObject GetClosestPlayer()
    {
        GameObject closest = null;
        float minDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (GameObject player in players)
        {
            float distance = Vector3.Distance(player.transform.position, currentPosition);
            if (distance < minDistance)
            {
                closest = player;
                minDistance = distance;
            }
        }

        return closest;
    }

    public void Enemie_Behavior()
    {
        closestPlayer = GetClosestPlayer();

        if (closestPlayer == null) return;

        if (Vector3.Distance(transform.position, closestPlayer.transform.position) > 2)
        {
            chronometer += 1 * Time.deltaTime;
            if (chronometer >= 4)
            {
                rutine = Random.Range(0, 2);
                chronometer = 0;
            }

            switch (rutine)
            {
                case 0:
                    grade = Random.Range(0, 360);
                    angle = Quaternion.Euler(0, grade, 0);
                    rutine++;
                    break;

                case 1:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    break;
            }
        }
        else
        {
            var lookPos = closestPlayer.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);

            transform.Translate(Vector3.forward * 5 * Time.deltaTime);
        }
    }
}