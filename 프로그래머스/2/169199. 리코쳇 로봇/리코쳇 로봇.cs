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

        public BoardPoint Copy()
        {
            return new BoardPoint(Y, X);
        }
    }
    
    private static Dictionary<char, List<BoardPoint>> BoardCompDic { get; set; }
    private static Dictionary<BoardPoint, List<BoardPoint>> VisitedBoardPointDic { get; set; }

    private static int MaxCount_X { get; set; }
    private static int MaxCount_Y { get; set; }

    private static Queue<BoardPoint> MovedPointQue { get; set; }
    
    public int solution(string[] board) 
    {
        BoardCompDic = GetBoardCompDic(board);
        VisitedBoardPointDic = new Dictionary<BoardPoint, List<BoardPoint>>();

        MaxCount_X = board[0].Length - 1;
        MaxCount_Y = board.Length - 1;

        int answer = 0;

        MovedPointQue = new Queue<BoardPoint>();
        MovedPointQue.Enqueue(BoardCompDic['R'][0]);

        while (!MovedPointQue.Contains(BoardCompDic['G'][0]))
        {
            int cnt = MovedPointQue.Count;

            for (int i = 0; i < cnt; i++)
            {
                var beforePoint = MovedPointQue.Dequeue();

                AddMovedPointQueByDirection(beforePoint, new BoardPoint(-1, 0));
                AddMovedPointQueByDirection(beforePoint, new BoardPoint(0, +1));
                AddMovedPointQueByDirection(beforePoint, new BoardPoint(0, -1));
                AddMovedPointQueByDirection(beforePoint, new BoardPoint(+1, 0));
            }

            if (MovedPointQue.Count == 0) return -1;
            else answer++;
        }

        return answer;
    }
    
    private void AddMovedPointQueByDirection(BoardPoint point, BoardPoint movingPoint)
    {
        BoardPoint beforePoint = point.Copy();

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

        AddMovedPointQue(beforePoint, point);
    }
    
    private void AddMovedPointQue(BoardPoint point, BoardPoint movingPoint)
    {
        if (point != movingPoint)
        {
            VisitedBoardPointDic.TryAdd(movingPoint, new List<BoardPoint>());

            if (!VisitedBoardPointDic[movingPoint].Contains(point))
            {
                MovedPointQue.Enqueue(movingPoint);

                VisitedBoardPointDic[movingPoint].Add(point);
            }
        }
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