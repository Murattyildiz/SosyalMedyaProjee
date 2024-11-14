namespace Entities.DTOs
{
    public class CommentDetailDto
    {
        public int Id { get; set; }

        public int İçerikId { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string CommentText { get; set; }

        public DateTime CommentDate { get; set; }
    }
}
