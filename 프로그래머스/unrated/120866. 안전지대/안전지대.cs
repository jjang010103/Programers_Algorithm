using System;

public class Solution {
    
    private int MaxLength_X { get; set; }

    private int MaxLength_Y { get; set; }

    private int DangerAreaCount { get; set; }
    
    public int solution(int[,] board)
    {
        this.MaxLength_X = board.GetLength(0);
        this.MaxLength_Y = board.GetLength(1);

        this.DangerAreaCount = 0;

        for (int i = 0; i < this.MaxLength_X; i++)
        {
            
            for (int j = 0; j < this.MaxLength_Y; j++)
            {
                if (board[i, j] == 1)
                {
                    CheckBombValue(i, j, board);
                }
            }
        }

        return board.Length - this.DangerAreaCount;
    }

    private void CheckBombValue(int x, int y, int[,] board)
    {
        CheckValue(x, y, board);

        CheckBombValue_Nearby(x, y + 1, board);
        CheckBombValue_Nearby(x, y - 1, board);
        CheckBombValue_Nearby(x - 1, y, board);
        CheckBombValue_Nearby(x + 1, y, board);

        CheckBombValue_Nearby(x - 1, y - 1, board);
        CheckBombValue_Nearby(x - 1, y + 1, board);
        CheckBombValue_Nearby(x + 1, y + 1, board);
        CheckBombValue_Nearby(x + 1, y - 1, board);
    }

    private void CheckBombValue_Nearby(int x, int y, int[,] board)
    {
        if (x < 0 || this.MaxLength_X <= x || y < 0 || this.MaxLength_Y <= y) return;

        if(board[x, y] == 1)
        {
            CheckBombValue(x, y, board);
        }
        else if (board[x, y] == 0)
        {
            CheckValue(x, y, board);
        }
    }

    private void CheckValue(int x, int y, int[,] board)
    {
        board[x, y] = -1;
        this.DangerAreaCount += 1;
    }
}