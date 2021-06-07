using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvLGeneration : MonoBehaviour
{
    public GameObject Ground1, Ground2, Dirt, Bridge, Enemy, StartCastle, EndCastle, HoriPlat, VeriPlat, Heart, Diamond, Emerald, FireBall, Star, Jumper, DBlock, Shell, Spike;

    public int minPlatformSize = 1;
    public int maxPlatformSize = 10;
    public int maxHazardSize = 6;
    public int maxHeight = 5;
    public int maxDrop = -5;

    public int platform = 50;
    [Range(0.0f, 1f)]
    public float HazardChance = 0.5f;
    [Range(0.0f, 1f)]
    public float bridgeChance = 0.1f;
    [Range(0.0f, 1f)]
    public float EnemyChance = 0.3f;
    [Range(0.0f, 1f)]
    public float DeathBlock = 0.3f;
    [Range(0.0f, 1f)]
    public float CollectibleChance = 0.2f;
    [Range(0.0f, 1f)]

    private int blockNum = 38;
    private int blockHeight;
    private bool isHazard;
    private bool changer = true;


    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(9,13,true);
        Instantiate(StartCastle, new Vector3(-10, 0, 0), Quaternion.Euler(0,90,0));
        Instantiate(HoriPlat);
        Instantiate(VeriPlat);
        Instantiate(Diamond, new Vector3(36, 10, 0), Quaternion.Euler(-90, 0, 0));
        Instantiate(Ground1, new Vector3(36, 8, 0), Quaternion.identity);
        // Instantiate(Ground2, new Vector3(2, 0, 0), Quaternion.identity);

        for (int plat = 1; plat < platform; plat++)
        {
            if (isHazard)
            {
                isHazard = false;
            }
            else
            {
                if (Random.value < HazardChance)
                {
                    isHazard = true;
                }
                else
                {
                    isHazard = false;
                }
            }
            if (isHazard)
            {
                int hazardSize = Mathf.RoundToInt(Random.Range(1, maxHazardSize));
                blockNum += hazardSize;
            }

            else
            {
                if (Random.value < bridgeChance)
                {
                    int platformSize = Mathf.RoundToInt(Random.Range(minPlatformSize, maxPlatformSize));

                    // int platformHeight = Mathf.RoundToInt(Random.Range(maxDrop, maxHeight));
                    blockHeight = blockHeight + Random.Range(maxDrop, maxHeight);
                    for (int tiles = 0; tiles < platformSize; tiles+=2)
                    {
                        if (tiles == 0 || tiles == platformSize)
                        {
                            if (changer)
                            {
                                Instantiate(Ground1, new Vector3(blockNum, blockHeight, 0), Quaternion.identity);
                                changer = !changer;
                            }
                            else
                            {
                                Instantiate(Ground2, new Vector3(blockNum, blockHeight, 0), Quaternion.identity);
                                changer = !changer;
                            }
                            /*if (Random.value < EnemyChance)
                            {
                                Instantiate(Enemy, new Vector3(blockNum, blockHeight, 0), Quaternion.identity);
                            }*/

                            /*if (Random.value < CollectibleChance)
                            {
                                Instantiate(CollectableSelector(), new Vector3(blockNum, blockHeight + 2, 0), Quaternion.Euler(-90, 0, 0));
                            }*/

                            for(int grdLow = 1; grdLow < 5; grdLow++)
                            {
                                Instantiate(Dirt, new Vector3(blockNum, blockHeight-grdLow, 0), Quaternion.identity);
                            }

                            blockNum += 4;
                        }
                        else
                        {
                            Instantiate(Bridge, new Vector3(blockNum, blockHeight, 0), Quaternion.Euler(0,90,0));
                            blockNum += 2;
                        }


                    }
                }
                else
                {
                    int platformSize = Mathf.RoundToInt(Random.Range(minPlatformSize, maxPlatformSize));

                    // int platformHeight = Mathf.RoundToInt(Random.Range(maxDrop, maxHeight));
                    blockHeight = blockHeight + Random.Range(maxDrop, maxHeight);
                    for (int tiles = 0; tiles < platformSize; tiles+=2)
                    {
                        if (changer)
                        {
                            Instantiate(Ground1, new Vector3(blockNum, blockHeight, 0), Quaternion.identity);
                            changer = !changer;
                        }
                        else
                        {
                            Instantiate(Ground2, new Vector3(blockNum, blockHeight, 0), Quaternion.identity);
                            changer = !changer;
                        }
                        if (Random.value < CollectibleChance)
                        {
                            Instantiate(CollectableSelector(), new Vector3(blockNum, blockHeight + 2, 0), Quaternion.Euler(-90, 0, 0));
                        }
                        if (Random.value < EnemyChance)
                        {
                            int enemychancer = Random.Range(1, 4);
                            if (enemychancer == 1)
                            {
                                Instantiate(Enemy, new Vector3(blockNum, blockHeight, 0), Quaternion.identity);
                            }
                            else if (enemychancer ==2)
                            {
                                Instantiate(Spike, new Vector3(blockNum, blockHeight, 0), Quaternion.identity);
                            }
                            else
                            {
                                Instantiate(Shell, new Vector3(blockNum, blockHeight, 0), Quaternion.identity);
                            }

                        }
                        for (int grdLow = 1; grdLow < 5; grdLow++)
                        {
                            Instantiate(Dirt, new Vector3(blockNum, blockHeight-grdLow, 0), Quaternion.identity);
                        }
                        if (Random.value < DeathBlock)
                        {
                            blockNum += 2;
                            Instantiate(DBlock, new Vector3(blockNum, blockHeight+2, 0), Quaternion.identity);
                        }
                        blockNum += 2;

                    }
                }
            }
        }
        //Debug.Log(blockNum);
        Instantiate(EndCastle, new Vector3(blockNum+36, blockHeight, 0), Quaternion.Euler(0, -90, 0));

    }

    public GameObject CollectableSelector()
    {
        // 1-Heart, 2-Diamond, 3-Fireball, 4-Emerald, 5-Jumper, 6-Star
        int chance = Random.Range(0, 100);
        if (chance < 50)               //  0 .. 49
        {
            return Diamond;
        }
        else if (chance < 50 + 20 + 5)     // 50 .. 69..74
        {
            int minichance = Random.Range(1, 3);
            if(minichance == 1)
            {
                return Heart;
            }
            else
            {
                return Emerald;
            }
        }
        else if (chance < 50 + 20 + 20 + 5) // 70 .. 74 
        {
            int minichance = Random.Range(1, 3);
            if (minichance == 1)
            {
                return Jumper;
            }
            else
            {
                return FireBall;
            }
        }
        else
        {
            return Star;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
