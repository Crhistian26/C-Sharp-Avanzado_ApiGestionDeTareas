using GestionTareas.Domain.Entities;
using GestionTareas.Domain.Enums;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GestionTareas.Application.DTOs.Jobs
{

    public class JobDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public State State { get; set; }
        public string AdditionalData { get; set; }
        public JobDTO() { }

        public JobDTO(string description, DateTime dueDate, State status, string additionalData)
        {
            Description = description;
            DueDate = dueDate;
            State = status;
            AdditionalData = additionalData;
        }

        public JobDTO(int id, string description, DateTime dueDate, State status, string additionalData)
            : this(description, dueDate, status, additionalData)
        {
            Id = id;
        }

        public JobDTO(Job job)
        {
            Id = job.Id;
            Description = job.Description;
            DueDate = job.DueDate;
            State = job.State;
            AdditionalData = job.AdditionalData;
        }
    }
}
