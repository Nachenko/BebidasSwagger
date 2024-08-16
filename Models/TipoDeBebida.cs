using System.ComponentModel.DataAnnotations;

public class TipoDeBebida
{
   [Key]
    public int IdTipoDeBebida { get; set; }
    public string Descripcion { get; set; }
}
