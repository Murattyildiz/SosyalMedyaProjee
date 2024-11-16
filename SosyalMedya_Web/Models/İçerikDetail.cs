namespace SosyalMedya_Web.Models
{
    public class İçerikDetail
    {
        public int Id { get; set; }
        public int KonuId { get; set; }

        public int UserId { get; set; }

        public string KonuTitle { get; set; }

        public string Content { get; set; }
        public string UserName { get; set; }

        public string SharingDate { get; set; }

        public List<CommentDetail> CommentDetails { get; set; }
    }
}
