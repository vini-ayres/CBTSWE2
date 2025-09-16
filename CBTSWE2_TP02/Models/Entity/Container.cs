namespace TP02.Models.Entity;

public class Container
{
    public int Id { get; set; }
    public string Numero { get; set; }
    public string Tipo { get; set; }
    public int Tamanho { get; set; }
    public int BillId { get; set; }

    public virtual BillOfLading? Bill { get; set; }
}
