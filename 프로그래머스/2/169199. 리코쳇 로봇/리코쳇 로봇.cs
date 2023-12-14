using System.Collections.Generic;
using System.Linq;

public class Solution 
{
    private struct BoardPoint
    {
        public int X { get; set; }

        public int Y { get; set; }

        public static BoardPoint operator +(BoardPoint a, BoardPoint b)
        {
            a.Y += b.Y;
            a.X += b.X;

            return a;
        }

        public static BoardPoint operator -(BoardPoint a, BoardPoint b)
        {
            a.Y -= b.Y;
            a.X -= b.X;

            return a;
        }

        public static BoardPoint operator *(BoardPoint a, int b)
        {
            a.Y *= b;
            a.X *= b;

            return a;
        }

        public static bool operator ==(BoardPoint a, BoardPoint b)
        {
            return a.Y == b.Y && a.X == b.X;
        }

        public static bool operator !=(BoardPoint a, BoardPoint b)
        {
            return a.Y != b.Y || a.X != b.X;
        }

        public override string ToString()
        {
            return Y + " " + X;
        }

        public BoardPoint(int y, int x)
        {
            Y = y;
            X = x;
        }
    }
    
    private Dictionary<char, List<BoardPoint>> BoardCompDic { get; set; }
    private Dictionary<BoardPoint, List<BoardPoint>> VisitedBoardPointDic { get; set; }

    private int MaxCount_X { get; set; }
    private int MaxCount_Y { get; set; }
    
    public int solution(string[] board) 
    {
        BoardCompDic = GetBoardCompDic(board);
    VisitedBoardPointDic = new Dictionary<BoardPoint, List<BoardPoint>>();
    MaxCount_X = board[0].Length - 1;
    MaxCount_Y = board.Length - 1;

    var currPointList = Moving(BoardCompDic['R'][0]);

    int answer = 1;
    while (!currPointList.Contains(BoardCompDic['G'][0]))
    {
        currPointList = Moving(currPointList);

        if(currPointList.Count == 0)
        {
            answer = -1;
            break;
        }
        else answer++;
    }

    return answer;
    }
    
    private List<BoardPoint> Moving(List<BoardPoint> beforePointList)
    {
        List<BoardPoint> list = new List<BoardPoint>();

        foreach (var item in beforePointList)
        {
            list.AddRange(Moving(item));
        }

        return list;
    }
    
    private List<BoardPoint> Moving(BoardPoint beforePoint)
    {
        List < BoardPoint > valList = new List<BoardPoint>();

        List<BoardPoint> movingPointList = new List<BoardPoint>() 
        {
            new BoardPoint(-1, 0),
            new BoardPoint(0, +1),
            new BoardPoint(0, -1),
            new BoardPoint(+1, 0),
        };

        foreach (BoardPoint movingPoint in movingPointList)
        {
            BoardPoint tempPoint = MovingByDirection(beforePoint, movingPoint);

            if (beforePoint != tempPoint)
            {
                VisitedBoardPointDic.TryAdd(tempPoint, new List<BoardPoint>());

                if (!VisitedBoardPointDic[tempPoint].Contains(beforePoint))
                {
                    valList.Add(tempPoint);

                    VisitedBoardPointDic[tempPoint].Add(beforePoint);
                }
            }
        }

        return valList;
    }
    
    private BoardPoint MovingByDirection(BoardPoint point, BoardPoint movingPoint)
    {
        while (movingPoint.X != 0 && (movingPoint.X == +1 ? point.X != MaxCount_X : point.X != 0)
               ||
               movingPoint.Y != 0 && (movingPoint.Y == +1 ? point.Y != MaxCount_Y : point.Y != 0))
        {
            point += movingPoint;

            if (BoardCompDic.TryGetValue('D', out List<BoardPoint> dVal))
            {
                if (dVal.Any(i => i == point))
                {
                    point += movingPoint * -1;

                    break;
                }
            }
        }

        return point;
    }
    
    private Dictionary<char, List<BoardPoint>> GetBoardCompDic(string[] board)
    {
        var boardCompDic = new Dictionary<char, List<BoardPoint>>();

        for (int i = 0; i < board.Count(); i++)
        {
            for (int j = 0; j < board[i].Count(); j++)
            {
                char val = board[i][j];

                if (val == '.')
                {
                    continue;
                }
                else if (boardCompDic.ContainsKey(val))
                {
                    boardCompDic[val].Add(new BoardPoint(i, j));
                }
                else
                {
                    boardCompDic.Add(val, new List<BoardPoint>() { new BoardPoint(i, j) });
                }
            }
        }

        return boardCompDic;
    }
}