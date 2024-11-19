namespace TriviaGame;
using static Console;
public class TriviaItem
{
    private string Question;
    private string Answer;

    public TriviaItem(string triviaQuestion, string triviaAnswer)
    {   
        Question = triviaQuestion;
        Answer = triviaAnswer;
    }

    public void AskQuestion()
    {
        // Todo this should display the question, get a repsonse
        // and display the coorrect answer
        WriteLine(Question);
        WriteLine("Whats your answer?");
        string playerAnswer = ReadLine();
        WriteLine($"You answer {playerAnswer}");
        WriteLine($"The correct answer is {Answer}");
    }
}