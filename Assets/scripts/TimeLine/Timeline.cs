using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timeline : MonoBehaviour
{

    public textBoxManager textBoxManager;
    public Player player;
    public BadGal badGal;
    //public Enemy enemy;
    public BossMovement boss;
    public CameraShake cameraShake;


    public string[] timeline;
    //"text","calltocenter", "enemyappears", "text","enemyleaves","gamestart" 
    //string[] timelineboss = {"enemyappears","text","callboss","text", " enemyleaves", "gamestart" };
    int currentState = 0;

    [SerializeField]
    public int[] textStartLines;
    public int[] textEndLines;
    int currentText = 0;

    private void Start()
    {
        Run();
    }

    public void Next()
    {
        currentState++;
        Run();
    }

    private void Run()
    {

        if (currentState < timeline.Length)
        {
            switch (timeline[currentState])
            {
                case "text":
                    textBoxManager.EnableTextBox(textStartLines[currentText], textEndLines[currentText]);
                    currentText = currentText + 1;
                    break;
                case "playerToCenter":
                    player.CallMoveToCenter();
                    break;
                case "enemyAppears":
                    badGal.CallMoveToCenter();
                    break;
                case "enemyLeaves":
                    badGal.CallMoveToSide();
                    break;
                case "callBoss":
                    boss.CallMoveToPosition();
                    cameraShake.ShakeCamera(4, 1);
                    break;
                case "gameStart":
                    player.SetGameStart(true);
                    if (boss != null)
                    {
                        boss.SetStartBattle(true);
                    }
                    break;
                 default: break;
            }
        }
    }
}
