namespace GuessGameProgram.BaseOfTheGame;
// DIP и ISP. Узкий интерфейс, клиентам не навязываются лишние методы.
public interface IGameHintLogic
{
    GuessResultHint GetHint(int secret, int guess);
}
