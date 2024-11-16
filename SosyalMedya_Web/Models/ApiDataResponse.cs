namespace SosyalMedya_Web.Models
{
    public class ApiDataResponse<T>
    {
        public List<T> Data { get; set; }

        public bool Succes  { get; set; }

        public string Message { get; set; }

    }
}
