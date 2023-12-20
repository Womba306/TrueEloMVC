namespace TrueEloMVC.Models.Components
{
    public class TimeViewComponent
    {
        public string Invoke()
        {
            return $"Время сейчас {DateTime.Now.ToString("F")}";
        }
    }
}
