namespace SharedApi.Models
{
    public class Model
    {
        public string Text { get; set; }

        public static Model Example()
        {
            return new Model
            {
                Text = "Example Text"
            };
        }
    }
}
