

namespace Domain.Model.Entity
{
    public class Vinho
    {
        public string Coloracao { get; set; }
        public string Descricao { get; set; }
        public VinhoFamilia Familia { get; set; }
        public string Graduacao { get; set; }
        public int Id { get; set; }
        public string Nome { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} - {3}", Nome, Descricao, Coloracao, Graduacao);
        }
    }
}