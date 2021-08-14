namespace AplicacionDeContactos.Models
{
    interface IContactos
    {
        string Apellido { get; set; }
        int Id { get; set; }
        string Nombre { get; set; }
        long Numero { get; set; }
    }
}