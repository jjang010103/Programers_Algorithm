using System;
using System.Collections.Generic;
using System.Linq;

public class Solution 
{
    class ParkLog
    {
        public DateTime Time { get; set; }
        public int CarNo { get; set; }
        public bool IsIn { get; set; }

        public ParkLog(string time, string carNo, string inOut)
        {
            Time = Convert.ToDateTime(time);
            CarNo = Convert.ToInt32(carNo);
            IsIn = inOut == "IN" ? true : false;
        }

        public static readonly DateTime EndTime = Convert.ToDateTime("23:59");
    }
    
    public int[] solution(int[] fees, string[] records) 
    {
        var parkLogArr = GetParkLog(records);

        var parkingTotalTimeArr = GetParkingTotalTimeArr(parkLogArr);

        //정산
        int[] answer = new int[parkingTotalTimeArr.Count()];

        int index = 0;
        foreach (int totalParkingTime in parkingTotalTimeArr)
        {
            if (totalParkingTime > fees[0])
            {
                double temp = ((double)totalParkingTime - fees[0]) / fees[2];

                answer[index++] = fees[1] + ((int)Math.Ceiling(temp) * fees[3]);
            }
            else
            {
                answer[index++] = fees[1];
            }
        }

        return answer;
    }
    
    private IEnumerable<ParkLog> GetParkLog(string[] records)
    {
        foreach (string record in records)
        {
            var temp = record.Split(' ');

            yield return new ParkLog(temp[0], temp[1], temp[2]);
        }
    }

    private IEnumerable<int> GetParkingTotalTimeArr(IEnumerable<ParkLog> parkLogs)
    {
        Dictionary<int, int> carParkingDic = new Dictionary<int, int>();

        ParkLog beforeLog = null;

        foreach (ParkLog log in parkLogs.OrderBy(i => i.CarNo).ThenBy(i => i.Time))
        {
            SumMinDate(carParkingDic, beforeLog, log);

            beforeLog = log;
        }

        if(beforeLog.IsIn) SumMinDate(carParkingDic, beforeLog);

        return carParkingDic.Values;
    }

    private void SumMinDate(Dictionary<int, int> carParkingDic, ParkLog beforeLog, ParkLog log = null)
    {
        bool isEmptyOutDate = log == null || log.IsIn == (beforeLog?.IsIn ?? !log.IsIn);

        if (beforeLog != null && (isEmptyOutDate || !log.IsIn))
        {
            TimeSpan parkingTime = (isEmptyOutDate ? ParkLog.EndTime : log.Time) - beforeLog.Time;

            if (!carParkingDic.TryAdd(beforeLog.CarNo, (int)parkingTime.TotalMinutes))
            {
                carParkingDic[beforeLog.CarNo] += (int)parkingTime.TotalMinutes;
            }
        }
    }
}