using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform character;
    public GameObject[] stageChip;
    public List<GameObject> generateStageList = new List<GameObject>();
    public int preInstance = 5;
    public int currentChipIndex;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int characterPositionIndex = (int)(character.position.z / 30f);
        if (characterPositionIndex + preInstance > currentChipIndex)
        {
            for (int i = currentChipIndex + 1; i <= preInstance; i++)
            {
                GameObject stageObject = Instantiate(stageChip[0]);
                stageObject.transform.position = new Vector3(0, 0, i * 30f);
                generateStageList.Add(stageObject);
                currentChipIndex++;
            }
        }
    }
}
