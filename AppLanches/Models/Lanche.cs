

using System.ComponentModel.DataAnnotations;

namespace AppLanches.Models

{
    public class Lanche
    {
        
        public int LancheId { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        [StringLength(100)]
        public string  DescricaoCurta { get; set; }
        [StringLength(250)]
        public string DescricaoDetalhada { get; set; }
        public decimal Preco { get; set; }
        [StringLength(250)]
        public string ImagemUrl { get; set; }
        [StringLength(250)]
        public string ImagemThumbnailUrl { get; set; }
        public bool IsLanchePreferido { get; set; }
        public bool EmEstoque { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}