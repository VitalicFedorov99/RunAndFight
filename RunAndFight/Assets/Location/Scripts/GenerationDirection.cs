using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RunAndFight.Location
{
    public class GenerationDirection : MonoBehaviour
    {
        public int CountBlock;
        public int StartBlock;
        public int EndBlock;

        public List<Direction> ListDirections;
        public Direction currentDirection;
        public int percentChangeDirection;
        public int countBlockForChangeDirection;


        
        public void CreateListDirection() 
        {
            ListDirections = new List<Direction>();
            currentDirection = Direction.Forward;
            for(int i = 0; i < StartBlock; i++) 
            {
                ListDirections.Add(currentDirection);
            }
            CountBlock = (CountBlock - StartBlock) - EndBlock;
           
            int count = 0;
            ChangeDirection(percentChangeDirection);
            for(int i = 0; i < CountBlock ; i++)
            {
                count++;
                if (count >= countBlockForChangeDirection) 
                {
                    ChangeDirection(percentChangeDirection);
                    count = 0;
                }
                ListDirections.Add(currentDirection);
            }
            for (int i=0;i<EndBlock; i++) 
            {
                ListDirections.Add(currentDirection);
            }

            ChangeLeftAndRightInHorizontal();
            
            
        }

        public void CreateForwardRoute() 
        {
            ListDirections = new List<Direction>();
            currentDirection = Direction.Forward;
            for (int i = 0; i < CountBlock; i++)
            {
                ListDirections.Add(Direction.Forward);
            }
        }
        
       private void ChooseDirection() 
        {
            
            switch (currentDirection) 
            {
                case Direction.Forward:
                    {
                        int rand = Random.Range(0, 2);// 0 влево 1 вправо
                        if (rand == 0)
                        {
                            currentDirection = Direction.Left;
                        }
                        else currentDirection = Direction.Right;
                        break;
                    }
                case Direction.Left:
                    {
                        int rand = Random.Range(0, 2);// 0 влево 1 возвращение вперед
                        if (rand == 0)
                        {
                            currentDirection = Direction.Left;
                        }
                        else currentDirection = Direction.Forward;
                        break;
                    }
                case Direction.Right:
                    {
                        int rand = Random.Range(0, 2);// 0 вправо 1 возвращение вперед
                        if (rand == 0)
                        {
                            currentDirection = Direction.Right;
                        }
                        else currentDirection = Direction.Forward;
                        break;
                    }
            }
        }


       private void ChangeDirection(int percent)
        {
            int rand = Random.Range(0, 100);
            if (percent >= rand)
            {
                ChooseDirection();
            }
            
        }

       private void ChangeLeftAndRightInHorizontal() 
       {
            currentDirection = ListDirections[0];
            Direction nextDirection = Direction.Back;
            for (int i = 0; i < ListDirections.Count; i++) 
            {
                currentDirection = ListDirections[i];
                if(i < ListDirections.Count-1) 
                {
                    if (currentDirection != ListDirections[i + 1])
                    {
                        nextDirection = ListDirections[i + 1];
                        switch (currentDirection)
                        {
                            case Direction.Forward:
                                {

                                    if (nextDirection == Direction.Right)
                                    {
                                        ListDirections[i] = Direction.Forward_Right;
                                    }
                                    if (nextDirection == Direction.Left)
                                    {
                                        ListDirections[i] = Direction.Forward_Left;
                                    }
                                    break;
                                }
                            case Direction.Right:
                                {
                                    if (nextDirection == Direction.Forward)
                                    {
                                        ListDirections[i] = Direction.Right_Forward;
                                    }
                                    break;
                                }
                            case Direction.Left:
                                {
                                    if (nextDirection == Direction.Forward)
                                    {
                                        ListDirections[i] = Direction.Left_Forward;
                                    }
                                    break;
                                }
                        }
                    }
                }             
            } 
       }
       


    }
}