using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Base
{
    [NotMapped]
    public abstract class Notifiable
    {
        public Notifiable()
        {
            Errors = new List<string>();
        }

        public IList<string> Errors { get; private set; }

        public bool IsFailure { get; private set; }

        public bool IsSuccess { get => !IsFailure; }

        public void AddErrorMessage(string mensage)
        {
            IsFailure = true;
            Errors.Add(mensage);
        }

        public void AddErrorsMessages(IEnumerable<string> mensages)
        {
            IsFailure = true;
            ((List<string>)Errors).AddRange(mensages);
        }
    }
}