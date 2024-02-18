using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class TurnScript : MonoBehaviour 
{
    public GameObject gameover;
    public GameObject redTurn;
    public GameObject blueTurn;
    public GameObject red_win;
    public GameObject blue_win;
    public GameObject image;
    public GameObject audio;
    public GameObject restartgame;
    public GameObject Exit;
    public GameObject about;
    public GameObject lineHorizontal;
    public GameObject lineVertical;
    public GameObject lineDownward;
    public GameObject lineUpward;
    public GameObject draw;
    public int buttonNum;
    private bool isRed = false,isBlue = false;
    public int turn = 0;
    public void TurnValue()
    {
        turn ++;
        // Debug.Log(" " + turn );
    }
      private float [] x = new float [7];
      private float [] y =new float [6];

      
        private int [,] match = new int [6,7];
    private int row,col;
    // private int buttonNum;

    public void Start()
    {
        x[0] = -5.72f;
        x[1] = -3.86f;
        x[2] = -1.94f;
        x[3] = -0.12f;
        x[4] = 1.72f;
        x[5] = 3.53f;
        x[6] = 5.4f;

        y[0] = 5.4f;
        y[1] = 3.34f;
        y[2] = 1.12f;
        y[3] = -1f;
        y[4] = -3.25f;
        y[5] = -5.44f;
     

        redTurn.SetActive(true);
        gameover.SetActive(false);
        draw.SetActive(false);
        red_win.SetActive(false);
        blue_win.SetActive(false);
        image.SetActive(false);
        restartgame.SetActive(false);
        Exit.SetActive(false);
        about.SetActive(false);
        //draw.SetActive(false);
         //GetComponent<AudioSource>().SetActive(true);
        for( row = 0;row < 6; row ++)
        {
            for( col = 0; col < 7;col ++)
            {
                match[row,col] = 0;
            }
        }
      //  Debug.Log("match is " + match[0,0]);
    }
    public void ReturnBt()
    {
         string clickButton = EventSystem.current.currentSelectedGameObject.name;
          buttonNum = int.Parse(clickButton);
         
    }
    public void ReturnNum()
    {
        ReturnBt();
          
        for( row = 0; row < 6; row ++)
            {
               if(match[row,buttonNum] != 0)
               {
                    break;
               }
            }
            match[(row - 1),buttonNum] = 1;
            
    }

    //  public void Print()
    // {
    //     for( row = 0;row < 6; row ++)
    //         {
    //             for( col = 0; col < 7;col ++)
    //             {
    //                 Debug.Log(match[row,col]);
    //             }
    //         }
    //          Debug.Log("Button is "+ buttonNum);

            
    // }
    public void ReturnNum1()
    {
        
        ReturnBt();
        for( row = 0; row < 6; row ++)
            {
               if(match[row,buttonNum] != 0)
               {
                    break;
               }
            }
            match[(row - 1),buttonNum] = 2;
            
    }
    int a;
    int b;
 
    public void MatchAlgorithm()
    {
        //Horizontal
        for(int i=0;i<6;i++)
        {
            for(int j= 0;j<4;j++)
            {
                for(int k =j;k<j+4;k++)
                {
                    if(match[i,k] == 1)
                    isRed=true;
                    else
                    {
                        isRed = false;
                        break;
                    }
                }
                for(int k =j;k<j+4;k++)
                {
                    if(match[i,k] == 2){
                    isBlue=true;
                    }
                    else
                    {
                        isBlue = false;
                        break;
                    }
                //    a=j;
                //    b=i;
                  
                }
                if(isRed)
                {
                    redTurn.SetActive(false);
                    blueTurn.SetActive(false);
                   Instantiate(lineHorizontal,new Vector3(x[j],y[i],0),Quaternion.identity);
                    Debug.Log("Horizontal matched ,Red wins");
                    gameover.SetActive(true);
                    red_win.SetActive(true);
                     image.SetActive(true);
                     restartgame.SetActive(true);
                     //Exit.SetActive(true);
                     about.SetActive(true);
                     //GetComponent<AudioSource>().SetActive(false);
                    //System.Environment.Exit(0);
                }
                else if(isBlue)
                {
                    Instantiate(lineHorizontal,new Vector3(x[j],y[i],0),Quaternion.identity);
                    Debug.Log("Horizontal matched ,Blue wins");
                    gameover.SetActive(true);
                    blue_win.SetActive(true);
                     image.SetActive(true);
                     restartgame.SetActive(true);
                     //Exit.SetActive(true);
                     about.SetActive(true);
                     //GetComponent<AudioSource>().SetActive(false);
                   
                }
            }
        }
        isRed=false;
        isBlue=false;


        //Vertical Algorithm
        for(int j=0;j<7;j++)
        {
            for(int i= 0;i<3;i++)
            {
                for(int k =i;k<i+4;k++)
                {
                    if(match[k,j] == 1)
                    isRed=true;
                    else
                    {
                        isRed = false;
                        break;
                    }
                }
                for(int k =i;k<i+4;k++)
                {
                    if(match[k,j] == 2)
                    isBlue=true;
                    else
                    {
                        isBlue = false;
                        break;
                    }
                }
                if(isRed)
                {
                     Instantiate(lineVertical,new Vector3(x[j],y[i],0),Quaternion.identity);
                    Debug.Log("Vertical matched ,Red wins");
                    gameover.SetActive(true);
                    red_win.SetActive(true);
                     image.SetActive(true);
                     restartgame.SetActive(true);
                     //Exit.SetActive(true);
                     about.SetActive(true);
                     //GetComponent<AudioSource>().SetActive(false);
                }
                else if(isBlue)
                {
                     Instantiate(lineVertical,new Vector3(x[j],y[i],0),Quaternion.identity);
                    Debug.Log("Vertical matched ,Blue wins");
                    gameover.SetActive(true);
                    blue_win.SetActive(true);
                     image.SetActive(true);
                     restartgame.SetActive(true);
                     //Exit.SetActive(true);
                     about.SetActive(true);
                    // GetComponent<AudioSource>().SetActive(false);
                }
            }
        }
        isRed=false;
        isBlue=false;
        //Downward Diagonal
        int c=0,d=0;

        for(int j=0;j<4;j++)
        {
            for(int i= 0;i<3;i++)
            {
                if(match[i,j] == 1 &&match[i+1,j+1] == 1 &&match[i+2,j+2] == 1 &&match[i+3,j+3] == 1 )
                {
                    isRed = true;
                    d=i;
                    c=j;
                }
                if(match[i,j] == 2 &&match[i+1,j+1] == 2 &&match[i+2,j+2] == 2 &&match[i+3,j+3] == 2 )
                {
                    isBlue = true;
                    d=i;
                    c=j;
                }
            
            }

             
              
        }
         if(isRed)
                {
                    Instantiate(lineDownward,new Vector3(x[c],y[d],0),Quaternion.identity);
                    Debug.Log("Downward diagonal ,Red wins");
                    gameover.SetActive(true);
                    red_win.SetActive(true);
                     image.SetActive(true);
                     restartgame.SetActive(true);
                     //Exit.SetActive(true);
                     about.SetActive(true);
                    //GetComponent<AudioSource>().SetActive(false);
                }
        else if(isBlue)
         {
            Instantiate(lineDownward,new Vector3(x[c],y[d],0),Quaternion.identity);
                    Debug.Log("Downward diagonal ,Blue wins");
                    gameover.SetActive(true);
                    blue_win.SetActive(true);
                     image.SetActive(true);
                     restartgame.SetActive(true);
                     //Exit.SetActive(true);
                     about.SetActive(true);
                    //GetComponent<AudioSource>().SetActive(false);   
                      }           
                        

        isRed=false;
        isBlue=false;
         
       //Upward diagonal
int a=0,b=0;
        for(int i=3;i<6;i++)
        {
            for(int j= 0;j<4;j++)
            {
                if(match[i,j] == 1 && match[i-1,j+1] == 1 && match[i-2,j+2] == 1 && match[i-3,j+3] == 1 )
                {
                    isRed = true;
                    a = j;
                    b = i;
                }
                if(match[i,j] == 2 && match[i-1,j+1] == 2 && match[i-2,j+2] == 2 && match[i-3,j+3] == 2 )
                {
                    isBlue = true;
                    a = j;
                    b = i;
                }
               
            }

        }
         if(isRed)
                {
                     Instantiate(lineUpward,new Vector3(x[a],y[b],0),Quaternion.identity);
                    Debug.Log("Upward diagonal ,Red wins");
                    gameover.SetActive(true);
                    red_win.SetActive(true);
                     image.SetActive(true);
                     restartgame.SetActive(true);
                    //Exit.SetActive(true);
                    about.SetActive(true);
                     //GetComponent<AudioSource>().SetActive(false);
                }
        else if(isBlue)
         {
             Instantiate(lineUpward,new Vector3(x[a],y[b],0),Quaternion.identity);
                    Debug.Log("Upward diagonal ,Blue wins");
                    gameover.SetActive(true);
                    blue_win.SetActive(true);
                     image.SetActive(true);
                     
                     restartgame.SetActive(true);
                   //Exit.SetActive(true);
                   about.SetActive(true);
                     //GetComponent<AudioSource>().SetActive(false);
                }
                //  if(isRed==false && isBlue==false)
                // Debug.Log("Draw");

                isRed=false;
                isBlue=false;


        if(turn == 42 && isBlue == false && isRed == false) 
        {//&& !isBlue && isRed){
                    draw.SetActive(true);
        }
    }

   
} 


