namespace Dev.Freela.Application.InputModels.Projects
{
    public class CreateCommentInputModel
    {
        public string Content { get; set; }
        public int IdUser { get; set; }
        public int IdProject { get; set; }
    }
}
