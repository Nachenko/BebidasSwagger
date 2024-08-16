using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Bebida
{
   [Key]
    public int Id_bebida { get; set; }
    public string Descripcion { get; set; }
    public string Tamaño { get; set; }
    public string PaisOrigen { get; set; }

    // Foreign Key for TipoDeBebida (para poder hacer la relación)
    public int IdTipoDeBebida { get; set; }
   [JsonIgnore]
    public TipoDeBebida TipoDeBebida { get; set; }
  
}
