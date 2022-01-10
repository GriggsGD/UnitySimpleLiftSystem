using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LiftSystem : MonoBehaviour
{
    [SerializeField] float liftSpeed = 5;
    [SerializeField] Transform liftAnchor;
    [SerializeField] Transform[] levelPositions;
    [SerializeField] int liftPositionAtStart = 0;
    int currLiftLevel;
    int desiredLevel;
    void Start()
    {
        liftAnchor.position = new Vector3(transform.position.x, levelPositions[liftPositionAtStart].position.y, transform.position.z);
        currLiftLevel = liftPositionAtStart;
        desiredLevel = currLiftLevel;
    }
    void Update()
    {
        MoveLift();
    }
    void MoveLift()
    {
        for (int i = 0; i < levelPositions.Length; i++)
        {
            if (levelPositions[i].position.y == liftAnchor.position.y) currLiftLevel = i;
        }

        float step = liftSpeed * Time.deltaTime;
        liftAnchor.position = Vector3.MoveTowards(liftAnchor.position, new Vector3(liftAnchor.position.x, levelPositions[desiredLevel].position.y, liftAnchor.position.z), step);
    }

    public void SimpleMoveToNextLvl()
    {
        if (desiredLevel == levelPositions.Length - 1)
        {
            desiredLevel = 0;
        }
        else desiredLevel++;
    }
    public void MoveUpLvl()
    {
        if (desiredLevel == levelPositions.Length - 1)
        {
            return;
        }
        else desiredLevel++;
    }
    public void MoveDownLvl()
    {
        if (desiredLevel == 0)
        {
            return;
        }
        else desiredLevel--;
    }
}
