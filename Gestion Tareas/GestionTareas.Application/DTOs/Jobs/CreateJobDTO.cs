using GestionTareas.Domain.Enums;
using GestionTareas.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace GestionTareas.Application.DTOs.Jobs
{
    public class CreateJobDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public State State { get; set; }
        public string? AdditionalData { get; set; }

        [JsonConstructor]
        public CreateJobDTO(string title,string description, DateTime dueDate, State state, string? additionalData)
        {
            if (title == null)
                throw new DomainException("Titulo nulo.");
            Title = title;

            if (description == null)
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
    }
}
