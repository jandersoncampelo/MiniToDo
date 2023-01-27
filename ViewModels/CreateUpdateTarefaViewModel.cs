using System.ComponentModel.DataAnnotations;
using Flunt.Notifications;
using Flunt.Validations;
using MiniToDo.Models;

namespace MiniToDo.ViewModels
{
    public class CreateUpdateTarefaViewModel : Notifiable<Notification>
    {
        [Required]
        public string? Titulo { get; set; }

        public Tarefa MapTo()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(Titulo, "Titulo", "Titulo é obrigatório")
                .IsGreaterThan(Titulo, 5, "Titulo", "Titulo precisar ter pelo menos 5 caracteres")
            );

            return new Tarefa(
                Id: Guid.NewGuid(),
                Titulo: Titulo ?? "Default",
                Finalizada: false
            );
        }
    }
}