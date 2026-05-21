using System;
using System.Collections.Generic;

// I have removed the 'namespace Week03' block. 
// This class is now in the global namespace, matching the test file.

public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    public void MoveLeft()
    {
        bool[] moves = _mazeMap[(_currX, _currY)];
        if (moves[0]) // Left
        {
            _currX--;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public void MoveRight()
    {
        bool[] moves = _mazeMap[(_currX, _currY)];
        if (moves[1]) // Right
        {
            _currX++;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public void MoveUp()
    {
        bool[] moves = _mazeMap[(_currX, _currY)];
        if (moves[2]) // Up
        {
            _currY--;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public void MoveDown()
    {
        bool[] moves = _mazeMap[(_currX, _currY)];
        if (moves[3]) // Down
        {
            _currY++;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}