using task_junior;

List<Interval> Hold_intervals = new List<Interval>();

Hold_intervals.Add(new Interval("12:30", "13:00"));
Hold_intervals.Add(new Interval("15:50", "16:20"));
Hold_intervals.Add(new Interval("17:30", "18:00"));
Hold_intervals.Add(new Interval("18:05", "19:00"));
Hold_intervals.Add(new Interval("21:30", "23:00"));


List<Interval> Free_intervals = new List<Interval>();

int ParserToMinute(string time)
{
    int hour = 0;
    int minute = 0;

    string hourS = string.Empty;
    int index = 0;
    for (int i = 0; time[i] != ':'; i++)
    {
        hourS += time[i];
        index++;
    }
    hour = int.Parse(hourS) * 60;

    string minuteS = string.Empty;
    for (int i = index + 1; i < time.Length; i++)
    {
        minuteS += time[i];
    }
    minute = int.Parse(minuteS);

    return hour + minute;
}

string ParserToTime(int time)
{
    string res = string.Empty;
    if (time == 0)
    {
        res = "00:00";
    }
    else
    {
        res = (time / 60).ToString() + ":" + (time % 60).ToString();
    }

    return res;
}

void GetBusyTime(ref List<Interval> Free_intervals, Interval interval)
{
    int startTime = ParserToMinute(interval.startTime);
    int endTime = ParserToMinute(interval.EndTime);

    int indexFirst = 0;
    int indexLast = 0;
    for (int i = 0; i < Free_intervals.Count; i++)
    {
        if (startTime >= ParserToMinute(Free_intervals[i].startTime) && startTime < ParserToMinute(Free_intervals[i].EndTime))
        {
            indexFirst = i;
        }

        if (endTime <= ParserToMinute(Free_intervals[i].EndTime) && endTime > ParserToMinute(Free_intervals[i].startTime))
        {
            indexLast = i;
        }
    }

    if (indexFirst == indexLast)
    {
        Free_intervals.RemoveAt(indexFirst);
    }
    else
    {
        Free_intervals.RemoveRange(indexFirst, indexLast - indexFirst + 1);
    }
}

List<Interval> Func(List<Interval> Hold_intervals)
{
    List<Interval> Free_intervals = new List<Interval>();
    for (int i = 0; i < 1440; i += 30)
    {
        Free_intervals.Add(new Interval(ParserToTime(i), ParserToTime(i + 30)));
    }

    for (int i = 0; i < Hold_intervals.Count; i++)
    {
        GetBusyTime(ref Free_intervals, Hold_intervals[i]);
    }

    return Free_intervals;
}



Free_intervals = Func(Hold_intervals);
for (int i = 0; i < Free_intervals.Count; i++)
{
    Console.WriteLine(Free_intervals[i].startTime + " - " + Free_intervals[i].EndTime);
}