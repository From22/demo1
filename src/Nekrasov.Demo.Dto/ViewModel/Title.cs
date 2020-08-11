namespace Nekrasov.Demo.Dto.ViewModel
{
    public class Title
    {
        public string Text { get; set; }

        public bool IsWarning { get; set; }

        public string Class => IsWarning ? "text-danger" : "text-success";
    }
}