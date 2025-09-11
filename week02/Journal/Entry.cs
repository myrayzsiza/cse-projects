using System;

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public int Mood { get; set; }  // NEW: Mood rating 1–5

    public Entry(string date, string prompt, string response, int mood)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
        Mood = mood;
    }

    public override string ToString()
    {
        return $"{Date} | Mood: {Mood}/5 | {Prompt}\n{Response}\n";
    }
}
