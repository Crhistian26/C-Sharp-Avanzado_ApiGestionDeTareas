using GestionTareas.Domain.Enums;
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
        [MaxLength(400)]
        public string Description { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public State State { get; set; }
        public string AdditionalData { get; set; }
        public Job() { }

        public Job(string description, DateTime dueDate, State state, string additionalData)
        {
            Description = description;
            DueDate = dueDate;
            State = state;
            AdditionalData = additionalData;
        }

        public Job(int id, string description, DateTime dueDate, State state, string additionalData)
            : this(description, dueDate, state, additionalData)
        {
            Id = id;
        }
    }
}
