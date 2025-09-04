using GestionTareas.Domain.Enums;
using GestionTareas.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTareas.Domain.Entities
{
    [Table("Trabajos")]
    public class Job
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(400)]
        public string Description { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public State State { get; set; }
        public string? AdditionalData { get; set; }
        public Job() { }

        public Job(string title, string description, DateTime dueDate, State state, string? additionalData)
        {
            if(title == null) 
                throw new DomainException("Titulo nulo.");
            Title = title;

            if(description == null)
                throw new DomainException("Descripcion nula.");
            Description = description;

            if (dueDate == null)
                throw new DomainException("Fecha para completar la tarea nula.");
            DueDate = dueDate;

            if (state == null)
                throw new DomainException("Estado nulo.");
            State = state;
            
            AdditionalData = additionalData == null ? null : additionalData; 
        }

        public Job(int id,string title, string description, DateTime dueDate, State state, string? additionalData)
            : this(title, description, dueDate, state, additionalData)
        {
            Id = id;
        }
    }
}
