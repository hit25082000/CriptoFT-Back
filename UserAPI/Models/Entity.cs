namespace UserAPI.Models
{
    public class Entity
    {
       private static int minhaPropriedadeEstatica { get; set; }

        public int Id { get; set; }

        public Entity()
        {
            minhaPropriedadeEstatica++;
            Id = minhaPropriedadeEstatica;
        }
    }
}
