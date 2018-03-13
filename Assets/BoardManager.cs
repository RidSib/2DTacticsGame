using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {
    
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count (int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }
    public int columns = 30;
    public int rows = 20;

    public GameObject tank;
    public GameObject mage;
    public GameObject vampire;
    public GameObject knight;
    public GameObject altar;
    public GameObject book;
    public GameObject floorTile;
    public GameObject obstacleTile;
    public GameObject highlighting;
    public List<NonPlayerCharacters> enemies;
    public FloorTile[] floorTileObjects;
    public GameObject attackField;
    private bool alerted = false;
    private Transform boardHolder;
    private List<Vector3> gridPostions = new List<Vector3>();

    void InitializeList()
    {
        gridPostions.Clear();

        for (int x = 0; x < columns -1; x++)
        {
            for (int y = 0; y < rows -1; y++)
            {
                gridPostions.Add(new Vector3(x, y, 0f));
            }
        }
    }

    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;

        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                FloorTile ft = floorTile.GetComponent<FloorTile>();
                ft.x = x;
                ft.y = y;
                Instantiate(floorTile, new Vector3(x, y, 0f), Quaternion.identity);
                
                // GameObject instance = Instantiate(floorTile, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                //instance.transform.SetParent(boardHolder);
            }
        }
    }

    void InteractableSetup()
    {
        Instantiate(obstacleTile, new Vector3(5, 16, 0f), Quaternion.identity);
        Instantiate(obstacleTile, new Vector3(25, 13, 0f), Quaternion.identity);
        Instantiate(obstacleTile, new Vector3(8, 8, 0f), Quaternion.identity);
        Instantiate(altar, new Vector3(17, 13, 0f), Quaternion.identity);
        Instantiate(obstacleTile, new Vector3(17, 15, 0f), Quaternion.identity);
        Instantiate(obstacleTile, new Vector3(18, 15, 0f), Quaternion.identity);
        Instantiate(obstacleTile, new Vector3(19, 15, 0f), Quaternion.identity);
        Instantiate(obstacleTile, new Vector3(19, 14, 0f), Quaternion.identity);
        Instantiate(obstacleTile, new Vector3(19, 12, 0f), Quaternion.identity);
        Instantiate(obstacleTile, new Vector3(19, 11, 0f), Quaternion.identity);
        Instantiate(obstacleTile, new Vector3(18, 11, 0f), Quaternion.identity);
        Instantiate(obstacleTile, new Vector3(17, 11, 0f), Quaternion.identity);
        Instantiate(obstacleTile, new Vector3(14, 11, 0f), Quaternion.identity);
        Instantiate(obstacleTile, new Vector3(12, 11, 0f), Quaternion.identity);
        Instantiate(obstacleTile, new Vector3(13, 11, 0f), Quaternion.identity);
        Instantiate(obstacleTile, new Vector3(14, 15, 0f), Quaternion.identity);
        Instantiate(obstacleTile, new Vector3(12, 15, 0f), Quaternion.identity);
        Instantiate(obstacleTile, new Vector3(13, 15, 0f), Quaternion.identity);
        Instantiate(obstacleTile, new Vector3(12, 12, 0f), Quaternion.identity);
        Instantiate(obstacleTile, new Vector3(12, 14, 0f), Quaternion.identity);
        Instantiate(book, new Vector3(15, 3, 0f), Quaternion.identity);
        Instantiate(obstacleTile, new Vector3(15, 4, 0f), Quaternion.identity);
        Instantiate(obstacleTile, new Vector3(14, 4, 0f), Quaternion.identity);
        Instantiate(obstacleTile, new Vector3(16, 4, 0f), Quaternion.identity);
        Instantiate(obstacleTile, new Vector3(15, 2, 0f), Quaternion.identity);
        Instantiate(obstacleTile, new Vector3(14, 2, 0f), Quaternion.identity);
        Instantiate(obstacleTile, new Vector3(16, 2, 0f), Quaternion.identity);
        Instantiate(obstacleTile, new Vector3(16, 3, 0f), Quaternion.identity);
    }

    void EnemySetup()
    {
        Vector2 k1p, k2p, k3p;
        k1p = new Vector3(16, 10);
        k2p = new Vector3(14, 10);
        k3p = new Vector3(16, 13);
        NonPlayerCharacters k1 = knight.GetComponent<NonPlayerCharacters>();
        k1.x = (int)k1p.x;
        k1.y = (int)k1p.y;
        k1.setCharacter(0);
        enemies.Add(Instantiate(k1, k1p, Quaternion.identity));
        NonPlayerCharacters k2 = knight.GetComponent<NonPlayerCharacters>();
        k2.x = (int)k2p.x;
        k2.y = (int)k2p.y;
        k2.setCharacter(0);
        enemies.Add(Instantiate(k2, k2p, Quaternion.identity));
        NonPlayerCharacters k3 = knight.GetComponent<NonPlayerCharacters>();
        k3.x = (int)k3p.x;
        k3.y = (int)k3p.y;
        k3.setCharacter(0);
        enemies.Add(Instantiate(k3, k3p, Quaternion.identity));
    }



    void CharacterSetup()
    {
        Vector2 tPos, mPos, vPos;
        tPos = new Vector3(2, 0, 0f);
        mPos = new Vector3(0, 0, 0f);
        vPos = new Vector3(1, 0, 0f);
        PlayerCharacters t = tank.GetComponent<PlayerCharacters>();
        t.setCharacter(0);
        t.x = (int) tPos.x;
        t.y = (int) tPos.y;
        Instantiate(tank, tPos, Quaternion.identity);
        PlayerCharacters m = mage.GetComponent<PlayerCharacters>();
        m.setCharacter(1);
        m.x = (int)mPos.y;
        m.y = (int)mPos.y;
        Instantiate(mage, mPos, Quaternion.identity);
        PlayerCharacters v = vampire.GetComponent<PlayerCharacters>();
        v.setCharacter(2);
        v.x = (int) vPos.x;
        v.y = (int) vPos.y;
        Instantiate(vampire, vPos, Quaternion.identity);
    }

    public void EnemyTurn()
    {
        GameObject text = GameObject.Find("Info");
        Text t2 = (Text)text.GetComponent(typeof(Text));
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemyObject in enemies)
        {
            NonPlayerCharacters enemy = enemyObject.GetComponent<NonPlayerCharacters>();
            GameObject[] characterObjects = GameObject.FindGameObjectsWithTag("Player");
            PlayerCharacters closestCharacter = null;
            int distance2ClosestChar = 1000;
            foreach (GameObject characterObject in characterObjects)
            {
                PlayerCharacters character = characterObject.GetComponent<PlayerCharacters>();
                int distance = System.Math.Abs(character.x - enemy.x) + System.Math.Abs(character.y - enemy.y);
                if(!alerted && distance < 6)
                {
                    
                    t2.text += "\nThe knight screams:\"Demons! Cultists! Tax-Evaders! Ready your arms men!\"";
                    t2.text += "\nYou have alerted the order of the fifth dawn.";
                    alerted = true;
                }
                if (distance < distance2ClosestChar)
                {
                    distance2ClosestChar = distance;
                    closestCharacter = character;
                }
            }
            if (alerted)
            {
                if (distance2ClosestChar <= enemy.moveRange + 1)
                {
                    MoveEnemyNext2Player(enemy, closestCharacter);

                    float roll = Random.Range(0.0f, 100.0f);
                    if (roll >= 50)
                    {
                        int damage = (enemy.damage - closestCharacter.defence);
                        closestCharacter.health -= damage;
                        if (closestCharacter.health > 0)
                        {
                            t2.text += "\n<color=#008000ff>" + enemy.name + "</color> attacked <color=#F62D2DFF>" + closestCharacter.name + "</color> and did <b>" + damage + "</b>";
                        }
                        else
                        {
                            t2.text += "\nIn an act guided by the fifth dawn itself<color=#008000ff>" + enemy.name + "</color> kills <color=#F62D2DFF>" + closestCharacter.name + "</color>. It is a good day to be good!";
                            Destroy(closestCharacter.gameObject);
                        }
                    }
                    else
                    {
                        t2.text += "\nThe knight stumbled and fell over his sword! You laugh and spit on him!";
                    }


                }
                else
                {
                    int movement = enemy.moveRange;
                    Vector3 goHere = new Vector3(enemy.x, enemy.y, 0);
                    while (movement > 0)
                    {
                        if (closestCharacter.x != goHere.x)
                        {
                            goHere.x += Math.Sign(closestCharacter.x - goHere.x);
                        }
                        else
                        {
                            goHere.y += Math.Sign(closestCharacter.y - goHere.y);
                        }
                        movement -= 1;
                    }
                    enemy.x = (int) goHere.x;
                    enemy.y = (int) goHere.y;
                    enemy.gameObject.transform.position = goHere;
                }
            }
        }
    }

    private void MoveEnemyNext2Player(NonPlayerCharacters enemy, PlayerCharacters player)
    {
        int x, y;
        x = player.x + 1;
        y = player.y;
        int distance = System.Math.Abs(x - enemy.x) + System.Math.Abs(y - enemy.y);
        if(distance <= enemy.moveRange)
        {
            enemy.x = x;
            enemy.y = y;
            enemy.gameObject.transform.position = new Vector3(x, y, 0);
            return;
        }
        x = player.x - 1;
        y = player.y;
        distance = System.Math.Abs(x - enemy.x) + System.Math.Abs(y - enemy.y);
        if (distance <= enemy.moveRange)
        {
            enemy.x = x;
            enemy.y = y;
            enemy.gameObject.transform.position = new Vector3(x, y, 0);
            return;
        }
        x = player.x;
        y = player.y+1;
        distance = System.Math.Abs(x - enemy.x) + System.Math.Abs(y - enemy.y);
        if (distance <= enemy.moveRange)
        {
            enemy.x = x;
            enemy.y = y;
            enemy.gameObject.transform.position = new Vector3(x, y, 0);
            return;
        }
        x = player.x;
        y = player.y-1;
        distance = System.Math.Abs(x - enemy.x) + System.Math.Abs(y - enemy.y);
        if (distance <= enemy.moveRange)
        {
            enemy.x = x;
            enemy.y = y;
            enemy.gameObject.transform.position = new Vector3(x, y, 0);
            return;
        }
    }

    public void Attack()
    {
        GameObject playerObj = GameObject.FindWithTag("SelectedPlayer");
        PlayerCharacters player = playerObj.GetComponent<PlayerCharacters>();

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemyObject in enemies)
        {
            NonPlayerCharacters enemy = enemyObject.GetComponent<NonPlayerCharacters>();
            int distanceToEnemy = System.Math.Abs(player.x - enemy.x) + System.Math.Abs(player.y - enemy.y);

            if(distanceToEnemy <= player.attackRange)
            {
                AttackFields f = attackField.GetComponent<AttackFields>();
                f.player = player;
                f.enemy = enemy;
                Instantiate(f, new Vector3(enemy.x, enemy.y, 0f), Quaternion.identity);
            }
        }
    }
    public void Ability()
    {

    }
    public void EndTurn()
    {
        if (GameObject.FindWithTag("SelectedPlayer") != null)
            GameObject.FindWithTag("SelectedPlayer").tag = "Player";

        GameObject[] characterObjects = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject characterObject in characterObjects)
        {
            PlayerCharacters character = characterObject.GetComponent<PlayerCharacters>();
            character.hasMoved = false;
            character.hasActed = false;
        }
        EnemyTurn();
    }

    public void LoadMap()
    {
        BoardSetup();
        CharacterSetup();
        InteractableSetup();
        EnemySetup();
        GameObject text = GameObject.Find("Info");
        Text info = (Text)text.GetComponent(typeof(Text));

        info.text += "\nWelcome to path to infamy! You play a group of dirty and dark servants to the dark lords. The order of fith dawn protects a temple of light! Kill them all and claim this ancient building for your malicious overlords! Click on your characters to move and attack with them. After you are satisfied with all your characters actions press \"End Turn\"";
    }
}
